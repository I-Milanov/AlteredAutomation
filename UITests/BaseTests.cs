using Infrastructure;
using Infrastructure.Models;
using Infrastructure.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace UITests
{
    public class BaseTests
    {
        public IWebDriver Driver { get; private set; }

        public LoginPage LoginPage => new LoginPage(Driver);

        public HomePage HomePage => new HomePage(Driver);

        public CardsPage CardsPage=> new CardsPage(Driver);

        public AppSettings AppSettings { get; set; }

        public BaseTests()
        {
            LoadConfiguration();
        }


        [OneTimeSetUp]
        public virtual void OneTimeSetup()
        {
            InitializeWebDriver();
            HomePage.Open();
            AcceptCookies();
        }

        private void InitializeWebDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            Driver = new ChromeDriver(GetChromeOptions());
        }


        private void LoadConfiguration()
        {
            AppSettings = ConfigurationService.GetConfiguration();
        }

        private void AcceptCookies()
        {
            var cookies = GetCookiesFromHeadlessDriver();

            AddCookies(cookies);
        }

        private void AddCookies(IReadOnlyCollection<Cookie> cookie)
        {
            cookie.ToList().ForEach(cookie => Driver.Manage().Cookies.AddCookie(cookie));
            Driver.Navigate().Refresh();
        }

        private IReadOnlyCollection<Cookie> GetCookiesFromHeadlessDriver()
        {
            using (var headlessDriver = new ChromeDriver(GetHeadlessOptions()))
            {
                var wait = new WebDriverWait(headlessDriver, TimeSpan.FromSeconds(AppSettings.Timeout.Main));
                new HomePage(headlessDriver).Open();

                var agreeButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("didomi-notice-agree-button")));
                agreeButton.Click();

                return headlessDriver.Manage().Cookies.AllCookies;
            }
        }

        protected virtual ChromeOptions GetChromeOptions()
        {
            var options = new ChromeOptions();

            if (AppSettings.BrowserOptions.Headless)
            {
                GetHeadlessOptions(options);
            }

            if (AppSettings.BrowserOptions.StartMaximized)
            {
                options.AddArgument("--start-maximized");
            }

            options.AcceptInsecureCertificates = AppSettings.BrowserOptions.AcceptInsecureCertificates;


            if (AppSettings.BrowserOptions.DisableNotifications)
            {
                options.AddArgument("--disable-notifications");
            }

            options.AcceptInsecureCertificates = AppSettings.BrowserOptions.AcceptInsecureCertificates;
            options.UnhandledPromptBehavior = AppSettings.BrowserOptions.GetUnhandledPromptBehavior();

            return options;
        }

        private ChromeOptions GetHeadlessOptions(ChromeOptions options = null)
        {
            var headlessOptions = options ?? new ChromeOptions();
            headlessOptions.AddArgument("--headless");
            headlessOptions.AddArgument("--disable-gpu");
            headlessOptions.AddArgument("--no-sandbox");
            // Used because the website detects the headless browser
            headlessOptions.AddArgument("user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");

            return headlessOptions;
        }


        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}
