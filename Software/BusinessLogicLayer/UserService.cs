using DataAccessLayer;
using EntityLayer;
using Microsoft.Win32;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ModelsLayer.Models;
using ModelsLayer.Base;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer
{
    public class UserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository = null) { 
            this.userRepository = userRepository ?? new UserRepository(new PMSModel());
        }

        ///<remarks>Karla Kulier</remarks
        public List<User> getUsers()
        {
            using (var repo = new UserRepository(new PMSModel()))
            {
                return repo.getAllUsers().ToList();
            }
        }
        ///<remarks>Karla Kulier</remarks
        public void AddUser(User user)
        {
            using (var repo = new UserRepository(new PMSModel()))
            {
                repo.AddnewUser(user);
            }
        }

        ///<remarks> Karla Kulier</remarks>
        public User ValidateUser(string username, string password)
        {
            using (var repo = new UserRepository(new PMSModel()))
            {
                var user = repo.GetUserByUsername(username, password);

                return user;
            }
        }
        ///<remarks> Karla Kulier</remarks>
        public List<User> GetUsers()
        {
            using (var repo = new UserRepository(new PMSModel()))
            {

                var users = repo.getAllUsers().ToList();
                return users;
            }
        }
        ///<remarks> Karla Kulier</remarks>

        public bool DeleteUser(User user)
        {
            using (var repo = new UserRepository(new PMSModel()))
            {
                bool isDeleted = repo.DeleteUser(user);
                return isDeleted;
            }
        }
        ///<remarks> Karla Kulier</remarks>
        public void UpdateUser(User user)
        {
            using (var repo = new UserRepository(new PMSModel()))
            {
                repo.UpdateUser(user);
            }
        }

        /// <remarks>Marta Kovač</remarks>
        public async Task<GenericResponse> ForgotPassword(string email)
        {
            var model = await userRepository.GetForgotPasswordModel(email);
            var response = new GenericResponse();

            Boolean endsWithGmail = email.EndsWith("@gmail.com");

            if(!endsWithGmail)
            {
                response.Success = false;
                response.Message = $"The invalid email." +
                    "Please provide a valid email address ending with '@gmail.com'.";
                return response;
            }

            if (model is null)
            {
                response.Success = false;
                response.Message = $"There is no account registered with the provided email address." +
                    "Please verify the email address and try again.";
                return response;
            }

            string subject = "[TheSnackAlchemist] Your required password is here!";
            string body = $"Hi {model.FirstName}, <br/><br/>" +
                $"here is your password: <b>{model.Password}</b><br/><br/>" +
                $"If you did not send this request, please ignore this email!<br/><br/>" +
                $"Best Regards,<br/>" +
                $"The Snack Alchemist Team";

            try
            {
                new EmailService(subject, body, model.MailTo);
                response.Success = true;
                response.Message = $"Your password has been sent successfully to inserted email: {model.MailTo}.";
                return response;
            }
            catch
            {
                response.Success = false;
                response.Message = "Error occured. Failed to send an email.";
                return response;
            }
        }
    }
}


