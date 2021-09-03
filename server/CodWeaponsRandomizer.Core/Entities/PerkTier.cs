namespace CodWeaponsRandomizer.Core.Entities
{
    public class PerkTier
    {
        public int Tier { get; set; }
        public List<GameItem> Perks { get; set; }

        public PerkTier(int tier)
        {
            Tier = tier;
            Perks = new List<GameItem>();
        }
    }
}
