using DBStorage.Common;
using Domain.NewTrackingDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBStorage.NewTrackingDevice
{
    public class NewTrackingDeviceRepository : Repository<Domain.NewTrackingDevice.NewTrackingDevice>, INewTrackingDeviceRepository
    {
        public NewTrackingDeviceRepository(WingsContext context) : base(context)
        {

        }

        public IEnumerable<Domain.NewTrackingDevice.NewTrackingDevice> GetAllNewTrackingDevices()
        {
            throw new NotImplementedException();
        }

        public Domain.NewTrackingDevice.NewTrackingDevice GetTrackingDeviceById(int id)
        {
            return Retrieve(d => d.TrackingDeviceId == id).SingleOrDefault();
        }       

        //public void UpdateTrackingDevice(Domain.NewTrackingDevice.NewTrackingDevice NewTrackingDevice)
        //{
        //    Domain.NewTrackingDevice.NewTrackingDevice trackingDeviceFromdb = RetrieveByKey(NewTrackingDevice.TrackingDeviceId);
        //    if (trackingDeviceFromdb != null)
        //    {
        //        trackingDeviceFromdb.massage_type = NewTrackingDevice.massage_type;
        //        trackingDeviceFromdb.imei = NewTrackingDevice.imei;
        //        trackingDeviceFromdb.date = NewTrackingDevice.date;
        //        trackingDeviceFromdb.GPS_flag = NewTrackingDevice.GPS_flag;
        //        trackingDeviceFromdb.Latitude = NewTrackingDevice.Latitude;
        //        trackingDeviceFromdb.Latitude_hemisphere = NewTrackingDevice.Latitude_hemisphere;
        //        trackingDeviceFromdb.Longitude = NewTrackingDevice.Longitude;
        //        trackingDeviceFromdb.Longitude_hemisphere = NewTrackingDevice.Longitude_hemisphere;
        //        trackingDeviceFromdb.Ground_speed = NewTrackingDevice.Ground_speed;
        //        trackingDeviceFromdb.Vehicle_angal = NewTrackingDevice.Vehicle_angal;
        //        trackingDeviceFromdb.input_output = NewTrackingDevice.input_output;
        //        trackingDeviceFromdb.mileage_identify = NewTrackingDevice.mileage_identify;
        //        trackingDeviceFromdb.mileage = NewTrackingDevice.mileage;                
        //        Save(trackingDeviceFromdb);
        //    }
        //}
    }
}
