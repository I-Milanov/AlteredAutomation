using Infrastructure.DTOs;
using Infrastructure.Models;
using System.Text.Json;

namespace Infrastructure.Services
{
    public static class DatabaseService
    {
        private readonly static string _dataFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "CardsBySet");

        public static List<Card> GetAllCards()
        {
            List<Card> allCards = new();

            // Get all JSON files in the folder
            var files = Directory.GetFiles(_dataFolder, "*.json");

            foreach (var file in files)
            {
                string jsonContent = File.ReadAllText(file);
                var deserializedData = JsonSerializer.Deserialize<CardsJsonWrapper>(jsonContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (deserializedData?.cards != null)
                {
                    foreach (var cardDto in deserializedData.cards)
                    {
                        allCards.Add(MapToCard(cardDto));
                    }
                }
            }

            return allCards;
        }

        private static Card MapToCard(CardJsonDto dto)
        {
            return new Card
            {
                Name = dto.name,
                Faction = Enum.TryParse<Faction>(dto.mainFaction, out var faction) ? faction : default,
                Type = Enum.TryParse<CardType>(dto.cardType, out var type) ? type : default,
                Rarity = Enum.TryParse<Rarity>(dto.rarity, out var rarity) ? rarity : default,
                HandCost = int.TryParse(dto.HandCost, out var handCost) ? handCost : null,
                ReserveCost = int.TryParse(dto.ReserveCost, out var reserveCost) ? reserveCost : null,
                ForestAttribute = int.TryParse(dto.ForestAttribute, out var forest) ? forest : null,
                MountainAttribute = int.TryParse(dto.MountainAttribute, out var mountain) ? mountain : null,
                WaterAttribute = int.TryParse(dto.WaterAttribute, out var water) ? water : null,
                ImageUrl = dto.imagePath,
                IsAltArt = dto.id.Contains("ALT"),  // Example: detecting alt art from ID
                IsOutOfFaction = false, // Placeholder, adjust based on logic
            };
        }
    }
}
