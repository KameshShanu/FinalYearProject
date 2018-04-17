using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MyVehicleTracking.System.Models
{
    public class TrackingDeviceViewModel
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

        [DisplayName("Massage")]
        public string MassageType
        {
            get;
            set;
        }

        [DisplayName("imei")]
        public char Imei
        {
            get;
            set;
        }

        [DisplayName("Date")]
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

        [DisplayName("Latitude")]
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

        [DisplayName("Longitude")]
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

        [DisplayName("Speed")]
        public decimal GroundSpeed
        {
            get;
            set;
        }

        [DisplayName("Time")]
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

        [DisplayName("Mileage")]
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
    }
}