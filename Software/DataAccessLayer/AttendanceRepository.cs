using DataAccessLayer.Interfaces;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AttendanceRepository : IDisposable, IAttendanceRepository
    {
        ///<remarks>Karla Kulier</remarks
        private PMSModel Context { get; set; }
        private DbSet<Attendance> Attendances { get; set; }

        public AttendanceRepository(PMSModel context)
        {
            Context = context;
            Attendances = Context.Set<Attendance>();
        }
        ///<remarks>Karla Kulier</remarks
        public void AddAttendance(Attendance attendance) {
            Attendances.Add(attendance);
            Context.SaveChanges();
        }
        ///<remarks>Karla Kulier</remarks
        public List<Attendance> GetPastAttendanceForChild(int childId) {
            return Attendances.Where(a => a.Id_Child == childId).ToList();
        }
        public List<Attendance> GetAttendanceByDate(DateTime date) {
            return Attendances
                .Where(a => DbFunctions.TruncateTime(a.Date) == date.Date)
                .ToList();
        }

        ///<remarks>Karla Kulier</remarks
        public bool RemoveAttendance(int attendanceId) {
            try {
                var attendance = Attendances.Find(attendanceId);
                if (attendance != null) {
                    Attendances.Remove(attendance);
                    Context.SaveChanges();
                    return true;
                }
                return false;
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        ///<remarks>Karla Kulier</remarks
        public void UpdateAttendance(Attendance updatedAttendance) {
            var existingAttendance = Context.Attendances.FirstOrDefault(a => a.Id == updatedAttendance.Id);
            if (existingAttendance != null) {
                existingAttendance.Date = updatedAttendance.Date;
                existingAttendance.isPresent = updatedAttendance.isPresent;

                Context.SaveChanges();
            } else {
                throw new ArgumentException("Attendance record not found.");
            }
        }

        ///<remarks>Marta Kovač</remarks>
        public async Task<List<Attendance>> GetChildrenPerYear(int year)
        {
            var attendantChildren = await Context.Attendances
                .Where(x => x.Date.Value.Year == year && x.isPresent==true)
                .ToListAsync();

            return attendantChildren;
        }

        ///<remarks>Karla Kulier</remarks
        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
