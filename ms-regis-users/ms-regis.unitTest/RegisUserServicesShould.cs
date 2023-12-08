using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ms_regis.domain.contracts;
using ms_regis.domain.dto;
using ms_regis.domain.services;
using ms_regis.infraestructure.services;
using Newtonsoft.Json;
using Xunit.Abstractions;

namespace ms_regis.unitTest
{
    public class RegisUserServicesShould
    {

        private readonly ITestOutputHelper _outputHelper;

        public RegisUserServicesShould(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        private void BuildRequiredComponents(out RegisUserServices regisUserServices)
        {
            var builder = new ConfigurationBuilder();
            var config = builder.Build();
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<IValidatorUser, ValidatorUserServices>();
                    services.AddTransient<IRegisUser, RegisUserServices>();
                })
                .Build();
            regisUserServices = ActivatorUtilities.CreateInstance<RegisUserServices>(host.Services);
        }

        [Fact]
        public void RegisUser_Ok()
        {
            //args
            var user = new User
            {
                Id = 1,
                Name = "Daniel",
                LastName = "Duran",
                Email = "daniels.geek@gmail.com",
                Password = "Dani123*"
            };

            //Act
            BuildRequiredComponents(out RegisUserServices services);
            var result = services.RegisUser(user);

            //Assert
            Assert.True(result.state);
            _outputHelper.WriteLine(JsonConvert.SerializeObject(result));

        }
    }
}