using USP.Domain.Enums;

namespace USP.Domain.Extensions;

public class EnumExtensions
{
    public static readonly string ValidReportTypeList =
        string.Join(", ", Category.List.Select(x => x.Name + "-" + x.Value));
    
    
}