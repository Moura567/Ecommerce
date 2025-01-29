using Microsoft.AspNetCore.Identity;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface IRoleRepo
    {

        public void Add(IdentityRole identityRole);
        public void Delete(IdentityRole identityRole);
        public void Update(IdentityRole identityRole);
        public IEnumerable< ApplicationUser> GetAllInRole(IdentityRole identityRole);
        public IEnumerable<IdentityRole> GetRoles();
        public IdentityRole GetRole(string roleName);
        public void save();
    }
}
