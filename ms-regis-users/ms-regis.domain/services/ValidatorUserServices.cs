using ms_regis.domain.contracts;
using ms_regis.domain.dto;
using System.Text;
using System.Text.RegularExpressions;

namespace ms_regis.domain.services
{
    public class ValidatorUserServices : IValidatorUser
    {
        public bool ValidateEmail(string email)
        {
            return Regex.IsMatch(email, "^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$", RegexOptions.None, TimeSpan.FromMilliseconds(100));
        }

        public bool ValidatePassword(string password)
        {
            return Regex.IsMatch(password, "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^a-zA-Z\\d\\s]).{8,}$", RegexOptions.None, TimeSpan.FromMilliseconds(100));
        }
        /// <summary>
        /// Validar mejor con fluentvalidation
        /// </summary>
        /// <param name="user"></param>
        /// <param name="loginResult"></param>
        /// <returns></returns>
        public bool ValidateUser(User user, out LoginResult loginResult)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (!ValidateEmail(user.Email))
                stringBuilder.AppendLine("Email invalido");

            if (!ValidatePassword(user.Password))
                stringBuilder.AppendLine("Contraseña invalida");

            bool succes = stringBuilder.Length == 0;

            loginResult = new LoginResult()
            {
                code = succes ? 200 : 99,
                Id = succes ? user.Id : 0,
                message = stringBuilder.ToString(),
                state = succes
            };

            return succes;
        }
    }
}
