using EntityLayer;
using System.Linq;

namespace DataAccessLayer.Interfaces
{
    public interface IResourceRepository
    {
        IQueryable<Resource> GetAllResources();
        void AddnewResource(Resource resource);
        bool RemoveResoruce(Resource resource);
        void UpdateResource(Resource resource);
    }
}
