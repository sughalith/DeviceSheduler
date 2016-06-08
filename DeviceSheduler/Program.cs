using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceSheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            Device lights = new Lights();
            Device airConditioning = new AirConditioning();
            Calendar calendar = new GregorianCalendar();
            int year, month, day, hour, minute;
            Console.WriteLine("Witaj w programie służącym do automatycznego włączania i wyłączania");
            Console.WriteLine("świateł oraz klimatyzacji.");
            Console.WriteLine("Aby program poprawnie działał musisz najpierw");
            Console.WriteLine("ustawić datę i godzinę kiedy chcesz włączyć urządzenia,");
            Console.WriteLine("a następnie podać datę i godzinę kiedy chcesz je wyłączyć.");
            Console.WriteLine("\nKrok numer 1");
            Console.WriteLine("Podaj pełną datę włączenia urządzeń");
            Console.Write("\nRok: ");
            year = int.Parse(Console.ReadLine());
            Console.Write("Miesiąc: ");
            month = int.Parse(Console.ReadLine());
            Console.Write("Dzień: ");
            day = int.Parse(Console.ReadLine());
            Console.Write("Godzina: ");
            hour = int.Parse(Console.ReadLine());
            Console.Write("Minuta: ");
            minute = int.Parse(Console.ReadLine());
            IScheduleTimeForDevices schedulerForAcOn = new ScheduleTurningOn(calendar.ToDateTime(year, month, day, hour, minute, 0, 0));
            IScheduleTimeForDevices schedulerForLightsOn = new ScheduleTurningOn(calendar.ToDateTime(year, month, day, hour, minute, 0, 0));
            Console.WriteLine("\nKrok numer 2");
            Console.WriteLine("Podaj pełną datę wyłączenia urządzeń");
            Console.Write("\nRok: ");
            year = int.Parse(Console.ReadLine());
            Console.Write("Miesiąc: ");
            month = int.Parse(Console.ReadLine());
            Console.Write("Dzień: ");
            day = int.Parse(Console.ReadLine());
            Console.Write("Godzina: ");
            hour = int.Parse(Console.ReadLine());
            Console.Write("Minuta: ");
            minute = int.Parse(Console.ReadLine());
            IScheduleTimeForDevices schedulerForAcOff = new ScheduleTurningOff(calendar.ToDateTime(year, month, day, hour, minute, 0, 0));
            IScheduleTimeForDevices schedulerForLightsOff = new ScheduleTurningOff(calendar.ToDateTime(year, month, day, hour, minute, 0, 0));

            schedulerForAcOn.addDeviceObservator(airConditioning);
            schedulerForLightsOn.addDeviceObservator(lights);

            schedulerForAcOff.addDeviceObservator(airConditioning);
            schedulerForLightsOff.addDeviceObservator(lights);

            SchedulerTask taskForAcOn = new SchedulerTask(schedulerForAcOn);
            SchedulerTask taskForLightOn = new SchedulerTask(schedulerForLightsOn);

            SchedulerTask taskForAcOff = new SchedulerTask(schedulerForAcOff);
            SchedulerTask taskForLightOff = new SchedulerTask(schedulerForLightsOff);

            taskForAcOn.Threads();
            taskForLightOn.Threads();

            taskForAcOff.Threads();
            taskForLightOff.Threads();

            Console.ReadKey();
        }
    }
}
