using Ozon.MerchApi.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Ozon.MerchApi.HttpClients
{
    public interface IMerchHttpClient
    {
        Task<MerchResponse> GetMerch(MerchRequest merchRequest, CancellationToken token);

        Task<MerchResponse> GetInfo(MerchRequest merchRequest, CancellationToken token);
    }

    public class MerchHttpClient : IMerchHttpClient
    {
        private readonly HttpClient _httpClient;

        public MerchHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<MerchResponse> GetMerch(MerchRequest merchRequest, CancellationToken token)
        {
            using var response = await _httpClient.GetAsync($"api/merchandise/{merchRequest.EmployeerId}/merch/", token);
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<MerchResponse>(body);
        }

        public async Task<MerchResponse> GetInfo(MerchRequest merchRequest, CancellationToken token)
        {
            using var response = await _httpClient.GetAsync($"api/merchandise/{ merchRequest.EmployeerId}/info/", token);
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<MerchResponse>(body);
        }
    }
}