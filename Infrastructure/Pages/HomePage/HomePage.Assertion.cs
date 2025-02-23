using NUnit.Framework;

namespace Infrastructure
{
    public partial class HomePage
    {
        public void AssertUserButtonHaveCorrectName(User user)
        {
            Assert.AreEqual(user.Name.ToUpper(), usernameButton.Text, "Button is not correct");
        }
    }
}
