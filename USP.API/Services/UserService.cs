namespace USP.API.Services;

public class UserService : IUserService
{
    public async Task<string> GetUser()
    {
        return "Ivan";
    }

    public async Task<string> CreateUser()
    {
        return "User created";
    }
}