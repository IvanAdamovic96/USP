using Microsoft.AspNetCore.Mvc;
using USP.Application.Common.Dto;
using USP.Application.Product.Commands;
using USP.Application.Product.Queries;

namespace USP.API.Controllers;

public class ProductController : ApiBaseController
{
    [HttpGet]
    public async Task<ActionResult>Get([FromQuery]GetOneProductQuery query)
    {
        return Ok(await Mediator.Send(query));
    }

    [HttpPost]
    public async Task<ActionResult>ProductAdd(ProductCreateDto command)
    {
        return Ok(await Mediator.Send(command));
    }
}

