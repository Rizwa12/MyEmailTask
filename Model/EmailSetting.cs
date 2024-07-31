namespace EmailSendTask.Model
{
    public class EmailSetting
    {
        public string? from { get; set; }
        public bool? isFake { get; set; }
        public string? password { get; set; }
        public string? smtpServer { get; set; }
        public int? smtpPort { get; set; }
        public bool? UseSSL { get; set; }
    }
}
