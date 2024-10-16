using MongoDB.Entities;
using USP.Domain.Entities;

namespace USP.Worker;

public class NotifyUserWorker : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            //var now = DateTime.Now;
            DoWorkAsync();
            await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
        }
    }

    private async Task DoWorkAsync()
    {
        var result = await DB.Find<User>().ExecuteAsync();
        foreach (var user in result)
        {
            Console.WriteLine(user.Email);
        }
    }
}