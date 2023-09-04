using DaprDotNetJourney.Framework.Abstractions.Application.Models;
using DaprDotNetJourney.Microservices.Basket.Abstraction.Dtos;
using MediatR;

namespace DaprDotNetJourney.Microservices.Basket.Application.Services.UpdateBasketDetails.Commands
{
    public class UpdateBasketCommand : IRequest<Result<BasketDto>>
    {

        public UpdateBasketCommand(string buyerId, List<BasketItemDto> items)
        {
            BuyerId = buyerId;
            Items = items;
        }

        public Guid Id => Guid.NewGuid();

        public string BuyerId { get; set; } = "";
        public List<BasketItemDto> Items { get; set; } = new List<BasketItemDto>();

    }
}
