using Infrastructure.Models;

namespace Infrastructure.Extensions
{
    public static class CardsExtensions
    {
        public static IEnumerable<Card> FilterByFaction(this IEnumerable<Card> cards, Faction faction)
        {
            return cards.Where(c => c.Faction == faction);
        }

        public static IEnumerable<Card> FilterByCardName(this IEnumerable<Card> cards, string cardName)
        {
            return cards.Where(c => c.Name == cardName);
        }

        public static IEnumerable<Card> DistinctByName(this IEnumerable<Card> cards)
        {
            return cards.DistinctBy(c => c.Name);
        }
    }
}
