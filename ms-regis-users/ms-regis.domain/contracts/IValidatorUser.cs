using ms_regis.domain.dto;

namespace ms_regis.domain.contracts
{
    public interface IValidatorUser
    {
        public bool ValidateUser(User user, out LoginResult loginResult);
        public bool ValidateEmail(string email);
        public bool ValidatePassword(string password);
    }
}
