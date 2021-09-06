using CodWeaponsRandomizer.CodWebPagesScraper.Scraper.Cod.MW;

namespace CodWeaponsRandomizer.CodWebPagesScraper
{
    class MwDbExporter : CodDbExporter
    {

        public MwDbExporter(MwWikiHomePageScraper mwWikiHomePageScraper): base(mwWikiHomePageScraper)
        {

        }

        protected override string ExportRootFolder => "mw";
    }
}
