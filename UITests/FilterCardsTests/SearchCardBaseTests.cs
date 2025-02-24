using Infrastructure;
using Infrastructure.Models;
using Infrastructure.Services;
namespace UITests
{
    public class SearchCardBaseTests : BaseTests
    {
        public static IEnumerable<Card> GetAllCards => DatabaseService.GetAllCards();

        [OneTimeSetUp]
        public override void OneTimeSetup()
        {
            base.OneTimeSetup();

            var user = UserFactory.RegisteredUser();
            LoginPage.Open();
            LoginPage.SubmitForm(user);
            // TODO I.M.(2025.02.23) Remove the following step when fix wait for ajax
            HomePage.ClickSignInButton();
        }
    }
}