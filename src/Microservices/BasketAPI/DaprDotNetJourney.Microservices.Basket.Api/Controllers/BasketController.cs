using DaprDotNetJourney.Microservices.Basket.Abstraction.Dtos;
using DaprDotNetJourney.Microservices.Basket.Application.UpdateBasketDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DaprDotNetJourney.Microservices.Basket.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[AllowAnonymous]
public class BasketController : ControllerBase
{
    private readonly IMediator _mediator;

    public BasketController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(BasketDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<BasketDto>> UpdateBasketAsync([FromBody] BasketDto value)
    {
        var res = await _mediator.Send(new UpdateBasketCommand(value.BuyerId, value.Items));

        return res.Success ? Ok(res) : NoContent();
    }

}