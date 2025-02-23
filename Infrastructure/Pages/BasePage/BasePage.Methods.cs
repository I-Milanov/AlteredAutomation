using OpenQA.Selenium;

namespace Infrastructure.Pages
{
    public abstract partial class BasePage
    {
        protected BasePage(IWebDriver driver)
        {
            Driver = driver;                
        }

        public abstract string Url { get; }

        public abstract string DomTitle { get; }

        protected IWebDriver Driver { get; set; }

        public void Open()
        {
            Driver.Navigate().GoToUrl(Url);
        }
    }
}
