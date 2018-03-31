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
                trackingDeviceFromdb.MassageType = TrackingDevice.MassageType;
                trackingDeviceFromdb.Imei = TrackingDevice.Imei;
                trackingDeviceFromdb.DeviceDate = TrackingDevice.DeviceDate;
                trackingDeviceFromdb.GPSflag = TrackingDevice.GPSflag;
                trackingDeviceFromdb.Latitude = TrackingDevice.Latitude;
                trackingDeviceFromdb.LatitudeHemisphere = TrackingDevice.LatitudeHemisphere;
                trackingDeviceFromdb.Longitude = TrackingDevice.Longitude;
                trackingDeviceFromdb.LongitudeHemisphere = TrackingDevice.LongitudeHemisphere;
                trackingDeviceFromdb.GroundSpeed = TrackingDevice.GroundSpeed;
                trackingDeviceFromdb.Time = TrackingDevice.Time;
                trackingDeviceFromdb.VehicleAngal = TrackingDevice.VehicleAngal;
                trackingDeviceFromdb.InputOrOutput = TrackingDevice.InputOrOutput;
                trackingDeviceFromdb.MileageIdentify = TrackingDevice.MileageIdentify;
                trackingDeviceFromdb.Mileage = TrackingDevice.Mileage;
                trackingDeviceFromdb.IsAvailable = TrackingDevice.IsAvailable;
                Save(trackingDeviceFromdb);
            }
        }
    }
}
