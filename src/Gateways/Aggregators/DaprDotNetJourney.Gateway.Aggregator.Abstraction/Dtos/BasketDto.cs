namespace DaprDotNetJourney.Gateway.Aggregator.Abstraction.Dtos;

public class BasketDto
{
    public List<BasketItemDto> Items { get; set; } = new List<BasketItemDto>();
}
