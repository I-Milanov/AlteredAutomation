using Infrastructure.Pages;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Infrastructure
{
    public partial class CardsPage : AlteredPage
    {
        public IReadOnlyCollection<IWebElement> Cards => Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//button[./p]")));

        public IWebElement SearchInput => Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("translations.name")));

        public IWebElement SearchButton => Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@data-testid='search']")));

        public IWebElement CardNameByPosition(int position) => Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"(//button/p)[position()={position+1}]")));

    }
}
