using Application.NewTrackingDevice;
using Domain.NewTrackingDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyVehicleTrackingSystem.Wings.Controllers
{
    public class HomeController : Controller
    {
        private readonly INewTrackingDeviceService _newTrackingDeviceService;
        
        public ActionResult Index()
        {
            return View();
        }

        public HomeController(NewTrackingDeviceService newTrackingDeviceService)
        {

        }

        public JsonResult GetAllLocation()
        {
            NewTrackingDevice newTrackingDevice = new NewTrackingDevice();
            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}