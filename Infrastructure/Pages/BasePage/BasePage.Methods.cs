using Infrastructure.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Infrastructure.Pages
{
    public abstract partial class BasePage
    {
        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(AppSettings.Timeout.Main));
        }
  
        public abstract string Url { get; }

        public abstract string DomTitle { get; }

        protected IWebDriver Driver { get; set; }

        protected WebDriverWait Wait { get; set; }

        protected AppSettings AppSettings { get; set; } = ConfigurationService.GetConfiguration();

        protected IJavaScriptExecutor JavaScriptExecutor => Driver as IJavaScriptExecutor;

        public void Open()
        {
            Driver.Navigate().GoToUrl(Url);
            WaitUntilPageLoaded();
        }

        public void Refresh()
        {
            Driver.Navigate().Refresh();
        }

        protected virtual void WaitUntilPageLoaded()
        {
            WaitUntilReady();
            WaitForAjax();
        }

        protected virtual void WaitUntilReady()
        {
            Utilities.Wait.Until(() => {
                var readyState = JavaScriptExecutor.ExecuteScript("return document.readyState").ToString();
                return readyState == "complete"; });
        }

        protected void WaitForAjax()
        {
            int maxSeconds = ConfigurationService.GetConfiguration().Timeout.ForAjax;

            string numberOfAjaxConnections = string.Empty;

            Utilities.Wait.Until(
                () =>
                {
                    numberOfAjaxConnections = JavaScriptExecutor.ExecuteScript("return !isNaN(window.openHTTPs) ? window.openHTTPs : null")?.ToString();

                    if (int.TryParse(numberOfAjaxConnections, out int ajaxConnections))
                    {
                        if (ajaxConnections == 0)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        // If it's not a number, the page might have been freshly loaded indicating the monkey
                        // patch is replaced or we haven't yet done the patch.
                        MonkeyPatchXMLHttpRequest();
                    }

                    return false;
                });
        }

        private void MonkeyPatchXMLHttpRequest()
        {
            var numberOfAjaxConnections = JavaScriptExecutor.ExecuteScript("return !isNaN(window.openHTTPs) ? window.openHTTPs : null")?.ToString();

            if (int.TryParse(numberOfAjaxConnections, out int ajaxConnections))
            {
                return;
            }

            var script = "  (function() {" +
                         "var oldOpen = XMLHttpRequest.prototype.open;" +
                         "window.openHTTPs = 0;" +
                         "XMLHttpRequest.prototype.open = function(method, url, async, user, pass) {" +
                         "window.openHTTPs++;" +
                         "this.addEventListener('readystatechange', function() {" +
                         "if(this.readyState == 4) {" +
                         "window.openHTTPs--;" +
                         "}" +
                         "}, false);" +
                         "oldOpen.call(this, method, url, async, user, pass);" +
                         "}" +
                         "})();";

            JavaScriptExecutor.ExecuteScript(script);
        }
    }
}
