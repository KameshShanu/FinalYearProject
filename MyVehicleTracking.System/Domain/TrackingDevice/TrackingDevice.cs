﻿using Domin.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
