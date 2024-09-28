using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Entities;

namespace USP.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
    {
        var conn = configuration.GetSection("MongoDbConfiguration");
        
        Task.Run(async () =>
        {
            await DB.InitAsync(conn.GetSection("DbName").Value!, MongoClientSettings.FromConnectionString(conn.GetSection("DbString").Value));
        })
        .GetAwaiter()
        .GetResult();
        
        
        return service;
    }
}

