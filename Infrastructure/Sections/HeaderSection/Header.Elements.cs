using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Infrastructure
{
    public partial class HeaderSection
    {
        public IWebElement CardsButton => NavigationButton("Cards");

        public IWebElement DecksButton => NavigationButton("Decks");

        public IWebElement MarketButton => NavigationButton("Market");

        public IWebElement PodButton => NavigationButton("POD");

        public IWebElement EventsButton => NavigationButton("Events");

        public IWebElement SignInButton => Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[./span[text()='Sign in']]")));

        private IWebElement NavigationButton(string buttonName) => Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//a[.//span[text()='{buttonName}']]")));

    }
}