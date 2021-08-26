using AngleSharp.Dom;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.CoDWikiFandom
{
    class Weapon: ScrapedGameItem
    {
        public string Category { get; set; }
        public IEnumerable<AttachmentCategory> SupportedAttachments { get;  }

        public Weapon(string category, string name): base(name)
        {
            SupportedAttachments = new List<AttachmentCategory>();
        }
    }
}
