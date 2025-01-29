using Microsoft.AspNetCore.Identity;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class RoleRepo : IRoleRepo
    {
        private readonly Context context;

        public RoleRepo(Context context)
        {
            this.context = context;
        }
        public void Add(IdentityRole identityRole)
        {
            context.Roles.Add(identityRole);
        }

        public void Delete(IdentityRole identityRole)
        {

            context.Roles.Remove(identityRole);
        }

        public IEnumerable<ApplicationUser> GetAllInRole(IdentityRole identityRole)
        {
            var userIds = context.UserRoles
                                 .Where(ur => ur.RoleId == identityRole.Id)
                                 .Select(ur => ur.UserId)
                                 .ToList();

            var usersInRole = context.Users
                                     .Where(u => userIds.Contains(u.Id))
                                     .ToList();

            return usersInRole;
        }


        public IEnumerable< IdentityRole> GetRoles()
        {
            return context.Roles.ToList();
        }

        public void Update(IdentityRole identityRole)
        { 
            context.Roles.Update(identityRole);
        }
        public void save() { context.SaveChanges(); }

        public IdentityRole GetRole(string roleName)
        {
            return context.Roles.FirstOrDefault(x => x.Name == roleName);
        }
    }
}
