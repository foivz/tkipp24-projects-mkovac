using EntityLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IAttendanceRepository
    {
        Task<List<Attendance>> GetChildrenPerYear(int year);
    }
}
