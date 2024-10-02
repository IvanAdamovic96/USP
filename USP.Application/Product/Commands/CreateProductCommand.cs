using MediatR;
using MongoDB.Entities;
using USP.Application.Common.Dto;
using USP.Application.Common.Mappers;

namespace USP.Application.Product.Commands;

public record CreateProductCommand(ProductCreateDto Product) : IRequest<ProductDetailsDto?>;


public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDetailsDto?>
{
    public async Task<ProductDetailsDto?> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Product.FromCreateDtoToEntity();
        //create product - upis u bazu

        await entity.SaveAsync(cancellation: cancellationToken);
        
        return entity.ToDto();
        //return "Created: " + request.Name + ", Description: " + request.Description + ", Price: " + request.Price;

    }
}