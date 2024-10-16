using USP.Domain.Entities;

namespace USP.Application.Common.Interfaces;

//sluzi nam da definisemo querije kako ih ne bi povaljali svuda

public interface IProductService
{
    Task<List<Product>> GetAllProductsAsync(CancellationToken cancellationToken);
}