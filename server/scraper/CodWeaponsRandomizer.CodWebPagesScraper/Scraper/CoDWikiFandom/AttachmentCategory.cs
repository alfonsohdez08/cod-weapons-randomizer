namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.CoDWikiFandom
{
    class AttachmentCategory : ScrapedGameItem
    {
        public List<string> AttachmentVariants { get; }

        public AttachmentCategory(string name) : base(name)
        {
            AttachmentVariants = new List<string>();
        }
    }
}
