using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer {
    public class RoleService {

        public List<Role> GetRoles() {
            using (var repo = new RoleRepository(new PMSModel())) {
                return repo.GetRoles().ToList();
            }
        }
        public Role GetRoleById(int roleId) {
            using (var repo = new RoleRepository(new PMSModel())) {
                return repo.GetRoleById(roleId);
            }
        }
    }
}
