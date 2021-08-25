using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.CoDWikiFandom
{
    class AttachmentCategory : ScrapedGameItem
    {
        public List<string> AttachmentVariants { get; }
        public Weapon Weapon { get; set; }

        private AttachmentCategory(string name) : base(name)
        {
            AttachmentVariants = new List<string>();
        }

        public void AddAttachmentVariant(string variant) => AttachmentVariants.Add(variant);
    }
}
