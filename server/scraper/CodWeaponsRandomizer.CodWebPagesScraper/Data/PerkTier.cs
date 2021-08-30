namespace CodWeaponsRandomizer.CodWebPagesScraper.Data
{
    class PerkTier
    {
        public int Tier { get; }
        public IEnumerable<string> Perks { get;  }

        public PerkTier(int tier, IEnumerable<string> perks) => (Tier, Perks) = (tier, perks);
    }
}
