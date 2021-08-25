using AngleSharp.Dom;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.CoDWikiFandom
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
