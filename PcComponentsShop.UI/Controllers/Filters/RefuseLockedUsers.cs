using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PcComponentsShop.Infrastructure.Data.RegistrationSystemManagment;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;
using System.Web.Security;

namespace PcComponentsShop.UI.Controllers.Filters
{
    public class RefuseLockedUsers : FilterAttribute, IAuthenticationFilter
    {

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {

        }

        public void OnAuthentication(AuthenticationContext filterContext)
        { 
            if (filterContext.HttpContext.Request.IsAuthenticated && Roles.IsUserInRole("Users") && filterContext.HttpContext.GetOwinContext().GetUserManager<AppUserManager>().IsLockedOut(filterContext.HttpContext.User.Identity.GetUserId()))
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary {
                    {"action",  "BlockInformation"},
                    {"controller", "Account"},
                    {"userId", filterContext.HttpContext.User.Identity.GetUserId() }
                });
        }
    }
}