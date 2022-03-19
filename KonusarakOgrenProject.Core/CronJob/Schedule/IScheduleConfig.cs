using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonusarakOgrenProject.Core.CronJob.Schedule
{
    public interface IScheduleConfig<T>
    {
        public string CronExpression { get; set; }

        TimeZoneInfo TimeZoneInfo { get; set; }
    }
}
