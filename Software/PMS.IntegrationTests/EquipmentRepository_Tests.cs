using DataAccessLayer;
using EntityLayer;
using System.Collections.Generic;
using System.Data.Entity;

namespace PMS.IntegrationTests;

public class EquipmentRepository_Tests
{
    private readonly PMSModel _dbContext;
    private readonly EquipmentRepository _equipmentRepository;

    public EquipmentRepository_Tests()
    {
        _dbContext = new PMSModel(@"Server = localhost\SQLEXPRESS; Database = IntegrationTestDB; Trusted_Connection = True;");
        _equipmentRepository = new EquipmentRepository(_dbContext);
    }

    [Fact]
    public void AddnewEquipment_EquipmentIsValid_NewEquipmentAddedToTheDatabase()
    {
        var equipment = new Equipment
        {
            Name = "Test",
            Amount = 1,
            Description = "Test"
        };

        _equipmentRepository.AddnewEquipment(equipment);

        var result = _dbContext.Equipment.FirstOrDefault(e => e.Name == "Test");

        Assert.NotNull(result);
        Assert.Equal(1, result.Amount);

        _dbContext.Equipment.Remove(result);
        _dbContext.SaveChanges();
    }

    [Fact]
    public void GetAllEquipment_SomeEquipmentExist_ReturnsListOfAllEquipmentt()
    {
        var first = new Equipment { Name = "Test1", Amount = 1 };
        var second = new Equipment { Name = "Test2", Amount = 2 };
        var third = new Equipment { Name = "Test3", Amount = 3 };

        _equipmentRepository.AddnewEquipment(first);
        _equipmentRepository.AddnewEquipment(second);
        _equipmentRepository.AddnewEquipment(third);

        var list = _equipmentRepository.GetAllEquipment().ToList();

        Assert.NotNull(list);
        Assert.Contains(first, list);
        Assert.Contains(second, list);
        Assert.Contains(third, list);

        _dbContext.Equipment.Remove(first);
        _dbContext.Equipment.Remove(second);
        _dbContext.Equipment.Remove(third);
        _dbContext.SaveChanges();
    }

    [Fact]
    public void RemoveEquipment_EquipmentExists_EquipmentIsRemovedFromDatabase()
    {
        var equipmentToDelete = new Equipment
        {
            Name = "Test",
            Amount = 1,
            Description = "Test"
        };

        _equipmentRepository.AddnewEquipment(equipmentToDelete);
        _equipmentRepository.RemoveEquipment(equipmentToDelete);

        var result = _dbContext.Equipment.FirstOrDefault(e => e.Name == "Test");

        Assert.Null(result);
    }

    [Fact]
    public void UpdateEquipment_ValidValuesChanged_EquipmentIsUpdated()
    {
        var existing = new Equipment { Name = "Test", Amount = 2 };
        _equipmentRepository.AddnewEquipment(existing);
        existing = _dbContext.Equipment.FirstOrDefault(e => e.Name == "Test");
        var existingName = existing.Name;

        var updated = _dbContext.Equipment.FirstOrDefault(e => e.Name == "Test");
        updated.Name = "Test Update";

        _equipmentRepository.UpdateEquipment(updated);

        Assert.NotEqual(existingName, updated.Name);
        Assert.True(existing.Id == updated.Id);
        Assert.Equal(updated, _dbContext.Equipment.FirstOrDefault(e => e.Name == "Test Update"));

        _dbContext.Equipment.Remove(updated);
        _dbContext.SaveChanges();
    }

    [Fact]
    public void Dispose_Called_DisposesDbContext()
    {
        _equipmentRepository.Dispose();

        Action action = () => _dbContext.Equipment.FirstOrDefault();
        Assert.Throws<InvalidOperationException>(action);
    }
}
