using ms_regis.domain.dto;

namespace ms_regis.domain.contracts
{
    public interface IManagementNotification
    {
        public bool SendEmail(NotificationArgs args);
    }
}
