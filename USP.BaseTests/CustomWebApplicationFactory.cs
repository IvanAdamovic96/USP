using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using MongoDB.Entities;

namespace USP.BaseTests;

public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    public CustomWebApplicationFactory()
    {
        
        Task.Run(async () =>
        {
            await DB.InitAsync("UspBazaTestiranje",
                MongoClientSettings.FromConnectionString(
                    "mongodb+srv://ivanadamovic21:pAzxV64OEpPFoRnW@cluster-usp.tc6wi.mongodb.net/?retryWrites=true&w=majority&appName=Cluster-usp"));
        })
        .GetAwaiter()
        .GetResult();
        
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.RemoveAll(typeof(IHostedService));
        });
    }
}