using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace USP.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        //serviceCollection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        service.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return service;
    }
}