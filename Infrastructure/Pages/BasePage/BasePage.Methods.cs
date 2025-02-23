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

        protected IJavaScriptExecutor JavaScriptExecutor => Driver as IJavaScriptExecutor;

        public void Open()
        {
            Driver.Navigate().GoToUrl(Url);
            WaitUntilReady();
        }

        protected virtual void WaitUntilReady()
        {
            Utilities.Wait.Until(() => JavaScriptExecutor.ExecuteScript("return document.readyState") == "complete");
        }
    }
}
