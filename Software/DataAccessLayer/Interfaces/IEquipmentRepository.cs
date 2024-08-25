using EntityLayer;
using System.Linq;

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
