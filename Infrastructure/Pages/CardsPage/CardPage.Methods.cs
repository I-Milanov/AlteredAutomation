using Infrastructure.Models;
using Infrastructure.Pages;
using OpenQA.Selenium;

namespace Infrastructure
{
    public partial class CardsPage : AlteredPage
    {
        public CardsPage(IWebDriver driver) : base(driver)
        {
        }

        public override string Url => "https://www.altered.gg/en-us/cards";

        public override string DomTitle => "Cards - Altered TCG - Explore the Unexpected";

        public void Search(Card card)
        {
            SearchInput.SendKeys(card.Name);
            SearchButton.Click();
        }
    }
}
