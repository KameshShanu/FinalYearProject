using Domin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.TrackingDevice
{
    public interface ITrackingDeviceRepository : IRepository<TrackingDevice>
    {
        IEnumerable<TrackingDevice> GetAllTrackingDevices();
        void DeleteMultipleTrackingDevices(IEnumerable<int> TrackingDeviceToDelete);
        void SaveTrackingDevice(TrackingDevice trackingDevice);
        void UpdateTrackingDevice(TrackingDevice TrackingDevice);
        Domain.TrackingDevice.TrackingDevice GetTrackingDeviceById(int id);
    }
}
