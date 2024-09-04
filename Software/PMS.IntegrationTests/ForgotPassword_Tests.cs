using DataAccessLayer;
using EntityLayer;
using ModelsLayer.Models;

namespace PMS.IntegrationTests;

public class ForgotPassword_Tests
{
    private readonly PMSModel _dbContext;
    private readonly UserRepository _userRepository;

    public ForgotPassword_Tests()
    {
        _dbContext = new PMSModel(@"Server = localhost\SQLEXPRESS; Database = IntegrationTestDB; Trusted_Connection = True;");
        _userRepository = new UserRepository(_dbContext);
    }

    [Fact]
    public async void GetForgotPasswordModel_ExistingEmailForwarded_CorrectDataRetrieved()
    {
        var existingEmail = "martakovac73@gmail.com";
        var expected = _dbContext.Users.FirstOrDefault(x => x.Email == existingEmail);

        var result = await _userRepository.GetForgotPasswordModel(existingEmail);

        Assert.IsType<ForgotPasswordModel>(result);
        Assert.Equal(expected.Email, result.MailTo);
        Assert.Equal(expected.Password, result.Password);
        Assert.Equal(expected.FirstName, result.FirstName);
    }

    [Fact]
    public async void GetForgotPasswordMode_NonExistingEmailForwarded_ReturnsNull()
    {
        var nonExistingEmail = "anonim@gmail.com";

        var result = await _userRepository.GetForgotPasswordModel(nonExistingEmail);

        Assert.Null(result);
    }
}
