using DaprDotNetJourney.Framework.Abstractions.Application.Models;
using DaprDotNetJourney.Gateway.Aggregator.Abstraction.Dtos;

namespace DaprDotNetJourney.Gateway.Aggregator.Abstraction.Services
{
    public interface IBasketService
    {
        Task<Result<BasketDto>> CreateAsync(BasketDto basket);
    }
}
