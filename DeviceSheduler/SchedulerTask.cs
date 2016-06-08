using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeviceSheduler
{
    public class SchedulerTask
    {
        private IScheduleTimeForDevices scheduler;
        public SchedulerTask(IScheduleTimeForDevices scheduler)
        {
            this.scheduler = scheduler;
        }
        public void Threads()
        {
            Thread newThread = new Thread(Run);
            newThread.Start();
        }
        public void Run()
        {
            Calendar calendar = new GregorianCalendar();
            DateTime now;
            while (true)
            {
                now = DateTime.Now;
                if (scheduler.time <= now)
                {
                    scheduler.sendCommandToDevice();
                    calendar.ToDateTime(scheduler.time.Year, scheduler.time.Month, scheduler.time.Day,
                    scheduler.time.Hour, scheduler.time.Minute, scheduler.time.Second, scheduler.time.Millisecond);
                    scheduler.time = now.AddDays(1);
                }
                try
                {
                    Thread.Sleep(1000);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }

        }
    }
}
