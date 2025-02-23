namespace Infrastructure.Models
{
    public class Card
    {
        public string Name { get; set; }
        public Faction Faction { get; set; }
        public CardType Type { get; set; }
        public Rarity Rarity { get; set; }
        public int HandCost { get; set; }
        public int ReserveCost { get; set; }
        public int ForestAttribute { get; set; }
        public int MountainAttribute { get; set; }
        public int WaterAttribute { get; set; }
        public string MainEffect { get; set; }
        public List<SubType> SubTypes { get; set; } = new List<SubType>();
        public bool IsOutOfFaction { get; set; }
        public bool IsAltArt { get; set; }
        public string ImageUrl { get; set; }
        public List<Action> Actions { get; set; } = new List<Action>();
    }
}
