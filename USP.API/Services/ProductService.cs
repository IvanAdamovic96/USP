namespace USP.API.Services;

public class ProductService : IProductService
{
    public async Task<string> GetProduct()
    {
        return "Product 1";
    }

    public async Task<string> CreateProduct()
    {
        return "Product created";
    }
}