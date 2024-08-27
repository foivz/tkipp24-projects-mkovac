using DataAccessLayer;
using ModelsLayer.Models;
using System.Collections.Generic;
using EntityLayer;
using System.Threading.Tasks;
using System;
using System.Linq;
using DataAccessLayer.Interfaces;
namespace BusinessLogicLayer
{
    public class StatisticsService
    {
        private readonly IAttendanceRepository attendanceRepository;
        private readonly IChildRepository childRepository;
        private readonly IGroupRepository groupRepository;
        public StatisticsService(IAttendanceRepository attendanceRepository = null, IChildRepository childRepository = null, IGroupRepository groupRepository = null)
        {
            this.attendanceRepository = attendanceRepository ?? new AttendanceRepository(new PMSModel());
            this.childRepository = childRepository ?? new ChildRepository(new PMSModel());
            this.groupRepository = groupRepository ?? new GroupRepository(new PMSModel());
        }

        public Dictionary<int, int> GroupDictionary()
        {
            var childrenPerGroup = new Dictionary<int, int>()
            {
                {0, 0}
            };

            return childrenPerGroup;
        }

        public Dictionary<Months, int> Default()
        {
            var monthValues = new Dictionary<Months, int>() {
                { Months.January, 0 },
                { Months.February, 0 },
                { Months.March, 0 },
                { Months.April, 0 },
                { Months.May, 0 },
                { Months.June, 0 },
                { Months.July, 0 },
                { Months.August, 0 },
                { Months.September, 0 },
                { Months.October, 0 },
                { Months.November, 0 },
                { Months.December, 0 }
            };

            return monthValues;
        }

        public async Task<Dictionary<Months, int>> AttendanceByMonths(int year)
        {
            var monthValues = new Dictionary<Months, int>() {
                { Months.January, 0 },
                { Months.February, 0 },
                { Months.March, 0 },
                { Months.April, 0 },
                { Months.May, 0 },
                { Months.June, 0 },
                { Months.July, 0 },
                { Months.August, 0 },
                { Months.September, 0 },
                { Months.October, 0 },
                { Months.November, 0 },
                { Months.December, 0 }
            };

            var children = new List<Attendance>();
            children = await attendanceRepository.GetChildrenPerYear(year);
            foreach (var child in children)
            {
                switch (child.Date.Value.Month)
                {
                    case (int)Months.January:
                        monthValues[Months.January]++;
                        break;
                    case (int)Months.February:
                        monthValues[Months.February]++;
                        break;
                    case (int)Months.March:
                        monthValues[Months.March]++;
                        break;
                    case (int)Months.April:
                        monthValues[Months.April]++;
                        break;
                    case (int)Months.May:
                        monthValues[Months.May]++;
                        break;
                    case (int)Months.June:
                        monthValues[Months.June]++;
                        break;
                    case (int)Months.July:
                        monthValues[Months.July]++;
                        break;
                    case (int)Months.August:
                        monthValues[Months.August]++;
                        break;
                    case (int)Months.September:
                        monthValues[Months.September]++;
                        break;
                    case (int)Months.October:
                        monthValues[Months.October]++;
                        break;
                    case (int)Months.November:
                        monthValues[Months.November]++;
                        break;
                    case (int)Months.December:
                        monthValues[Months.December]++;
                        break;
                }
            }
            return monthValues;
        }

        public List<int> Gender()
        {
            int male = 0;
            int female = 0;
            var children = new List<Child>();
            children = childRepository.GetAllChild().ToList();

            foreach (var child in children)
            {
                if (child.Sex == "m" || child.Sex == "M")
                {
                    male++;
                }
                else
                {
                    female++;
                }
            }

            var genderCounts = new List<int>
            {
                male,
                female
            };

            return genderCounts;
        }

        public async Task<Dictionary<int, int>> Group()
        {
            var childrenPerGroup = new Dictionary<int, int>();

            var groups = new List<Group>();
            groups = groupRepository.GetAllGroups().ToList();

            foreach (var group in groups)
            {
                var children = childRepository.GetChildremFromGroup(group);
                childrenPerGroup[group.Id] = children.Count();
            }

            return childrenPerGroup;
        }
    }
}