using BusinessLogicLayer;
using DataAccessLayer.Interfaces;
using EntityLayer;
using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit.Sdk;

namespace PMS_UnitTests
{
    public class ResourceService_Tests
    {
        private readonly IResourceRepository _fakeRepository;
        private readonly ResourceService service;

        public ResourceService_Tests()
        {
            _fakeRepository = A.Fake<IResourceRepository>();
            service = new ResourceService(_fakeRepository);
        }

        [Fact]
        public void GetAllResources_WhenCalled_ReturnsAllResources()
        {

            var expectedResources = new List<Resource>
            {
                new Resource { Name = "Test1", Amount = 1, Description = "Test1"},
                new Resource { Name = "Test2", Amount = 2, Description = "Test2"},
                new Resource { Name = "Test3", Amount = 3, Description = "Test3"}
            };

            A.CallTo(() => _fakeRepository.GetAllResources()).Returns(expectedResources.AsQueryable());

            var result = service.GetAllResources().AsQueryable();

            Assert.Equal(expectedResources, result);
        }

        [Fact]
        public void AddResource_WhenCalled_AddsNewResource()
        {
            var resource = new Resource
            {
                Name = "Test",
                Amount = 1,
                Description = "Test"
            };

            service.AddResource(resource);

            A.CallTo(() => _fakeRepository.AddnewResource(resource)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void AddResource_WhenResourcetAmountIsNull_ThrowsException()
        {
            var resourceWithoutAmount = new Resource
            {
                Name = "Test",
                Amount = 0,
                Description = "Test"
            };

            Assert.Throws<ArgumentNullException>(() => service.AddResource(resourceWithoutAmount));
        }

        [Fact]
        public void AddResource_WhenResourcetNameIsEmpty_ThrowsException()
        {
            var resourceWithoutName = new Resource
            {
                Amount = 1,
                Description = "Test"
            };

            Assert.Throws<ArgumentException>(() => service.AddResource(resourceWithoutName));
        }

        [Fact]
        public void AddResource_WhenResourceNameIsWhiteSpacesOnly_ThrowsException()
        {
            var resourceWithoutName = new Resource
            {
                Name = "     ",
                Amount = 1,
                Description = "Test"
            };

            Assert.Throws<ArgumentException>(() => service.AddResource(resourceWithoutName));
        }

        [Fact]
        public void RemoveResource_WhenCalled_ResourceIsRemoved()
        {
            var resourceForDelete = new Resource
            {
                Id = 1,
                Name = "Test",
                Amount = 5,
                Description = "Test"
            };

            service.RemoveResource(resourceForDelete);

            A.CallTo(() => _fakeRepository.RemoveResoruce(resourceForDelete)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void UpdateResoure_WhenCalled_ResourceIsUpdated()
        {
            var resource = new Resource
            {
                Id = 1,
                Name = "Test1",
                Amount = 5,
                Description = "Test1"
            };

            service.UpdateResource(resource);

            A.CallTo(() => _fakeRepository.UpdateResource(resource)).MustHaveHappenedOnceExactly();
        }
    }
}
