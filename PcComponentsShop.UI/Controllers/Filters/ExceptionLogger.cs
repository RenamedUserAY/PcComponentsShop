using NLog;
using System.Web.Mvc;

namespace PcComponentsShop.UI.Controllers.Filters
{
    public class ExceptionLogger : FilterAttribute, IExceptionFilter
    {
        private readonly Logger Logger;
        public ExceptionLogger(Logger l)
        {
            Logger = l;
        }
        public void OnException(ExceptionContext filterContext)
        {
            Logger.Error(filterContext.Exception, $"An exception caused by: {filterContext.Exception.Source}\n" +
                $"Target Cite: {filterContext.Exception.TargetSite}\n" +
                $"User Name: {filterContext.HttpContext.User.Identity.Name}\n" +
                $"Request: {filterContext.HttpContext.Request.Url}\n" +
                $"Stack Trace\n{filterContext.Exception.StackTrace}\n" +
                $"Usefull link {filterContext.Exception.HelpLink}");
        }
    }
}