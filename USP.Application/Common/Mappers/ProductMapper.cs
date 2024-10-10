using MongoDB.Entities;
using Riok.Mapperly.Abstractions;
using USP.Application.Common.Dto;
using USP.Domain.Entities;
using USP.Domain.Enums;

namespace USP.Application.Common.Mappers;

[Mapper]
public static partial class ProductMapper
{
    public static async Task<ProductDetailsDto> ToDtoAsync(this Domain.Entities.Product entity)
    {
        var userDetails = await entity.ReferencedOneToOneUser.ToEntityAsync();
        var userDetailsDto = userDetails.ToDto();
        
        return new ProductDetailsDto(entity.Name, entity.Description, entity.Price, userDetailsDto,
            entity.ReferencedOneToManyUser.ToListDto(), entity.ReferencedManyToManyUser.ToListDto());
    }
    
    public static partial Domain.Entities.Product ToEntityCustom(this ProductCreateDto dto);

    
    public static Domain.Entities.Product ToEntityFromCreateDto(this ProductCreateDto dto, Domain.Entities.User user, One<Domain.Entities.User> referencedOneToOneUser)
    {
        var entity = new Domain.Entities.Product
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            Category = Category.FromValue(dto.Category),
            User = user,
            ReferencedOneToOneUser = referencedOneToOneUser
        };
        
        
        return entity;
    }
}

