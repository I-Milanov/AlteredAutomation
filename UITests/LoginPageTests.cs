using Infrastructure;
using OpenQA.Selenium;

namespace UITests
{
    public class LoginPageTests : BaseTests
    {
        [Test]
        public void LoginPageNavigated_When_ClickSignInButton()
        {
            var user = UserFactory.RegisteredUser();
            IWebElement signInButton = Driver.FindElement(By.XPath("//button[./span[text()='Sign in']]"));
            signInButton.Click();

            LoginPage.SubmitForm(user);

            HomePage.AssertUserButtonHaveCorrectName(user);
        }
    }
}