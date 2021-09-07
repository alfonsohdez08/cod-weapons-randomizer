using System.Text.Json.Serialization;

namespace CodWeaponsRandomizer.Core.Entities
{
    public class PerkTier
    {
        public int Tier { get; private set; }
        public List<GameItem> Perks { get; private set; }

        public PerkTier(int tier, List<GameItem> perks)
        {
            Tier = tier;
            Perks = perks;
        }
    }
}
