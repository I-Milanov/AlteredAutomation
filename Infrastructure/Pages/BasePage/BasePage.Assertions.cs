using NUnit.Framework;

namespace Infrastructure.Pages
{
    public abstract partial class BasePage
    {
        public void AssertTitle(string? domTitle = null)
        {
            var expectedTitle = domTitle ?? DomTitle;
            var actualTitle = Driver.Title;

            Assert.AreEqual(expectedTitle, actualTitle, "DOM Title is not as expected");
        }
    }
}
