namespace Inventory_Tracker_Project.Services.Background
{
    public class PriceCheckerService : BackgroundService
    {
        private readonly ILogger<PriceCheckerService> _logger;

        public PriceCheckerService(ILogger<PriceCheckerService> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Checking recent prices...");

                await Task.Delay(TimeSpan.FromMinutes(10), stoppingToken);
            }
        }
    }
}
