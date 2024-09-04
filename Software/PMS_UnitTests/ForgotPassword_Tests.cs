using BusinessLogicLayer;
using DataAccessLayer.Interfaces;
using FakeItEasy;
using ModelsLayer.Models;
using System.Threading.Tasks;

namespace PMS_UnitTests
{
    public class ForgotPassword_Tests
    {
        private readonly IUserRepository fakeUserRepository;
        private readonly UserService userService;

        public ForgotPassword_Tests()
        {
            fakeUserRepository = A.Fake<IUserRepository>();
            userService = new UserService(fakeUserRepository);
        }

        [Fact]
        public async Task ForgotPassword_InvalidEmail_ReturnsInvalidEmailResponse()
        {
            var invalidEmail = "invalidemail";

            var result = await userService.ForgotPassword(invalidEmail);

            Assert.False(result.Success);
            Assert.Equal("The invalid email.Please provide a valid email address ending with '@gmail.com'.", result.Message);
        }

        [Fact]
        public async Task ForgotPassword_ErrorCaused_ReturnsDefaultErrorMessage()
        {
            var invalidEmail = "invalidemail@gmail.com";

            var result = await userService.ForgotPassword(invalidEmail);

            Assert.False(result.Success);
            Assert.Equal("Error occured. Failed to send an email.", result.Message);
        }

        [Fact]
        public async Task ForgotPassword_NonExistingUser_ReturnNonExistingUserResponse()
        {
            var invalidEmail = "invalidemail@gmail.com";

            A.CallTo(() => fakeUserRepository.GetForgotPasswordModel(invalidEmail)).Returns(Task.FromResult<ForgotPasswordModel>(null));

            var result = await userService.ForgotPassword(invalidEmail);

            Assert.False(result.Success);
            Assert.Equal("There is no account registered with the provided email address.Please verify the email address and try again.", result.Message);
        }

        [Fact]
        public async Task ForgotPassword_ValidEmailInserted_ReturnSuccessfullySentResponse()
        {
            var validEmail = "martakovac73@gmail.com";

            var model = new ForgotPasswordModel
            {
                FirstName = "John",
                MailTo = validEmail,
                Password = "password123"
            };

            A.CallTo(() => fakeUserRepository.GetForgotPasswordModel(validEmail)).Returns(Task.FromResult(model));
            
            var result = await userService.ForgotPassword(validEmail);

            Assert.True(result.Success);
            Assert.Equal("Your password has been sent successfully to inserted email: martakovac73@gmail.com.", result.Message);
        }
    }
}
