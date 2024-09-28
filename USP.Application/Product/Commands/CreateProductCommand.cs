using MediatR;
using MongoDB.Entities;

namespace USP.Application.Product.Commands;

public record CreateProductCommand(string Name, string Description, decimal Price) : IRequest<string>;


public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, string>
{
    public async Task<string> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        //create product - upis u bazu
        var entity = new Domain.Entities.Product();
        entity.Name = request.Name;
        entity.Description = request.Description;
        entity.Price = request.Price;

        entity.SaveAsync(cancellation: cancellationToken);
        
        
        
        return "Product created!";
        //return "Created: " + request.Name + ", Description: " + request.Description + ", Price: " + request.Price;

    }
}