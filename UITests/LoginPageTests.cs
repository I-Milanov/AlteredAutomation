using Infrastructure;

namespace UITests
{
    public class LoginPageTests : BaseTests
    {
        [Test]
        public void LoginPageNavigated_When_ClickSignInButton()
        {
            HomePage.ClickSignInButton();

            LoginPage.AssertTitle();
        }

        [Test]
        public void LoginSuccessfully_When_SubmitValidCredentials()
        {
            var user = UserFactory.RegisteredUser();

            LoginPage.Open();
            LoginPage.SubmitForm(user);

            // TODO I.M.(2025.02.23) Remove the following step when fix wait for ajax
            HomePage.ClickSignInButton();

            HomePage.AssertUserButtonHaveCorrectName(user);
        }
    }
}