namespace ms_regis.domain.dto
{
    public class NotificationArgs
    {
        public string subject { get; set; } = string.Empty;
        public string body { get; set; } = string.Empty;
        public string addressee { get; set; } = string.Empty;
        public string addresseeCC { get; set; } = string.Empty;
        public string addresseeCO { get; set; } = string.Empty;
        public FileInfo? attach { get; set; }

    }
}
