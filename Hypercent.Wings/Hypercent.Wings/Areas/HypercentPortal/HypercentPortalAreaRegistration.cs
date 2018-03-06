using System.Web.Mvc;

namespace Hypercent.Wings.Areas.HypercentPortal
{
    public class HypercentPortalAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "HypercentPortal";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "HypercentPortal_default",
                "HypercentPortal/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Hypercent.Wings.Areas.HypercentPortal.Controllers" }
            );
        }
    }
}