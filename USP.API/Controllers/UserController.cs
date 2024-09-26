using Microsoft.AspNetCore.Mvc;

namespace USP.API.Controllers;

public class UserController : ApiBaseController
{
    [HttpGet]
    public string GetUser()
    {
        return "Ivan";
    }

    [HttpPost]
    public string Create()
    {
        return "Ivan created";
    }
}