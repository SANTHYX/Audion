namespace Infrastructure.Options
{
    public class SmtpOptions
    {
        public const string Section = "Mailing:Smtp";
        public string Server { get; set; }
        public int Port { get; set; }
        public bool RequiresAuthentication { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public bool UseSSL { get; set; }
    }
}
