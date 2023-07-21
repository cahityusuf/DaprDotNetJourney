using DaprDotNetJourney.Framework.Abstractions.Application.Models;
using DaprDotNetJourney.Microservices.Basket.Abstraction.Dtos;
using DaprDotNetJourney.Microservices.Basket.Abstraction.Services;

namespace DaprDotNetJourney.Microservices.Basket.Application.Services
{
    public class BasketService : IBasketService
    {
        public async Task<Result<BasketDto>> UpdateBasketAsync(BasketDto basket)
        {
            return new SuccessResult<BasketDto>(basket)
            {
                Messages = new List<string>
                {
                    "Ürün sepete kaydedildi"
                }
            };
        }
    }
}
