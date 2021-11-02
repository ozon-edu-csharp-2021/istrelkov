using Ozon.MerchApi.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Ozon.MerchApi.HttpClients
{
    public class MerchHttpClient : IMerchHttpClient
    {
        private readonly HttpClient _httpClient;

        public MerchHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IssueMerchResponse> IssueMerch(IssueMerchRequest issueMerchRequest, CancellationToken token)
        {
            using var response =
                await _httpClient.GetAsync($"api/merchandise/{issueMerchRequest.EmployeeId}/issue/", token);
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<IssueMerchResponse>(body);
        }

        public async Task<CheckWasIssuedMerchResponse> CheckWasIssuedMerch(
            CheckWasIssuedMerchRequest checkWasIssuedMerchRequest, CancellationToken token)
        {
            using var response =
                await _httpClient.GetAsync($"api/merchandise/{checkWasIssuedMerchRequest.EmployeeId}/issue-info/",
                    token);
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<CheckWasIssuedMerchResponse>(body);
        }
    }
}