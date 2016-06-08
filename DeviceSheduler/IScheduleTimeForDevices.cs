using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceSheduler
{
    public interface IScheduleTimeForDevices
    {
        DateTime time { get; set; }
        void addDeviceObservator(IObserveDevice device);
        void removeDeviceObservator(IObserveDevice device);
        void sendCommandToDevice();
    }
}
