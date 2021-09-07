using System.Text.Json.Serialization;

namespace CodWeaponsRandomizer.Core.Entities
{
    public class PerkTier
    {
        public int Tier { get; set; }
        public List<GameItem> Perks { get; set; } = new List<GameItem>();

        public PerkTier(int tier)
        {
            Tier = tier;
        }

        [JsonConstructor]
        public PerkTier(int tier, List<GameItem> perks): this(tier)
        {
            Perks = perks;
        }
    }
}
