using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface IUserRepo
    {
        void update(ApplicationUser applicationUser);
        ApplicationUser GetByName(string name);
        ApplicationUser GetByEmail(string Email);

        ApplicationUser GetUser(string id);
        public string GetNameById(string userid);
        void delete(ApplicationUser applicationUser);

        void save();
    }
}
