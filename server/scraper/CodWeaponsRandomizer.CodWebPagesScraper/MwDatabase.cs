using CodWeaponsRandomizer.CodWebPagesScraper.Scraper.Cod.MW;

namespace CodWeaponsRandomizer.CodWebPagesScraper
{
    class MwDatabase : CodDatabase
    {

        public MwDatabase(MwWikiHomePageScraper mwWikiHomePageScraper): base(mwWikiHomePageScraper)
        {

        }

        protected override string ExportRootFolder => "mw";
    }
}
