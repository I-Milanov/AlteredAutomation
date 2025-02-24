namespace Infrastructure.DTOs
{
    public class CardJsonDto
    {
        public string id { get; set; }
        public string name { get; set; }
        public string mainFaction { get; set; }
        public string cardType { get; set; }
        public string rarity { get; set; }
        public string imagePath { get; set; }
        public string HandCost { get; set; }
        public string ReserveCost { get; set; }
        public string ForestAttribute { get; set; }
        public string MountainAttribute { get; set; }
        public string WaterAttribute { get; set; }
        public bool isSuspended { get; set; }
    }

    public class CardsJsonWrapper
    {
        public List<CardJsonDto> cards { get; set; }
    }
}
