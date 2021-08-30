using AngleSharp.Dom;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Data
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
