using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceSheduler
{
    public abstract class Device : IObserveDevice
    {
        public abstract void turnOn();
        public abstract void turnOff();
        public void reactOnCommand(DeviceCommandEvent command)
        {
            if(command.shouldTurnOn) turnOn();
            if(command.shouldTurnOff) turnOff();
        }
    }
}
