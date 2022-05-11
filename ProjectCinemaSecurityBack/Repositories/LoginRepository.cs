using ProjectCinemaSecurityBack.Context;
using ProjectCinemaSecurityBack.Models;

namespace ProjectCinemaSecurityBack.Repositories
{
    public class LoginRepository
    {
        private readonly CinemaContext context;

        public LoginRepository(CinemaContext Context)
        {
            context = Context;
        }

        public LoginModel AddUser(LoginModel user)
        {
            this.context.LoginModel.Add(user);
            this.context.SaveChanges();
            return user;
        }

        public void DeleteUser(long id)
        {
            this.context.LoginModel.Remove(this.context.LoginModel.FirstOrDefault(u => u.Id == id));
        }

        public LoginModel GetUserById(long id)
        {
            LoginModel user = this.context.LoginModel.FirstOrDefault(u => u.Id == id);
            return user;
        }

        public LoginModel GetUserByNameAndPassword(string name, string password)
        {
            LoginModel user = this.context.LoginModel.FirstOrDefault(u => u.Username == name && u.Password == password);
            return user;
        }

        public IEnumerable<LoginModel> GetUsers()
        {
            return this.context.LoginModel.ToList();
        }

        public LoginModel UpdateUser(LoginModel user)
        {
            this.context.LoginModel.Update(user);
            this.context.SaveChanges();
            return user;
        }
    }
}
