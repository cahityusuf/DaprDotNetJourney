using DaprDotNetJourney.Framework.Abstractions.Application.Models;
using DaprDotNetJourney.Microservices.Basket.Abstraction.Dtos;

namespace DaprDotNetJourney.Microservices.Basket.Abstraction.Services
{
    public interface IBasketService
    {
        Task<Result<BasketDto>> UpdateBasketAsync(BasketDto basket);
    }
}
