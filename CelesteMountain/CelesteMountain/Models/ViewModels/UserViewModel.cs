using Microsoft.AspNetCore.Identity;

namespace CelesteMountain.Models
{
    public class UserViewModel
    {
        public IEnumerable<AppUser> Users { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}
