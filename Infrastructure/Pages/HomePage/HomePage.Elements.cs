using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Infrastructure
{
    public partial class HomePage
    {
        public IWebElement UsernameButton => Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//header/following-sibling::div//button[not(.//*[contains(text(),'Sign in')])]")));
        public IWebElement SignInButton => Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[./span[text()='Sign in']]")));
    }
}