using EntityLayer;
using System;
using System.Data.Entity;
using System.Linq;

namespace DataAccessLayer
{
    public class EquipmentRepository : IDisposable
    {
        private PMSModel Context { get; set; }

        private DbSet<Equipment> AllEquipment { get; set; }

        public EquipmentRepository(PMSModel context)
        {
            Context = context;
            AllEquipment = Context.Set<Equipment>();
        }

        ///<remarks>Marta Kovač</remarks
        public void AddnewEquipment(Equipment equipment)
        {
            AllEquipment.Add(equipment);
            Context.SaveChanges();
        }

        ///<remarks>Marta Kovač</remarks
        public IQueryable<Equipment> GetAllEquipment()
        {
            var query = from e in AllEquipment
                        select e;

            return query;
        }

        ///<remarks>Marta Kovač</remarks
        public bool RemoveEquipment(Equipment equipment)
        {
            try
            {
                AllEquipment.Attach(equipment);
                AllEquipment.Remove(equipment);
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
        public void UpdateEquipment(Equipment equipment)
        {
            var existing = Context.Equipment.FirstOrDefault(e => e.Id == equipment.Id);
            if (existing != null)
            {
                existing.Name = equipment.Name;
                existing.Amount = equipment.Amount;
                existing.Description = equipment.Description;
                Context.SaveChanges();
            }
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
