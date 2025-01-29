using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly Context context;

        public UserRepo(Context context)
        {
            this.context = context;
        }

        public void delete(ApplicationUser applicationUser)
        {
            context.Remove(applicationUser);
        }

        public string GetNameById(string userid)
        {
            return context.Users.FirstOrDefault(x=>userid==x.Id).fullname;
        }

        public ApplicationUser GetByName(string name)
        {
            return context.Users.FirstOrDefault(x => x.UserName == name);
        }

        //public ApplicationUser GetUser(int id)
        //{
        //    return context.Users.FirstOrDefault(x => x.physicalID == id);
        //}

        public void save()
        {
            context.SaveChanges();
        }

        public ApplicationUser GetByEmail(string Email)
        {
            return context.Users.FirstOrDefault(x=>Email.ToUpper()==x.NormalizedEmail);
        }
        public void update(ApplicationUser applicationUser)
        {
            context.Update(applicationUser);
        }

        public ApplicationUser GetUser(string id)
        {
            return context.Users.FirstOrDefault(x => id == x.Id);
        }
    }
}
