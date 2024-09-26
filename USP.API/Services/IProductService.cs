namespace USP.API.Services;

public interface IProductService
{
    Task<string> GetProduct();
    Task<string> CreateProduct();
}