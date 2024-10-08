using MediatR;
using MongoDB.Entities;
using USP.Application.Common.Dto;
using USP.Application.Common.Mappers;
using USP.Domain.Entities;
using USP.Domain.Enums;

namespace USP.Application.Product.Commands;

public record CreateProductCommand(ProductCreateDto Product) : IRequest<ProductDetailsDto?>;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDetailsDto?>
{
    public async Task<ProductDetailsDto?> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var userEntity = new User
        {
            Email = "ivan2@gmail.com",
            FirstName = "Ivan2",
            LastName = "Adamovic2"
        };
        //create user
        await userEntity.SaveAsync(cancellation: cancellationToken);
        
        
        var entity = request.Product.ToEntityFromCreateDto(userEntity, new One<User>(userEntity));
        //create product - upis u bazu
        await entity.SaveAsync(cancellation: cancellationToken);
        return entity.ToDto();
        //return "Created: " + request.Name + ", Description: " + request.Description + ", Price: " + request.Price;

    }
}