using Dapr.Client;
using DaprDotNetJourney.Framework.Abstractions.Application.Models;
using DaprDotNetJourney.Gateway.Aggregator.Abstraction.Dtos;
using DaprDotNetJourney.Gateway.Aggregator.Abstraction.Services;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace DaprDotNetJourney.Gateway.Aggregator.Application.Services
{
    public class BasketService: IBasketService
    {
        private readonly HttpClient _httpClient;

        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
        public async Task<Result<BasketDto>> CreateAsync(BasketDto basket)
        {

            var response = await _httpClient.PostAsJsonAsync("api/v1/basket", basket);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<SuccessResult<BasketDto>>(content);
            }

            return new NoContentResult<BasketDto>();
        }

    }
}
