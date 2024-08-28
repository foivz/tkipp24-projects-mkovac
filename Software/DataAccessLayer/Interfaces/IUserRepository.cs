using ModelsLayer.Base;
using ModelsLayer.Models;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IUserRepository
    {
        Task<ForgotPasswordModel> GetForgotPasswordModel(string email);
    }
}
