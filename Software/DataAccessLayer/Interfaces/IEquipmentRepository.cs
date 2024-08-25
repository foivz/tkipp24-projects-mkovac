using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IEquipmentRepository
    {
        IQueryable<Equipment> GetAllEquipment();
        void AddnewEquipment(Equipment equipment);
        bool RemoveEquipment(Equipment equipment);
        void UpdateEquipment(Equipment equipment);
    }
}
