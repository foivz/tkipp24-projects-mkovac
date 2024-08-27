using DataAccessLayer;
using DataAccessLayer.Interfaces;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class ChildService
    {

        private GroupRepository groupRepository;
        private ChildRepository childRepository;
        private readonly IChildRepository _childRepository;

        public ChildService(IChildRepository _childRepository = null)
        {
            groupRepository = new GroupRepository(new PMSModel());
            childRepository = new ChildRepository(new PMSModel());

            this._childRepository = _childRepository ?? new ChildRepository(new PMSModel());
        }

        //Vdran Đimoti
        public List<Child> getChildremFromGroup(Group group)
        {
            using (var repo = new ChildRepository(new PMSModel()))
            {
                return repo.GetChildremFromGroup(group).ToList();
            }
        }
        //Vdran Đimoti
        public List<Child> GetChildByLastName (string lastName)
        {
            using (var repo = new ChildRepository(new PMSModel()))
            {
                return repo.GetChildByLastName(lastName).ToList();
            }
        }

        ///<remarks>Karla Kulier</remarks
        public List<Child> GetAllChildren() {
            var child = _childRepository.GetAllChild().ToList();
            return child;
        }
        ///<remarks>Karla Kulier</remarks
        public void AddChild(Child child) {
            using (var repo = new ChildRepository(new PMSModel())) {
                repo.AddnewChild(child);
            }
        }

        //Karla Kulier
        public List<string> GetGroupNames() {
            using (var repo = new ChildRepository(new PMSModel())) {
                return repo.GetGroupNames();
            }
        }
        ///<remarks>Karla Kulier</remarks
        public bool DeleteChild(Child child) {
            using (var repo = new ChildRepository(new PMSModel())) {
                return repo.DeleteChild(child);
            }
        }
        ///<remarks>Karla Kulier</remarks
        public void UpdateChild(Child child, string groupName) {
            int? groupId = groupRepository.GetGroupIdByName(groupName);
            if (groupId.HasValue) {
                child.Id_Group = groupId.Value;
                childRepository.UpdateChild(child);
            } else {
                throw new Exception("Group not found.");
            }
        }
        //Karla Kulier
        public List<Child> getChildrenBySearch(string pattern)
        {
            using (var repo = new ChildRepository(new PMSModel()))
            {
                return repo.getChildBySearch(pattern).ToList();
            }
        }
    }
}
