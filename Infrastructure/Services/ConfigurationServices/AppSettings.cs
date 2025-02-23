using OpenQA.Selenium;

namespace Infrastructure.Services
{
    public class TimeoutSettings
    {
        public int Main { get; set; }
        public int UntilTotalTimeout { get; set; }
        public int ForAjax { get; set; }
    }

    public class BrowserOptions
    {

        public bool Headless { get; set; }
        public bool StartMaximized { get; set; }
        public bool DisableNotifications { get; set; }
        public bool AcceptInsecureCertificates { get; set; }
        public string UnhandledPromptBehavior { get; set; }

        public UnhandledPromptBehavior GetUnhandledPromptBehavior()
        {
            return Enum.Parse<UnhandledPromptBehavior>(UnhandledPromptBehavior);
        }
    }

    public class AppSettings
    {
        public TimeoutSettings Timeout { get; set; }
        public BrowserOptions BrowserOptions { get; set; }
    }
}
