using Microsoft.Extensions.DependencyInjection;
using MongoDB.Entities;

namespace USP.BaseTests;

public class Base : IAsyncLifetime
{
    public readonly HttpClient AnonymousClient;
    public Base()
    {
        var factory = new CustomWebApplicationFactory<Program>();
        var scope = factory.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
        AnonymousClient = factory.CreateClient();

        
    }

    public Task InitializeAsync()
    {
        return Task.CompletedTask;
    }

    public async Task DisposeAsync()
    {
        await DB.Database("UspBazaTestiranje").Client.DropDatabaseAsync("UspBazaTestiranje");
    }
}