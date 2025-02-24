using Infrastructure;
using Infrastructure.Extensions;
using Infrastructure.Models;

namespace UITests
{
    public class SearchCardByNameTests : SearchCardBaseTests
    {
        private static IEnumerable<TestCaseData> GetCardData()
        {
            return GetAllCards
                .DistinctByName()
                .Select(card =>
                {
                    var testCase = new TestCaseData(card);
                    testCase.SetName($"{card.Name} cards were visible when filter by card name");
                    return testCase;
                });
        }

        [SetUp]
        public void Setup()
        {
            CardsPage.Open();
        }

        [TestCaseSource(nameof(GetCardData))]
        public void CorrectCardsWereVisible_When_FilterByCardName(Card card)
        {
            CardsPage.Search(card);
            
            CardsPage.AssertCards(GetAllCards.FilterByCardName(card.Name).ToList());
        }     
    }
}