using DataAccessLayer;
using DataAccessLayer.Interfaces;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicLayer
{
    public class ResourceService
    {
        private readonly IResourceRepository resourceRepository;
        public ResourceService(IResourceRepository resourceRepository = null)
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
            ValidateResource(resource);
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
            ValidateResource(resource);
            resourceRepository.UpdateResource(resource);
        }

        private void ValidateResource(Resource resource)
        {
            if (string.IsNullOrWhiteSpace(resource.Name))
            {
                throw new ArgumentException("Name is required.");
            }

            if (resource.Amount == 0)
            {
                throw new ArgumentNullException(nameof(resource.Amount), "Amount cannot be null.");
            }
        }
    }
}
