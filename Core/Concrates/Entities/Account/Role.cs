using Microsoft.AspNet.Identity.EntityFramework;

namespace Core.Concrates.Entities.Account
{
    public class Role : IdentityRole
    {
        public string Description { get; set; }
    }
}
