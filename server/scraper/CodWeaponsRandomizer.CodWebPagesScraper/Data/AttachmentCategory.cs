namespace CodWeaponsRandomizer.CodWebPagesScraper.Data
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
