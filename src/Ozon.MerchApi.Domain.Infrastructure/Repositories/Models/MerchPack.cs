using System.Collections.Generic;

namespace Ozon.MerchApi.Domain.Infrastructure.Repositories.Models
{
    public class MerchPack
    {
        public long Id { get; set; }

        public int PackTypeId { get; set; }

        public string PackTypeName { get; set; }

        public IEnumerable<ItemPack> ItemPackCollection { get; set; }
    }
}