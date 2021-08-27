using AngleSharp.Dom;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.CoDWikiFandom
{
    class Weapon: ScrapedGameItem
    {
        public string WeaponClass { get; set; }
        public string WeaponImageUrl { get; set; }
        public IEnumerable<AttachmentCategory> SupportedAttachments { get; set; }

        public Weapon(string weaponClass, string name): base(name)
        {
            WeaponClass = weaponClass;
            SupportedAttachments = new List<AttachmentCategory>();
        }
    }
}
