using Infrastructure.Pages;
using OpenQA.Selenium;

namespace Infrastructure
{
    public partial class HomePage : AlteredPage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {                
        }

        public override string Url { get; } = "https://www.altered.gg/";

        public override string DomTitle { get; } = "Altered TCG - Explore the Unexpected";
    }
}
