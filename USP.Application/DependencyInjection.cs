using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using USP.Application.Common.Behaviours;

namespace USP.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        service.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        service.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        return service;
    }
}