using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceSheduler
{
    public class Lights : Device
    {
        public override void turnOff()
        {
            Console.WriteLine("Światła zostały wyłączone");
        }

        public override void turnOn()
        {
            Console.WriteLine("Włączam światła");
        }
    }
}
