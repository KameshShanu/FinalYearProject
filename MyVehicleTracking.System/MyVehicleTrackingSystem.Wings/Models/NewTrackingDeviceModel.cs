using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyVehicleTrackingSystem.Wings.Models
{
    public class NewTrackingDeviceModel
    {
        public int TrackingDeviceId
        {
            get;
            set;
        }

        public string device_Id
        {
            get;
            set;
        }

        public string massage_type
        {
            get;
            set;
        }

        public string imei
        {
            get;
            set;
        }

        public DateTime? date
        {
            get;
            set;
        }

        public string GPS_flag
        {
            get;
            set;
        }

        public double Latitude
        {
            get;
            set;
        }

        public string Latitude_hemisphere
        {
            get;
            set;
        }

        public double Longitude
        {
            get;
            set;
        }

        public string Longitude_hemisphere
        {
            get;
            set;
        }

        public double Ground_speed
        {
            get;
            set;
        }

        public double Vehicle_angal
        {
            get;
            set;
        }

        public string input_output
        {
            get;
            set;
        }

        public string mileage_identify
        {
            get;
            set;
        }

        public string mileage
        {
            get;
            set;
        }
    }
}