using Microsoft.AspNetCore.Mvc;
using USP.Application.Product.Commands;
using USP.Application.Product.Queries;

namespace USP.API.Controllers;

public class ProductController : ApiBaseController
{
    [HttpGet]
    public async Task<string>GetProduct()
    {
        return await Mediator.Send(new GetOneProductQuery());
    }

    [HttpPost]
    public async Task<string>ProductAdd(CreateProductCommand command)
    {
        return await Mediator.Send(command);
    }
}

