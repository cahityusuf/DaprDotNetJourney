using DaprDotNetJourney.Framework.Abstractions.Application.Models;
using DaprDotNetJourney.Framework.Dapr.Abstractions;
using DaprDotNetJourney.Microservices.Basket.Abstraction.Dtos;
using MediatR;

namespace DaprDotNetJourney.Microservices.Basket.Application.Services.UpdateBasketDetails.Commands
{
    public class UpdateBasketCommandHandler : IRequestHandler<UpdateBasketCommand, Result<BasketDto>>
    {
        private readonly IDaprStateStore _stateStore;
        public UpdateBasketCommandHandler(IDaprStateStore stateStore)
        {
            _stateStore = stateStore;
        }
        private const string DAPR_PUBSUB_NAME = "pubsub";
        public async Task<Result<BasketDto>> Handle(UpdateBasketCommand request, CancellationToken cancellationToken)
        {
            await _stateStore.UpdateStateAsync(DAPR_PUBSUB_NAME, request.BuyerId, request);

            var basket = await _stateStore.GetStateAsync<BasketDto>(DAPR_PUBSUB_NAME, request.BuyerId);

            return new SuccessResult<BasketDto>(basket)
            {
                Messages = new List<string>
                    {
                        "Ürün sepete eklendi"
                    }
            };
        }
    }
}
