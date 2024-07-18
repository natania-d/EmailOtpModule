using EmailOtpModule;

namespace EmailOtpModuleTests
{
    public class EmailOtpModuleTest
    {
        private readonly EmailOtpMod _emailOtpModule;
        public EmailOtpModuleTest()
        {
            _emailOtpModule = new EmailOtpMod();
        }

        [Theory]
        [InlineData("natania@dso.org.sg")]
        [InlineData("natania@hr.dso.org.sg")]
        public void GenerateOtpEmailAsync_WithValidEmails_ReturnsEmailOkStatus(string emailAddress)
        {
            //Arrange
            string expectedResult = StatusCodes.EmailOk;
            // Act & Assert
            Assert.Equal(expectedResult, _emailOtpModule.GenerateOtpEmailAsync(emailAddress));
        }

        [Theory]
        [InlineData("natania.dso.org.sg")]
        [InlineData(".dso.org.sg")]
        [InlineData("natania@dso")]
        public void GenerateOtpEmailAsync_WithInvalidEmails_ReturnsEmailInvalidStatus(string emailAddress)
        {
            //Arrange
            string expectedResult = StatusCodes.EmailInvalid;
            // Act & Assert
            Assert.Equal(expectedResult, _emailOtpModule.GenerateOtpEmailAsync(emailAddress));
        }
    }
}
