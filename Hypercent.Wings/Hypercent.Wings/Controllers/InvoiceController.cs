using Application.Invoice;
using Hypercent.Wings.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hypercent.Wings.Controllers
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
            IEnumerable<InvoiceViewModel> invoiceModels = new Collection<InvoiceViewModel>();
            return View(invoiceModels);
        }
    }
}