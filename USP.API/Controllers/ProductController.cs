using Microsoft.AspNetCore.Mvc;
using USP.Application.Common.Dto;
using USP.Application.Products.Commands;
using USP.Application.Products.Queries;

namespace USP.API.Controllers;

public class ProductController : ApiBaseController
{
    [HttpGet]
    public async Task<ActionResult>Get([FromQuery]GetOneProductQuery query)
    {
        return Ok(await Mediator.Send(query));
    }

    [HttpPost]
    public async Task<ActionResult>ProductAdd(CreateProductCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
}

