namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.CoDWikiFandom
{
    class AttachmentCategory : ScrapedGameItem
    {
        public IEnumerable<string> AttachmentVariants { get; set; }

        public AttachmentCategory(string name) : base(name)
        {
            AttachmentVariants = new List<string>();
        }
    }
}
