using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
