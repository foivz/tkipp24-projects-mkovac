using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ResourceRepository : IDisposable
    {
        private PMSModel Context { get; set; }

        private DbSet<Resource> AllResources { get; set; }

        public ResourceRepository(PMSModel context)
        {
            Context = context;
            AllResources = Context.Set<Resource>();
        }

        ///<remarks>Marta Kovač</remarks
        public void AddnewResource(Resource resource)
        {
            AllResources.Add(resource);
            Context.SaveChanges();
        }

        ///<remarks>Marta Kovač</remarks
        public IQueryable<Resource> GetAllResources()
        {
            var resources = AllResources.Select(x => x);

            return resources;
        }

        ///<remarks>Marta Kovač</remarks
        public bool RemoveResoruce(Resource resource)
        {
            try
            {
                AllResources.Attach(resource);
                AllResources.Remove(resource);
                Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        ///<remarks>Marta Kovač</remarks
        public void UpdateResource(Resource resource)
        {
            var existing = Context.Resources.FirstOrDefault(r => r.Id == resource.Id);
            if (existing != null)
            {
                existing.Name = resource.Name;
                existing.Amount = resource.Amount;
                existing.Description = resource.Description;
                Context.SaveChanges();
            }
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
