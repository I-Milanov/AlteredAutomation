using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Infrastructure;

namespace UITests
{
    public class BaseTests
    {
        public IWebDriver Driver { get; set; }

        public LoginPage LoginPage => new LoginPage(Driver);

        public HomePage HomePage => new HomePage(Driver);


        [OneTimeSetUp]
        public void OneTimeSetup() {
            var driverOptions = new ChromeOptions();
            driverOptions.AddArgument("--start-maximized");
            Driver = new ChromeDriver(driverOptions);
            Driver.Url = "https://www.altered.gg/";
            Driver.FindElement(By.XPath("//*[@id='didomi-notice-agree-button']")).Click();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}
