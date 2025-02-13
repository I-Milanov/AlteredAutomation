using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UITests
{
    public class Tests
    {
        IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            var driverOptions = new ChromeOptions();
            driverOptions.AddArgument("--start-maximized");
            _driver = new ChromeDriver(driverOptions);
            _driver.Url = "https://www.altered.gg/";
            _driver.FindElement(By.XPath("//*[@id='didomi-notice-agree-button']")).Click();
        }

        [Test]
        public void LoginPageNavigated_When_ClickSignInButton()
        {
            IWebElement signInButton = _driver.FindElement(By.XPath("//button[./span[text()='Sign in']]"));
            signInButton.Click();

            var emailLabel = _driver.FindElement(By.XPath("//label[@for='username']"));
            var passwordLabel = _driver.FindElement(By.XPath("//label[@for='password']"));
            var continueButton = _driver.FindElement(By.XPath("//*[@name='login']"));

            Assert.AreEqual("Email *", emailLabel.Text, "Email label is not as expected");
            Assert.AreEqual("Password *", passwordLabel.Text, "Password label is not as expected");
            Assert.AreEqual("CONTINUE", continueButton.Text, "Continue button is not as expected");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}