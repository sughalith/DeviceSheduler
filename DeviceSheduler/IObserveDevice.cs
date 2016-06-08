using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceSheduler
{
    public interface IObserveDevice
    {
        void reactOnCommand(DeviceCommandEvent commandEvent);
    }
}
