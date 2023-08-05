using DaprDotNetJourney.Gateway.Aggregator.Abstraction.Dtos;
using DaprDotNetJourney.Gateway.Aggregator.Abstraction.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DaprDotNetJourney.Gateway.Aggregator.Api.Controllers;

[Route("api/v1/[controller]")]
[AllowAnonymous]
[ApiController]
public class BasketController : ControllerBase
{
    private readonly IBasketService _basket;
    public BasketController(IBasketService basket)
    {
        _basket = basket;
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(BasketDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> UpdateBasketAsync(
        [FromBody] BasketDto basket)
    {
        return Ok(await _basket.CreateAsync(basket));
    }
}
