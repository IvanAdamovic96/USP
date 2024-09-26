using Microsoft.AspNetCore.Mvc;
using USP.API.Services;

namespace USP.API.Controllers;

public class UserController(IUserService userService, IProductService productService) : ApiBaseController
{
    [HttpGet]
    public async Task<string>GetUser() => (await userService.GetUser());
    

    [HttpPost]
    public async Task<string> Create()
    {
        var result = await userService.CreateUser();
        await productService.CreateProduct();
        return result;
    }
}