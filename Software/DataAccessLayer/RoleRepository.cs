using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer {
    public class RoleRepository : IDisposable {

        public PMSModel Context { get; set; }

        public DbSet<Role> Roles { get; set; }

        public RoleRepository(PMSModel context) {
            Context = context;
            Roles = Context.Set<Role>();
        }
        public List<Role> GetRoles() {
            return Roles.ToList();
        }
        public Role GetRoleById(int id) {
            return Roles.Find(id);
        }
        public void Dispose() {
            Context.Dispose();
        }
    }
}
