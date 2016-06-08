using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceSheduler
{
    public class ScheduleTurningOn : IScheduleTimeForDevices
    {
        public DateTime time { get; set; }
        public List<IObserveDevice> observers = new List<IObserveDevice>();
        public ScheduleTurningOn(DateTime time)
        {
            this.time = time;
        }
        public void addDeviceObservator(IObserveDevice device)
        {
            observers.Add(device);
        }
        public void removeDeviceObservator(IObserveDevice device)
        {
            observers.Remove(device);
        }
        public void sendCommandToDevice()
        {
            DeviceCommandEvent command = new DeviceCommandEvent();
            command.shouldTurnOn = true;
            foreach (IObserveDevice device in observers)
            {
                device.reactOnCommand(command);
            }
        }
    }
}
