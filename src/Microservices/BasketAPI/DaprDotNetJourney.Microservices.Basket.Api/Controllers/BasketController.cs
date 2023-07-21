using DaprDotNetJourney.Microservices.Basket.Abstraction.Dtos;
using DaprDotNetJourney.Microservices.Basket.Abstraction.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DaprDotNetJourney.Microservices.Basket.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[AllowAnonymous]
public class BasketController : ControllerBase
{
    private readonly IBasketService _basketService;

    public BasketController(
        IBasketService basketService)
    {
        _basketService = basketService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(BasketDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<BasketDto>> UpdateBasketAsync([FromBody] BasketDto value)
    {
        return Ok(await _basketService.UpdateBasketAsync(value));
    }

}