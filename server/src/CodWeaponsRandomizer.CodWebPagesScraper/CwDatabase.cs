using CodWeaponsRandomizer.CodWebPagesScraper.Scraper.Cod.CW;
using CodWeaponsRandomizer.Core.Entities;

namespace CodWeaponsRandomizer.CodWebPagesScraper
{
    class CwDatabase : CodDatabase
    {
        private readonly List<GameItem> _wildcards;

        public CwDatabase(CwWikiHomePageScraper cwWikiHomePageScraper) : base(cwWikiHomePageScraper)
        {
            _wildcards = cwWikiHomePageScraper.ScrapWildcards();
        }

        protected override void Export()
        {
            base.Export();

            Export("wildcards.json", _wildcards);
        }

        protected override string ExportRootFolder => "cw";
    }
}
