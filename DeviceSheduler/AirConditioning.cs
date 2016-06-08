using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceSheduler
{
    public class AirConditioning : Device
    {
        public override void turnOn()
        {
            Console.WriteLine("Klimatyzacja pomieszczeń została uruchomiona");
        }
        public override void turnOff()
        {
            Console.WriteLine("Klimatyzacja pomieszczeń zakończyła pracę");
        }
    }
}
