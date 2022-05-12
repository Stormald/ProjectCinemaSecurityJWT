using ProjectCinemaSecurityBack.Context;
using ProjectCinemaSecurityBack.Models;
using System.Net.Mail;

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

            Email emailCreationCompte = new Email();
            emailCreationCompte.SendMail(user, "Votre compte "+user.Username+" a bien été créé");

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

    public class Email
    {
        private SmtpClient smtpClient;
        public Email()
        {
            smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new System.Net.NetworkCredential("arknightv1@gmail.com", "DetectiveC0nan?4869");
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
        }
        public void SendMail(LoginModel model, string message)
        {
            MailMessage mail = new MailMessage();

            //Expéditeur
            mail.From = new MailAddress("arknightv1@gmail.com", "Mon site Internet - Cinema");
            //Destinataire
            mail.To.Add(new MailAddress(model.Username));

            mail.Subject = "Confirmation création compte";
            mail.Body = message;

            smtpClient.Send(mail);
        }
    }
}
