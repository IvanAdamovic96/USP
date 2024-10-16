using MongoDB.Entities;
using USP.Application.Common.Interfaces;
using USP.Domain.Entities;

namespace USP.Infrastructure.Services;

public class ProductService : IProductService
{
    public async Task<List<Product>> GetAllProductsAsync(CancellationToken cancellationToken)
    {
        return await DB.Find<Product>().ExecuteAsync(cancellationToken);
    }
    
}