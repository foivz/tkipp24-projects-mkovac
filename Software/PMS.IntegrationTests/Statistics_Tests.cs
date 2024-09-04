using DataAccessLayer;

namespace PMS.IntegrationTests;

public class Statistics_Tests
{
    private readonly PMSModel _dbContext;
    private readonly AttendanceRepository _attendanceRepository;

    public Statistics_Tests()
    {
        _dbContext = new PMSModel(@"Server = localhost\SQLEXPRESS; Database = IntegrationTestDB; Trusted_Connection = True;");
        _attendanceRepository = new AttendanceRepository(_dbContext);
    }

    [Fact]
    public async void GetChildrenPerYear_ChildrenExists_ReturnsList()
    {
        var year = 2024;

        var result = await _attendanceRepository.GetChildrenPerYear(year);

        Assert.NotNull(result);
        Assert.True(result.Count == 5);
        Assert.True(result.TrueForAll(x => x.isPresent == true));
        Assert.True(result.TrueForAll(x => x.Date.Value.Year == year));
    }
}
