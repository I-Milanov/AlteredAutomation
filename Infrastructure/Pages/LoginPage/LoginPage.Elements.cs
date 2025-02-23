using OpenQA.Selenium;

namespace Infrastructure
{
    public partial class LoginPage
    {
        public IWebElement UsernameField => Driver.FindElement(By.Id("username"));

        public IWebElement PasswordField => Driver.FindElement(By.Id("password"));

        public IWebElement ContinueButton => Driver.FindElement(By.XPath("//button[@type='submit']"));
      
    }
}
