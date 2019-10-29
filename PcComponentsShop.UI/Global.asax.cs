using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using PcComponentsShop.Infrastructure.Data.Contexts;
using PcComponentsShop.Infrastructure.Data.Units;
using NLog;

namespace PcComponentsShop.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static PcComponentsUnit PcComponentsUnit { get; } = new PcComponentsUnit();
        public static Logger AppErrorLogger { get; } = LogManager.GetLogger("ErrorLogger");
        public static Logger AppInfoLogger { get; } = LogManager.GetLogger("InfoLogger");
        protected void Application_Start()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<PcComponentsShopContext>());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
