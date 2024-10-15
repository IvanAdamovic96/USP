using MongoDB.Entities;
using USP.Application.Common.Interfaces;
using USP.Application.Common.Mappers;
using USP.Domain.Entities;

namespace USP.Worker;

public class UpdateProductEmbeddedWorker(IProductService productService) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            //var now = DateTime.Now;
            DoWorkAsync();
            await Task.Delay(TimeSpan.FromSeconds(20), stoppingToken);
        }
    }

    private async Task DoWorkAsync()
    {
        await DB.Database<ProductEmbedded>().DropCollectionAsync(nameof(ProductEmbedded));

        var result = await productService.GetAllProductsAsync(new CancellationToken());
        
        foreach (var entity in result)
        {
            var entityProductEmbedded = await entity.ToEmbedded();

            await entityProductEmbedded.SaveAsync();
        }
    }
}