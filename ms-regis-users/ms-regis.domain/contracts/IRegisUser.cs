using ms_regis.domain.dto;

namespace ms_regis.domain.contracts
{
    public interface IRegisUser
    {
        public LoginResult RegisUser(User user);
    }
}
