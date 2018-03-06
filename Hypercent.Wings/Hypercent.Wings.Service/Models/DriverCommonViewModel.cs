﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hypercent.Wings.Models
{
    public class DriverCommonViewModel
    {
        public IEnumerable<DriverViewModel> DriverAvailableList { get; set; }
        public IEnumerable<DriverViewModel> DriverUnAvailableList { get; set; }
    }
}