using DataAccessLayer.Interfaces;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ChildRepository : IDisposable, IChildRepository
    {
        private PMSModel Context;
        private DbSet<Child> Children;

        public ChildRepository(PMSModel context)
        {
            Context = context;
            Children = Context.Set<Child>();
        }


        ///<remarks>Karla Kulier</remarks
        public IQueryable<Child> GetAllChild()
    {
        var query = from c in Children select c;
        return query;
    }
        ///<remarks>Karla Kulier</remarks
        public void AddnewChild(Child child) {

        Children.Add(child);
        Context.SaveChanges();

    }

        //Karla Kulier
    public List<string> GetGroupNames() {
        try {
            return Context.Groups.Select(c => c.Name).Distinct().ToList();
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
            return new List<string>();
        }
    }
        ///<remarks>Karla Kulier</remarks
        public bool DeleteChild(Child child) {
        try {
            Context.Children.Attach(child);
            Context.Children.Remove(child);
            Context.SaveChanges();
            return true;
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
        ///<remarks>Karla Kulier</remarks
        public void UpdateChild(Child child) {
        var existingChild = Context.Children.FirstOrDefault(c => c.Id == child.Id);
        if (existingChild != null) {
            existingChild.OIB = child.OIB;
            existingChild.FirstName = child.FirstName;
            existingChild.Id_Group = child.Id_Group;
            existingChild.LastName = child.LastName;
            existingChild.DateOfBirth = child.DateOfBirth;
            existingChild.Sex = child.Sex;
            existingChild.Adress = child.Adress;
            existingChild.Nationality = child.Nationality;
            existingChild.DevelopmentStatus = child.DevelopmentStatus;
            existingChild.MedicalInformation = child.MedicalInformation;
            existingChild.BirthPlace = child.BirthPlace;
            Context.SaveChanges();
        }
    }

        public IQueryable<Child> GetChildremFromGroup(Group group)
    {
        var queri = from c in Children where (c.Id_Group == @group.Id) select c;
        return queri;
    }

    public IQueryable<Child> GetChildByLastName(string lastname)
    {
        var queri = from c in Children where c.LastName.Contains(lastname) select c;
        return queri;
    }

    public IQueryable<Child> getChildBySearch(string pattern)
    {
        var query = from c in Children
                    where c.FirstName.Contains(pattern) || c.LastName.Contains(pattern)
                    select c;

        return query;
    }




    public void Dispose()
    {
        Context.Dispose();
    }
}
}
