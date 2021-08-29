using AngleSharp.Dom;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.Data
{
    class ScrapedGameItem
    {
        public string Name { get; }

        protected ScrapedGameItem(string name)
        {
            Name = name;
        }
    }
}
