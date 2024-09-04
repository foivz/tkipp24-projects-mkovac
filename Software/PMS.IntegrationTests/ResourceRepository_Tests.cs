using DataAccessLayer;
using DataAccessLayer.Interfaces;
using EntityLayer;

namespace PMS.IntegrationTests
{
    public class ResourceRepository_Tests
    {
        private readonly PMSModel _dbContext;
        private readonly ResourceRepository _resourceRepository;

        public ResourceRepository_Tests()
        {
            _dbContext = new PMSModel(@"Server = localhost\SQLEXPRESS; Database = IntegrationTestDB; Trusted_Connection = True;");
            _resourceRepository = new ResourceRepository(_dbContext);
        }

        [Fact]
        public void AddnewResource_ResourceIsValid_NewResourceAddedToTheDatabase()
        {
            var resource = new Resource
            {
                Name = "Test",
                Amount = 1,
                Description = "Test"
            };

            _resourceRepository.AddnewResource(resource);

            var result = _dbContext.Resources.FirstOrDefault(r => r.Name == "Test");

            Assert.NotNull(result);
            Assert.Equal(1, result.Amount);

            _dbContext.Resources.Remove(result);
            _dbContext.SaveChanges();
        }

        [Fact]
        public void GetAllResource_SomeResourceExist_ReturnsListOfAllResourcet()
        {
            var first = new Resource { Name = "Test1", Amount = 1 };
            var second = new Resource { Name = "Test2", Amount = 2 };
            var third = new Resource { Name = "Test3", Amount = 3 };

            _resourceRepository.AddnewResource(first);
            _resourceRepository.AddnewResource(second);
            _resourceRepository.AddnewResource(third);

            var list = _resourceRepository.GetAllResources().ToList();

            Assert.NotNull(list);
            Assert.Contains(first, list);
            Assert.Contains(second, list);
            Assert.Contains(third, list);

            _dbContext.Resources.Remove(first);
            _dbContext.Resources.Remove(second);
            _dbContext.Resources.Remove(third);
            _dbContext.SaveChanges();
        }

        [Fact]
        public void RemoveResource_ResourceExists_ResourceIsRemovedFromDatabase()
        {
            var resourceToDelete = new Resource
            {
                Name = "Test",
                Amount = 1,
                Description = "Test"
            };

            _resourceRepository.AddnewResource(resourceToDelete);
            _resourceRepository.RemoveResoruce(resourceToDelete);

            var result = _dbContext.Resources.FirstOrDefault(r => r.Name == "Test");

            Assert.Null(result);
        }

        [Fact]
        public void UpdateResource_ValidValuesChanged_ResourceIsUpdated()
        {
            var existing = new Resource { Name = "Test", Amount = 2 };
            _resourceRepository.AddnewResource(existing);
            existing = _dbContext.Resources.FirstOrDefault(r => r.Name == "Test");
            var existingName = existing.Name;

            var updated = _dbContext.Resources.FirstOrDefault(r => r.Name == "Test");
            updated.Name = "Test Update";

            _resourceRepository.UpdateResource(updated);

            Assert.NotEqual(existingName, updated.Name);
            Assert.True(existing.Id == updated.Id);
            Assert.Equal(updated, _dbContext.Resources.FirstOrDefault(r => r.Name == "Test Update"));

            _dbContext.Resources.Remove(updated);
            _dbContext.SaveChanges();
        }

        [Fact]
        public void Dispose_Called_DisposesDbContext()
        {
            _resourceRepository.Dispose();

            Action action = () => _dbContext.Equipment.FirstOrDefault();
            Assert.Throws<InvalidOperationException>(action);
        }
    }
}
