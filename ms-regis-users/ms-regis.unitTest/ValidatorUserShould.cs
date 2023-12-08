using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ms_regis.domain.contracts;
using ms_regis.domain.dto;
using ms_regis.domain.services;
using Newtonsoft.Json;
using Xunit.Abstractions;

namespace ms_regis.unitTest
{
    public class ValidatorUserShould
    {

        private readonly ITestOutputHelper _outputHelper;

        public ValidatorUserShould(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        private void BuildRequiredComponents(out ValidatorUserServices validatorUserServices)
        {
            var builder = new ConfigurationBuilder();
            var config = builder.Build();
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<IValidatorUser, ValidatorUserServices>();
                })
                .Build();
            validatorUserServices = ActivatorUtilities.CreateInstance<ValidatorUserServices>(host.Services);
        }

        [Fact]
        public void ValidateEmail_Ok()
        {
            //args
            string email = "daniels.geek@gmail.com";

            //Act
            BuildRequiredComponents(out ValidatorUserServices services);
            var result = services.ValidateEmail(email);

            //Assert
            Assert.True(result);
            _outputHelper.WriteLine(JsonConvert.SerializeObject(result));

        }
        [Fact]
        public void ValidateEmail_NOk()
        {
            //args
            string email = "daniels.geekgmail.com";

            //Act
            BuildRequiredComponents(out ValidatorUserServices services);
            var result = services.ValidateEmail(email);

            //Assert
            Assert.True(!result);
            _outputHelper.WriteLine(JsonConvert.SerializeObject(result));

        }
        [Fact]
        public void ValidatePassword_Ok()
        {
            //args
            string password = "Dani.123";

            //Act
            BuildRequiredComponents(out ValidatorUserServices services);
            var result = services.ValidatePassword(password);

            //Assert
            Assert.True(result);
            _outputHelper.WriteLine(JsonConvert.SerializeObject(result));

        }
        [Fact]
        public void ValidatePassword_NoSpecialCharacters()
        {
            //args
            string password = "Dani1234";

            //Act
            BuildRequiredComponents(out ValidatorUserServices services);
            var result = services.ValidatePassword(password);

            //Assert
            Assert.True(!result);
            _outputHelper.WriteLine(JsonConvert.SerializeObject(result));

        }
        [Fact]
        public void ValidatePassword_WithoutCapitalLeter()
        {
            //args
            string password = "dani.123";

            //Act
            BuildRequiredComponents(out ValidatorUserServices services);
            var result = services.ValidatePassword(password);

            //Assert
            Assert.True(!result);
            _outputHelper.WriteLine(JsonConvert.SerializeObject(result));

        }
        [Fact]
        public void ValidatePassword_WithoutLowerLeter()
        {
            //args
            string password = "DANI.123";

            //Act
            BuildRequiredComponents(out ValidatorUserServices services);
            var result = services.ValidatePassword(password);

            //Assert
            Assert.True(!result);
            _outputHelper.WriteLine(JsonConvert.SerializeObject(result));

        }
        [Fact]
        public void ValidatePassword_WithSpace()
        {
            //args
            string password = "Dani 123";

            //Act
            BuildRequiredComponents(out ValidatorUserServices services);
            var result = services.ValidatePassword(password);

            //Assert
            Assert.True(!result);
            _outputHelper.WriteLine(JsonConvert.SerializeObject(result));

        }
        [Fact]
        public void ValidatePassword_7Characters()
        {
            //args
            string password = "Dani.12";

            //Act
            BuildRequiredComponents(out ValidatorUserServices services);
            var result = services.ValidatePassword(password);

            //Assert
            Assert.True(!result);
            _outputHelper.WriteLine(JsonConvert.SerializeObject(result));

        }
        [Fact]
        public void ValidatePassword_WithoutNumber()
        {
            //args
            string password = "DaniDuran.";

            //Act
            BuildRequiredComponents(out ValidatorUserServices services);
            var result = services.ValidatePassword(password);

            //Assert
            Assert.True(!result);
            _outputHelper.WriteLine(JsonConvert.SerializeObject(result));

        }
        [Fact]
        public void ValidateUser_Ok()
        {
            //args
            User user = new User()
            {
                Id = 1,
                Name = "Daniel",
                LastName = "Duran",
                Email = "daniels.geek@gmail.com",
                Password = "Dani.1234"
            };

            //Act
            BuildRequiredComponents(out ValidatorUserServices services);
            var result = services.ValidateUser(user, out LoginResult loginResult);

            //Assert
            Assert.True(result);
            Assert.True(string.IsNullOrEmpty(loginResult.message));
            Assert.True(loginResult.code.Equals(200));
            Assert.True(loginResult.state);
            _outputHelper.WriteLine(JsonConvert.SerializeObject(loginResult));
        }
        [Fact]
        public void ValidateUser_EmailNOK()
        {
            //args
            User user = new User()
            {
                Id = 1,
                Name = "Daniel",
                LastName = "Duran",
                Email = "daniels.geekgmail.com",
                Password = "Dani.1234"
            };

            //Act
            BuildRequiredComponents(out ValidatorUserServices services);
            var result = services.ValidateUser(user, out LoginResult loginResult);

            //Assert
            Assert.True(!result);
            Assert.True(!string.IsNullOrEmpty(loginResult.message));
            Assert.True(loginResult.code.Equals(99));
            Assert.True(!loginResult.state);
            _outputHelper.WriteLine(JsonConvert.SerializeObject(loginResult));
        }
        [Fact]
        public void ValidateUser_PasswordNOK()
        {
            //args
            User user = new User()
            {
                Id = 1,
                Name = "Daniel",
                LastName = "Duran",
                Email = "daniels.geek@gmail.com",
                Password = "dani.1234"
            };

            //Act
            BuildRequiredComponents(out ValidatorUserServices services);
            var result = services.ValidateUser(user, out LoginResult loginResult);

            //Assert
            Assert.True(!result);
            Assert.True(!string.IsNullOrEmpty(loginResult.message));
            Assert.True(loginResult.code.Equals(99));
            Assert.True(!loginResult.state);
            _outputHelper.WriteLine(JsonConvert.SerializeObject(loginResult));
        }
        [Fact]
        public void ValidateUser_Password_emailNOK()
        {
            //args
            User user = new User()
            {
                Id = 1,
                Name = "Daniel",
                LastName = "Duran",
                Email = "daniels.geekgmail.com",
                Password = "dan123"
            };

            //Act
            BuildRequiredComponents(out ValidatorUserServices services);
            var result = services.ValidateUser(user, out LoginResult loginResult);

            //Assert
            Assert.True(!result);
            Assert.True(!string.IsNullOrEmpty(loginResult.message));
            Assert.True(loginResult.code.Equals(99));
            Assert.True(!loginResult.state);
            _outputHelper.WriteLine(JsonConvert.SerializeObject(loginResult));
        }
    }
}