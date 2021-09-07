using System.Text.Json.Serialization;

namespace CodWeaponsRandomizer.Core.Entities
{
    public class PerkTier
    {
        [JsonInclude]
        public int Tier { get; private set; }

        [JsonInclude]
        public List<GameItem> Perks { get; private set; }

        public PerkTier(int tier, List<GameItem> perks)
        {
            Tier = tier;
            Perks = perks;
        }
    }
}
