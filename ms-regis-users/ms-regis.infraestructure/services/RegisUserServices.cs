using Microsoft.Extensions.Logging;
using ms_regis.domain.contracts;
using ms_regis.domain.dto;
using System.Text.Json;

namespace ms_regis.infraestructure.services
{
    public class RegisUserServices : IRegisUser
    {
        private readonly IValidatorUser _validatorUser;
        private readonly ILogger<User> _logger;

        public RegisUserServices(IValidatorUser validatorUser, ILogger<User> logger)
        {
            _validatorUser = validatorUser;
            _logger = logger;
        }


        public LoginResult RegisUser(User user)
        {
            try
            {
                var result = _validatorUser.ValidateUser(user, out LoginResult loginResult);
                if (result)
                {
                    string filePath = "C:\\WorkSpace\\file.json";
                    string jsonString = JsonSerializer.Serialize(user);
                    File.AppendAllLines(filePath, new[] { jsonString });
                    return new LoginResult { code = 200, Id = user.Id, state = true, message = "Succes" };

                }
                return new LoginResult { code = 99, Id = 0, state = true, message = "Falla en registro de usuario" };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Falla metodo RegisUser - Fecha:{@fecha}", DateTime.Now);
                return new LoginResult { code = 99, Id = 0, state = false, message = ex.StackTrace! };
            }

        }
    }
}
