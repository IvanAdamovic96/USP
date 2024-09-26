namespace USP.API.Services;

public interface IUserService
{
    Task<string> GetUser();
    Task<string> CreateUser();
}