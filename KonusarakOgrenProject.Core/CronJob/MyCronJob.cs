using KonusarakOgrenProject.Business.Abstract;
using KonusarakOgrenProject.Core.CronJob.Schedule;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonusarakOgrenProject.Core.CronJob
{
    public class MyCronJob : CronJobService
    {
        private readonly ILogger<MyCronJob> _logger;

        public MyCronJob(IScheduleConfig<MyCronJob> config, ILogger<MyCronJob> logger) : base(config.CronExpression, config.TimeZoneInfo)
        {
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Articles taken from www.wired.com");
            return base.StartAsync(cancellationToken);
        }
    }
}
