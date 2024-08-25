using DataAccessLayer;
using DataAccessLayer.Interfaces;
using EntityLayer;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicLayer
{
    public class ResourceService
    {
        private readonly IResourceRepository resourceRepository;
        public ResourceService(IEquipmentRepository equipmentRepository = null)
        {
            this.resourceRepository = resourceRepository ?? new ResourceRepository(new PMSModel());
        }

        /// <remarks>Marta Kovač</remarks>
        public List<Resource> GetAllResources()
        {
            return resourceRepository.GetAllResources().ToList();
        }

        /// <remarks>Marta Kovač</remarks>
        public void AddResource(Resource resource)
        {
            resourceRepository.AddnewResource(resource);
        }

        /// <remarks>Marta Kovač</remarks>
        public bool RemoveResource(Resource resource)
        {
            bool isDeleted = resourceRepository.RemoveResoruce(resource);
            return isDeleted;
        }

        /// <remarks>Marta Kovač</remarks>
        public void UpdateResource(Resource resource)
        {
            resourceRepository.UpdateResource(resource);
        }
    }
}
