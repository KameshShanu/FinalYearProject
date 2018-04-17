using DBStorage.Common;
using Domain.TrackingDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBStorage.TrackingDevice
{
    public class TrackingDeviceRepository : Repository<Domain.TrackingDevice.TrackingDevice>, ITrackingDeviceRepository
    {
        public TrackingDeviceRepository(WingsContext context) : base(context)
        {

        }

        public void DeleteMultipleTrackingDevices(IEnumerable<int> TrackingDeviceToDelete)
        {
            Context.TrackingDevice.Where(d => TrackingDeviceToDelete.Contains(d.TrackingDeviceId)).ToList().ForEach(
                 d =>
                 {
                     d.IsDeleted = true;
                 }
                 );
            Context.Commit();
        }

        public IEnumerable<Domain.TrackingDevice.TrackingDevice> GetAllTrackingDevices()
        {
            return Retrieve(d => d.IsDeleted == false);
        }

        public Domain.TrackingDevice.TrackingDevice GetTrackingDeviceById(int id)
        {
            return Retrieve(d => d.TrackingDeviceId == id).SingleOrDefault();
        }       

        public void SaveTrackingDevice(Domain.TrackingDevice.TrackingDevice trackingDevice)
        {
            Save(trackingDevice);
        }

        public void UpdateTrackingDevice(Domain.TrackingDevice.TrackingDevice TrackingDevice)
        {
            Domain.TrackingDevice.TrackingDevice trackingDeviceFromdb = RetrieveByKey(TrackingDevice.TrackingDeviceId);
            if (trackingDeviceFromdb != null)
            {
                trackingDeviceFromdb.massage_type = TrackingDevice.massage_type;
                trackingDeviceFromdb.imei = TrackingDevice.imei;
                trackingDeviceFromdb.date = TrackingDevice.date;
                trackingDeviceFromdb.GPS_flag = TrackingDevice.GPS_flag;
                trackingDeviceFromdb.Latitude = TrackingDevice.Latitude;
                trackingDeviceFromdb.Latitude_hemisphere = TrackingDevice.Latitude_hemisphere;
                trackingDeviceFromdb.Longitude = TrackingDevice.Longitude;
                trackingDeviceFromdb.Longitude_hemisphere = TrackingDevice.Longitude_hemisphere;
                trackingDeviceFromdb.Ground_speed = TrackingDevice.Ground_speed;
                trackingDeviceFromdb.Vehicle_angal = TrackingDevice.Vehicle_angal;
                trackingDeviceFromdb.input_output = TrackingDevice.input_output;
                trackingDeviceFromdb.mileage_identify = TrackingDevice.mileage_identify;
                trackingDeviceFromdb.mileage = TrackingDevice.mileage;
                trackingDeviceFromdb.IsAvailable = TrackingDevice.IsAvailable;
                Save(trackingDeviceFromdb);
            }
        }
    }
}
