namespace DaprDotNetJourney.Microservices.Basket.Abstraction.Dtos;

public record BasketItemDto(int ProductId, string ProductName, decimal UnitPrice, int Quantity);
