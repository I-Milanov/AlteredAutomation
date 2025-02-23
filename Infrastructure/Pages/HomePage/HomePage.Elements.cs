using OpenQA.Selenium;

namespace Infrastructure
{
    public partial class HomePage
    {
        public IWebElement usernameButton => Driver.FindElement(By.XPath("//header/following-sibling::div//button"));
    }
}
