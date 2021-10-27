using AngleSharp.Html.Dom;
using CodWeaponsRandomizer.Core.Entities;
using System.Collections.Generic;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.Cod
{
    class PerkTableScraper: TableScraper
    {
        private static readonly Dictionary<int, int> _perkTierRowNumber = new Dictionary<int, int>()
        {
            {1, 3 },
            {2, 5 },
            {3, 7 },
        };

        public PerkTableScraper(IHtmlTableElement tableElement) : base(tableElement)
        {

        }

        private static int GetRowNumberByPerkTier(int perkTier) => _perkTierRowNumber[perkTier];

        private PerkTier ScrapPerk(int perkTier)
        {
            int rowNumber = GetRowNumberByPerkTier(perkTier);
            List<GameItem> perks = ParseAnchors(GetSingleRowAnchors(rowNumber));

            return new PerkTier(perkTier, perks);
        }

        public List<PerkTier> ScrapPerks()
        {
            var perks = new List<PerkTier>(3);

            for (int perkTier = 1; perkTier <= perks.Capacity; perkTier++)
                perks.Add(ScrapPerk(perkTier));

            return perks;
        }
    }
}
