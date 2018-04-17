using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
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

        public string device_Id
        {
            get;
            set;
        }

        [DisplayName("Massage")]
        public string massage_type
        {
            get;
            set;
        }

        [DisplayName("imei")]
        public string imei
        {
            get;
            set;
        }

        [DisplayName("Date")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
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

        [DisplayName("Latitude")]
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

        [DisplayName("Longitude")]
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

        [DisplayName("Speed")]
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

        [DisplayName("Mileage")]
        public string mileage
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