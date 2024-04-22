using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NCrontab;

namespace Forum.Workers.Bans
{
    public class BanWorker : BackgroundService
    {
        private readonly BanService _banService;
        private readonly CrontabSchedule _schedule;
        private DateTime _nextRun;

        public BanWorker(BanService banService, IConfiguration config)
        {
            _banService = banService;
            var cronExpression = config.GetValue<string>("Constants:BanWorkerCronExpression");
            _schedule = CrontabSchedule.Parse(cronExpression, new CrontabSchedule.ParseOptions { IncludingSeconds = true });
            _nextRun = _schedule.GetNextOccurrence(DateTime.UtcNow);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var now = DateTime.UtcNow;

                if (now > _nextRun)
                {
                    await DoWork(stoppingToken);
                    _nextRun = _schedule.GetNextOccurrence(DateTime.UtcNow);
                }
            }
        }

        private async Task DoWork(CancellationToken stoppingToken)
        {
            var users = await _banService.GetAllAsync(stoppingToken);

            var bannedUsers = users.Where(x => x.IsBanned).ToList();

            foreach (var user in bannedUsers)
            {
                if (user.BannedUntil <= DateTime.UtcNow)
                {
                    await _banService.UnbanUser(user.Id.ToString());
                }
            }
        }
    }
}
