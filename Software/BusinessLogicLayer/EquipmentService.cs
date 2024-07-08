using DataAccessLayer;
using EntityLayer;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicLayer
{
    public class EquipmentService
    {
        /// <remarks>Marta Kovač</remarks>
        public List<Equipment> GetAllEquipment()
        {
            using (var repo = new EquipmentRepository(new PMSModel()))
            {
                return repo.GetAllEquipment().ToList();
            }
        }

        /// <remarks>Marta Kovač</remarks>
        public void AddEquipment(Equipment equipment)
        {
            using (var repo = new EquipmentRepository(new PMSModel()))
            {
                repo.AddnewEquipment(equipment);
            }
        }

        /// <remarks>Marta Kovač</remarks>
        public bool RemoveEquipment(Equipment equipment)
        {
            using (var repo = new EquipmentRepository(new PMSModel()))
            {
                bool isDeleted = repo.RemoveEquipment(equipment);
                return isDeleted;
            }
        }

        /// <remarks>Marta Kovač</remarks>
        public void UpdateEquipment(Equipment equipment)
        {
            using (var repo = new EquipmentRepository(new PMSModel()))
            {
                repo.UpdateEquipment(equipment);
            }
        }
    }
}
