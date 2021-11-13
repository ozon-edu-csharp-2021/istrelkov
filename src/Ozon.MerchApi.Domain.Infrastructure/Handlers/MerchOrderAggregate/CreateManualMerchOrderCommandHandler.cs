using MediatR;

using Ozon.MerchApi.Domain.AggregationModels.Enumerations;
using Ozon.MerchApi.Domain.AggregationModels.ItemPackAggregate;
using Ozon.MerchApi.Domain.AggregationModels.MerchOrderAggregate;
using Ozon.MerchApi.Domain.AggregationModels.MerchPackAggregate;
using Ozon.MerchApi.Domain.AggregationModels.SkuPackAggregate;
using Ozon.MerchApi.Domain.AggregationModels.ValueObjects;
using Ozon.MerchApi.Domain.Infrastructure.Commands.CreateMerchOrder;
using Ozon.MerchApi.Domain.Infrastructure.Services;
using Ozon.MerchApi.HttpModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ozon.MerchApi.Domain.Infrastructure.Handlers.MerchOrderAggregate
{
    public class CreateManualMerchOrderCommandHandler : IRequestHandler<CreateManualMerchOrderCommand, int>
    {
        private readonly IMerchOrderRepository _merchOrderRepository;
        private readonly IMerchPackRepository _merchPackRepository;
        private readonly IStockApiService _stockApiService;
        private readonly IEmailService _emailService;

        public CreateManualMerchOrderCommandHandler(
                                              IMerchOrderRepository stockItemRepository,
                                              IMerchPackRepository merchPackRepository,
                                              IStockApiService stockApiService,
                                              IEmailService emailService)
        {
            _merchOrderRepository = stockItemRepository;
            _merchPackRepository = merchPackRepository;
            _stockApiService = stockApiService;
            _emailService = emailService;
        }

        public async Task<int> Handle(CreateManualMerchOrderCommand request, CancellationToken cancellationToken)
        {
            MerchOrder merchOrder = await _merchOrderRepository.FindIssuedMerchAsync(request.EmployeeId, request.MerchPackId, cancellationToken);
            if (merchOrder is not null)
            {
                throw new Exception($"Merch has already been issued");
            }

            MerchPackType merchPackType = MerchPackType.GetAll<MerchPackType>().FirstOrDefault(m => m.Id == request.MerchPackId);

            MerchPack merchPack = await _merchPackRepository.FindByTypeAsync(merchPackType, cancellationToken);

            IEnumerable<long> merchPackItems = merchPack.ItemPackCollection.Select(ip => ip.StockItem.Value).ToHashSet();

            List<StockItemResponse> stockItems = await _stockApiService.GetAll(cancellationToken);

            Dictionary<long, StockItemResponse> stockItemsById = stockItems
                .Where(i => merchPackItems.Contains(i.Id) && (i.ClothingSize is null || i.ClothingSize == request.ClothingSize))
                .ToDictionary(i => i.Id);

            bool isEnough = true;

            List<SkuPack> skuPacks = new();

            foreach (ItemPack itemPack in merchPack.ItemPackCollection)
            {
                stockItemsById.TryGetValue(itemPack.StockItem.Value, out StockItemResponse stockItem);           

                if (itemPack.Quantity.Value <= stockItem.Quantity)
                {
                    isEnough = false;
                }
                skuPacks.Add(new SkuPack(new Sku(stockItem.Sku), itemPack.Quantity));
            }

            merchOrder = new MerchOrder(
                request.EmployeeId,
                skuPacks,
                MerchRequestType.Manual,
                merchPackType);

            if (isEnough)
            {
                bool isReserved = await _stockApiService.Reserve(skuPacks, cancellationToken);
                if (isReserved)
                {
                    merchOrder.Reserve();
                    bool isSent = await _emailService.SendMail(request.EmployeeId, cancellationToken);
                    if (isSent)
                    {
                        merchOrder.Done();
                    }
                }
            }

            merchOrder = await _merchOrderRepository.CreateAsync(merchOrder, cancellationToken);

            return merchOrder.Id;
        }
    }
}