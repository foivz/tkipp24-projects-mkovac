using BusinessLogicLayer;
using DataAccessLayer.Interfaces;
using EntityLayer;
using FakeItEasy;
using ModelsLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMS_UnitTests
{
    public class StatisticsService_Tests
    {
        private readonly IAttendanceRepository fakeAttendanceRepository;
        private readonly IChildRepository fakeChildRepository;
        private readonly IGroupRepository fakeGroupRepository;
        private readonly StatisticsService fakeService;

        public StatisticsService_Tests()
        {
            fakeAttendanceRepository = A.Fake<IAttendanceRepository>();
            fakeChildRepository = A.Fake<IChildRepository>();
            fakeGroupRepository = A.Fake<IGroupRepository>();
            fakeService = new StatisticsService(fakeAttendanceRepository, fakeChildRepository, fakeGroupRepository);
        }

        [Fact]
        public void GroupDictionary_WhenCalled_ReturnsInitialDictionary()
        {
            var result = fakeService.GroupDictionary();

            Assert.NotNull(result);
            Assert.IsType<Dictionary<int, int>>(result);
            Assert.Single(result);
            Assert.True(result.ContainsKey(0) && result[0] == 0);
        }

        [Fact]
        public void Default_WhenCalled_ReturnsDictionaryWithAllMonthsWithValueZero()
        {
            var result = fakeService.Default();

            Assert.NotNull(result);
            Assert.IsType<Dictionary<Months, int>>(result);
            Assert.Equal(12, result.Count);

            foreach (Months month in Enum.GetValues(typeof(Months)))
            {
                Assert.True(result.ContainsKey(month));
                Assert.Equal(0, result[month]);
            }
        }

        [Fact]
        public async Task AttendanceByMonths_WhenCalled_ReturnsCorrectMonthValues()
        {
            int year = 2024;
            var attendanceList = new List<Attendance>
            {
                new Attendance { Date = new DateTime(year, 1, 10) },
                new Attendance { Date = new DateTime(year, 1, 20) },
                new Attendance { Date = new DateTime(year, 2, 5) },
                new Attendance { Date = new DateTime(year, 2, 25) },
                new Attendance { Date = new DateTime(year, 3, 15) },
                new Attendance { Date = new DateTime(year, 3, 22) },
                new Attendance { Date = new DateTime(year, 4, 8) },
                new Attendance { Date = new DateTime(year, 4, 18) },
                new Attendance { Date = new DateTime(year, 5, 12) },
                new Attendance { Date = new DateTime(year, 5, 25) },
                new Attendance { Date = new DateTime(year, 6, 3) },
                new Attendance { Date = new DateTime(year, 6, 30) },
                new Attendance { Date = new DateTime(year, 7, 7) },
                new Attendance { Date = new DateTime(year, 7, 21) },
                new Attendance { Date = new DateTime(year, 8, 14) },
                new Attendance { Date = new DateTime(year, 8, 29) },
                new Attendance { Date = new DateTime(year, 9, 4) },
                new Attendance { Date = new DateTime(year, 9, 19) },
                new Attendance { Date = new DateTime(year, 10, 10) },
                new Attendance { Date = new DateTime(year, 10, 25) },
                new Attendance { Date = new DateTime(year, 11, 5) },
                new Attendance { Date = new DateTime(year, 11, 15) },
                new Attendance { Date = new DateTime(year, 12, 12) }
            };

            A.CallTo(() => fakeAttendanceRepository.GetChildrenPerYear(year)).Returns(Task.FromResult(attendanceList));

            var result = await fakeService.AttendanceByMonths(year);

            Assert.NotNull(result);
            Assert.IsType<Dictionary<Months, int>>(result);
            Assert.Equal(23, result.Values.Sum());

            Assert.Equal(2, result[Months.January]);
            Assert.Equal(2, result[Months.February]);
            Assert.Equal(2, result[Months.March]);
            Assert.Equal(2, result[Months.April]);
            Assert.Equal(2, result[Months.May]);
            Assert.Equal(2, result[Months.June]);
            Assert.Equal(2, result[Months.July]);
            Assert.Equal(2, result[Months.August]);
            Assert.Equal(2, result[Months.September]);
            Assert.Equal(2, result[Months.October]);
            Assert.Equal(2, result[Months.November]);
            Assert.Equal(1, result[Months.December]);
        }

        [Fact]
        public void Gender_WhenCalled_ReturnsCorrectGenderCount()
        {
            var children = new List<Child>
            {
                new Child { Sex = "m" },
                new Child { Sex = "M" },
                new Child { Sex = "f" },
                new Child { Sex = "F" },
                new Child { Sex = "m" }
            };

            A.CallTo(() => fakeChildRepository.GetAllChild()).Returns(children.AsQueryable());

            var result = fakeService.Gender();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal(3, result[0]);
            Assert.Equal(2, result[1]);
        }

        [Fact]
        public async Task Group_WhenCalled_ReturnsCorrectChildChildrenPerGroup()
        {
            var groups = new List<Group>
            {
                new Group { Id = 1, Name = "Group 1" },
                new Group { Id = 2, Name = "Group 2" }
            };

            var childrenInGroup1 = new List<Child>
            {
                new Child { Id = 1, FirstName = "Child 1", Id_Group = 1},
                new Child { Id = 2, FirstName = "Child 2", Id_Group = 1 }
            };

            var childrenInGroup2 = new List<Child>
            {
                new Child { Id = 3, FirstName = "Child 3", Id_Group = 2 }
            };

            A.CallTo(() => fakeGroupRepository.GetAllGroups()).Returns(groups.AsQueryable());
            A.CallTo(() => fakeChildRepository.GetChildremFromGroup(groups[0])).Returns(childrenInGroup1.AsQueryable());
            A.CallTo(() => fakeChildRepository.GetChildremFromGroup(groups[1])).Returns(childrenInGroup2.AsQueryable());

            var result = await fakeService.Group();

            Assert.NotNull(result);
            Assert.IsType<Dictionary<int, int>>(result);

            Assert.Equal(2, result[1]);
            Assert.Equal(1, result[2]);
        }

    }
}
