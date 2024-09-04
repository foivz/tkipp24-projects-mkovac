using BusinessLogicLayer;
using DataAccessLayer.Interfaces;
using EntityLayer;
using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PMS_UnitTests
{
    public class EquipmentService_Tests
    {
        private readonly IEquipmentRepository _fakeRepository;
        private readonly EquipmentService service;

        public EquipmentService_Tests()
        { 
            _fakeRepository = A.Fake<IEquipmentRepository>();
            service = new EquipmentService(_fakeRepository);
        }

        [Fact]
        public void GetAllEquipment_WhenCalled_ReturnsAllEquipment()
        {
            var list = new List<Equipment>
            {
                new Equipment { Name = "Test1", Amount = 1, Description = "Test1"},
                new Equipment { Name = "Test2", Amount = 2, Description = "Test2"},
                new Equipment { Name = "Test3", Amount = 3, Description = "Test3"}
            };

            A.CallTo(() => _fakeRepository.GetAllEquipment()).Returns(list.AsQueryable());

            var result = service.GetAllEquipment().AsQueryable();

            Assert.Equal(list, result);
        }

        [Fact]
        public void AddEquipment_WhenCalled_AddsNewEquipment()
        {
            var equipment = new Equipment {
                Name = "Test",
                Amount = 1,
                Description = "Test"
            };

            service.AddEquipment(equipment);

            A.CallTo(() => _fakeRepository.AddnewEquipment(equipment)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void AddEquipment_WhenEquipmentAmountIsNull_ThrowsException()
        {
            var equipmentWithoutAmount = new Equipment
            {
                Name = "Test",
                Description = "Test"
            };

            Assert.Throws<ArgumentNullException>(() => service.AddEquipment(equipmentWithoutAmount));
        }

        [Fact]
        public void AddEquipment_WhenEquipmentNameIsEmpty_ThrowsException()
        {
            var equipmentWithoutName = new Equipment
            {
                Amount = 1,
                Description = "Test"
            };

            Assert.Throws<ArgumentException>(() => service.AddEquipment(equipmentWithoutName));
        }

        [Fact]
        public void AddEquipment_WhenEquipmentNameIsWhiteSpacesOnly_ThrowsException()
        {
            var equipmentWithoutName = new Equipment
            {
                Name = "     ",
                Amount = 1,
                Description = "Test"
            };

            Assert.Throws<ArgumentException>(() => service.AddEquipment(equipmentWithoutName));
        }

        [Fact]
        public void RemoveEquipment_WhenCalled_EquipmentIsRemoved()
        {
            var equipmentForDelete = new Equipment
            {
                Id = 1,
                Name = "Test",
                Amount = 5,
                Description = "Test"
            };

            service.RemoveEquipment(equipmentForDelete);

            A.CallTo(() => _fakeRepository.RemoveEquipment(equipmentForDelete)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void UpdateEquipment_WhenCalled_EquipemntIsUpdated()
        {
            var equipment = new Equipment
            {
                Id = 1,
                Name = "Test1",
                Amount = 5,
                Description = "Test1"
            };

            service.UpdateEquipment(equipment);

            A.CallTo(() => _fakeRepository.UpdateEquipment(equipment)).MustHaveHappenedOnceExactly();
        }
    }
}
