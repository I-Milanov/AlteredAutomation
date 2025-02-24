using Infrastructure.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Infrastructure
{
    public abstract partial class BaseSection
    {
        protected BaseSection(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(AppSettings.Timeout.Main));
        }
  
        protected IWebDriver Driver { get; set; }

        protected WebDriverWait Wait { get; set; }

        protected AppSettings AppSettings { get; set; } = ConfigurationService.GetConfiguration();
    }
}
