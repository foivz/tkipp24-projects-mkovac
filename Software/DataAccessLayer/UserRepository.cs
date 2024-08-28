using DataAccessLayer.Interfaces;
using EntityLayer;
using ModelsLayer.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserRepository : IDisposable, IUserRepository
    {
        public PMSModel Context { get; set; }

        public DbSet<User> Users { get; set; }

        public UserRepository(PMSModel context)
        {
            Context = context;
            Users = Context.Set<User>();
        }
        ///<remarks> Karla Kulier</remarks>
        public void AddnewUser(User user) {
            if (user.Role != null && Context.Entry(user.Role).State == EntityState.Detached) {
                var existingRole = Context.Roles.Find(user.Role.Id);
                if (existingRole != null) {
                    user.Role = existingRole;  
                } else {
                    Context.Roles.Attach(user.Role); 
                }
            }
            Users.Add(user);
            Context.SaveChanges();

        }
        ///<remarks> Karla Kulier</remarks>
        public User GetUserByUsername(string username, string password)
        {
            var user = Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            return user;
        }

        public IQueryable<User> getAllUsers()
        {
            var query = from u in Users
                        select u;

            return query;
        }

        public IQueryable<string> getUserEmails()
        {
            var query = from u in Users
                        select u.Email;

            return query;
        }
        ///<remarks> Karla Kulier</remarks>    
        public bool DeleteUser(User user) {
            try {
                Users.Attach(user);
                Users.Remove(user);
                Context.SaveChanges();
                return true; 
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        ///<remarks> Karla Kulier</remarks
        public void UpdateUser(User user)
        {
            var existingUser = Context.Users.Find(user.Id); 
            if (existingUser != null) {          
                existingUser.Username = user.Username;
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Email = user.Email;
                existingUser.Password = user.Password;
                existingUser.Telephone = user.Telephone;
                existingUser.DateOfBirth=user.DateOfBirth;
                existingUser.Sex = user.Sex;
                existingUser.OIB = user.OIB;              
                if (existingUser.Id_role != user.Id_role) {
                    existingUser.Id_role = user.Id_role;
                }
                Context.SaveChanges();
            }
        }

        ///<remarks>Marta Kovač</remarks
        public async Task<ForgotPasswordModel> GetForgotPasswordModel(string email)
        {
            var entity = await Users.FirstOrDefaultAsync(x => x.Email == email);

            if(entity is null)
            {
                return null;
            }

            return new ForgotPasswordModel
            {
                FirstName = entity.FirstName,
                MailTo = entity.Email,
                Password = entity.Password,
            };
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}    


