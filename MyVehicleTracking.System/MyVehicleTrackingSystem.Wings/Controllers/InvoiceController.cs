using Application.Invoice;
using MyVehicleTrackingSystem.Wings.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;

namespace MyVehicleTrackingSystem.Wings.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            if (invoiceService == null)
            {
                throw new NullReferenceException("invoiceService");
            }
            _invoiceService = invoiceService;
        }

        // GET: Invoice
        public ActionResult Open()
        {
            IEnumerable<NewTrackingDeviceModel> newTrackingDeviceModel = new Collection<NewTrackingDeviceModel>();
            string markers = "[";
            string conString = ConfigurationManager.ConnectionStrings["WingsContext"].ConnectionString;
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 *  FROM NewTrackingDevice ORDER BY [TrackingDeviceId] DESC;");
            using (SqlConnection con = new SqlConnection(conString))
            {
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        markers += "{";
                        //markers += string.Format("'title': '{0}',", sdr["Name"]);
                        markers += string.Format("'lat': '{0}',", sdr["Latitude"]);
                        markers += string.Format("'lng': '{0}',", sdr["Longitude"]);
                        markers += string.Format("'Ground_speed': '{0}',", sdr["Ground_speed"]);
                        markers += string.Format("'Vehicle_angal': '{0}'", sdr["Vehicle_angal"]);
                        markers += "},";
                    }
                }
                con.Close();
            }

            markers += "];";
            ViewBag.Markers = markers;
            return View();
        }
    }
}