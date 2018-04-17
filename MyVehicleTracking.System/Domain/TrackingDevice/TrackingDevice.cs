using Domin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.TrackingDevice
{
    public class TrackingDevice : BaseEntity
    {
        public int TrackingDeviceId
        {
            get;
            set;
        }

        public string DeviceId
        {
            get;
            set;
        }

        public string MassageType
        {
            get;
            set;
        }

        public char Imei
        {
            get;
            set;
        }

        public DateTime DeviceDate
        {
            get;
            set;
        }

        public string GPSflag
        {
            get;
            set;
        }

        public decimal Latitude
        {
            get;
            set;
        }

        public string LatitudeHemisphere
        {
            get;
            set;
        }

        public decimal Longitude    
        {
            get;
            set;
        }

        public string LongitudeHemisphere
        {
            get;
            set;
        }

        public decimal GroundSpeed
        {
            get;
            set;
        }

        public DateTime Time
        {
            get;
            set;
        }

        public decimal VehicleAngal
        {
            get;
            set;
        }

        public string InputOrOutput
        {
            get;
            set;
        }

        public string MileageIdentify
        {
            get;
            set;
        }

        public string Mileage
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }

        public bool IsAvailable
        {
            get;
            set;
        }

        public virtual Vehicles.Vehicle Vehicle
        {
            get;
            set;
        }

        public override bool IsTransient()
        {
            return TrackingDeviceId == 0;
        }
    }
}
