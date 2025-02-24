using Infrastructure.Models;
using Infrastructure.Pages;
using NUnit.Framework;

namespace Infrastructure
{
    public partial class CardsPage : AlteredPage
    {
        public void AssertCards(List<Card> cards)
        {
            for (int i = 0; i < cards.Count(); i++)
            {
                Assert.AreEqual(cards[i].Name, CardNameByPosition(i).Text, "Card name is not as expected");
            }
        }
    }
}
