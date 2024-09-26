using Microsoft.AspNetCore.Mvc;

namespace USP.API.Controllers;

public class ProductController : ApiBaseController
{
    [HttpGet]
    public string GetProduct()
    {
        return "Apple";
    }

    [HttpPost]
    public string ProductAdd()
    {
        return "Apple added";
    }
}