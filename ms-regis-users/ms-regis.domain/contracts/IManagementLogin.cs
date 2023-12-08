using ms_regis.domain.dto;

namespace ms_regis.domain.contracts
{
    public interface IManagementLogin
    {
        public LoginResult ValidateAcces(LoginArgs args);

        public bool BlockAccess(User user);
    }
}
