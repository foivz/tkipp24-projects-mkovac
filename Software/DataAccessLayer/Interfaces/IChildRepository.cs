using EntityLayer;
using System.Linq;

namespace DataAccessLayer.Interfaces
{
    public interface IChildRepository
    {
        IQueryable<Child> GetAllChild();
        IQueryable<Child> GetChildremFromGroup(Group group);
    }
}
