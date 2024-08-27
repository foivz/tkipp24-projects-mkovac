using EntityLayer;
using System.Linq;

namespace DataAccessLayer.Interfaces
{
    public interface IGroupRepository
    {
        IQueryable<Group> GetAllGroups();
    }
}
