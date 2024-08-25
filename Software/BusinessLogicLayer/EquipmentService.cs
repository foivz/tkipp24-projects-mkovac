using DataAccessLayer;
using DataAccessLayer.Interfaces;
using EntityLayer;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicLayer
{
    public class EquipmentService
    {
        private readonly IEquipmentRepository equipmentRepository;
        public EquipmentService(IEquipmentRepository equipmentRepository = null) {
            this.equipmentRepository = equipmentRepository ?? new EquipmentRepository(new PMSModel());
        }
        /// <remarks>Marta Kovač</remarks>
        public List<Equipment> GetAllEquipment()
        {
            return equipmentRepository.GetAllEquipment().ToList();
        }

        /// <remarks>Marta Kovač</remarks>
        public void AddEquipment(Equipment equipment)
        {
            equipmentRepository.AddnewEquipment(equipment);
        }

        /// <remarks>Marta Kovač</remarks>
        public bool RemoveEquipment(Equipment equipment)
        {
            bool isDeleted = equipmentRepository.RemoveEquipment(equipment);
            return isDeleted;
        }

        /// <remarks>Marta Kovač</remarks>
        public void UpdateEquipment(Equipment equipment)
        {
            equipmentRepository.UpdateEquipment(equipment);
        }
    }
}
