namespace CodWeaponsRandomizer.CodWebPagesScraper.Data
{
    class AttachmentCategory
    {
        public string Name { get;  }
        public IEnumerable<string> AttachmentVariants { get; set;  }

        public AttachmentCategory(string name)
        {
            Name = name;
            AttachmentVariants = new List<string>();
        }
    }
}
