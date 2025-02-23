using Infrastructure.Pages;
using OpenQA.Selenium;

namespace Infrastructure
{
    public partial class LoginPage : AlteredPage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public override string Url { get; } = "https://auth.altered.gg/realms/players/protocol/openid-connect/auth?client_id=web&scope=openid%20email%20profile%20offline_access&response_type=code&redirect_uri=https%3A%2F%2Fwww.altered.gg%2Fapi%2Fauth%2Fcallback%2Fkeycloak&ui_locales=en&shop_redirect_uri=https%3A%2F%2Fwww.altered.gg%2Fapi%2Fauth%2Fcallback%2Fkeycloak-shop&state=nqAcJhskZ9KLCO_aKV5b7iCjeEKGpKH441D7SeJ6KH4&code_challenge=XKVA5bzDeC9yddX9xiFgIx3mYIa5sJET6PlvSypRxxQ&code_challenge_method=S256";

        public override string DomTitle { get; } = "Player - Sign in - Altered TCG - Explore the Unexpected";

        public void FillForm(User user)
        {
            UsernameField.SendKeys(user.Email);
            PasswordField.SendKeys(user.Password);
        }

        public void SubmitForm(User user)
        {
            FillForm(user);
            ContinueButton.Click();
        }
    }
}
