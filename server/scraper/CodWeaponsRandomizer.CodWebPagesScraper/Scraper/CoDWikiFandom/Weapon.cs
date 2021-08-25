using AngleSharp.Dom;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.CoDWikiFandom
{
    class Weapon: ScrapedGameItem
    {
        public WeaponCategory Category { get; set; }
        public string WeaponDetailsPagePath { get; set; }
        public IEnumerable<AttachmentCategory> AttachmentCategories { get; set; }

        private Weapon(string name, string weaponDetailsPagePath): base(name)
        {
            WeaponDetailsPagePath = weaponDetailsPagePath;
            AttachmentCategories = new List<AttachmentCategory>();
        }

        public static Weapon Parse(IElement anchorElement)
        {
            string weaponName = anchorElement.Text();

            return new Weapon(weaponName, anchorElement.GetAttribute("href"));
        }
    }
}
