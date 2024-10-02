using Riok.Mapperly.Abstractions;
using USP.Application.Common.Dto;

namespace USP.Application.Common.Mappers;

[Mapper]
public static partial class ProductMapper
{
    public static partial ProductDetailsDto ToDto(this Domain.Entities.Product product);
    
    public static partial Domain.Entities.Product FromCreateDtoToEntity(this ProductCreateDto dto);
    
    
}

