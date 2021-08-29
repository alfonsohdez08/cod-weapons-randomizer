using AngleSharp.Dom;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper
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
