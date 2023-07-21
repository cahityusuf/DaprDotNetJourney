namespace DaprDotNetJourney.Gateway.Aggregator.Abstraction.Dtos;

public record BasketItemDto(int ProductId, string ProductName, decimal UnitPrice, int Quantity);
