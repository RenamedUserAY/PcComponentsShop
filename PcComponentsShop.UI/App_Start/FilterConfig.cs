using PcComponentsShop.UI.Controllers.Filters;
using System.Web.Mvc;

namespace PcComponentsShop.UI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute() { View="_Exception"});
            filters.Add(new ExceptionLogger(MvcApplication.AppErrorLogger));
        }
    }
}
