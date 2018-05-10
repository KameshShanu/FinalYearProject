using Domin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.NewTrackingDevice
{
    public interface INewTrackingDeviceRepository : IRepository<NewTrackingDevice>
    {
        IEnumerable<NewTrackingDevice> GetAllNewTrackingDevices();
        Domain.NewTrackingDevice.NewTrackingDevice GetTrackingDeviceById(int id);
    }
}
