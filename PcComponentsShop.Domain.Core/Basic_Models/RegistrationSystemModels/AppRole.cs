using Microsoft.AspNet.Identity.EntityFramework;

namespace PcComponentsShop.Domain.Core.Basic_Models.RegistrationSystemModels
{
    public class AppRole : IdentityRole
    {
        public AppRole() : base() { }

        public AppRole(string name)
            : base(name)
        { }
    }
}
