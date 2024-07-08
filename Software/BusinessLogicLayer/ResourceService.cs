using DataAccessLayer;
using EntityLayer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class ResourceService
    {
        /// <remarks>Marta Kovač</remarks>
        public List<Resource> GetAllResources()
        {
            using (var repo = new ResourceRepository(new PMSModel()))
            {
                return repo.GetAllResources().ToList();
            }
        }

        /// <remarks>Marta Kovač</remarks>
        public void AddResource(Resource resource)
        {
            using (var repo = new ResourceRepository(new PMSModel()))
            {
                repo.AddnewResource(resource);
            }
        }

        /// <remarks>Marta Kovač</remarks>
        public bool RemoveResource(Resource resource)
        {
            using (var repo = new ResourceRepository(new PMSModel()))
            {
                bool isDeleted = repo.RemoveResoruce(resource);
                return isDeleted;
            }
        }

        /// <remarks>Marta Kovač</remarks>
        public void UpdateResource(Resource resource)
        {
            using (var repo = new ResourceRepository(new PMSModel()))
            {
                repo.UpdateResource(resource);
            }
        }
    }
}
