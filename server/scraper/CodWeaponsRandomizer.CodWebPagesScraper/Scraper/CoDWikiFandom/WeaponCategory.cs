using AngleSharp.Dom;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.CoDWikiFandom
{
    class WeaponCategory: ScrapedGameItem
    {
        public List<Weapon> Weapons { get; }

        private WeaponCategory(string name): base(name)
        {
            Weapons = new List<Weapon>();
        }

        public void AddWeapon(Weapon weapon) => Weapons.Add(weapon);

        public static WeaponCategory Parse(IElement anchorElement)
        {
            string category = anchorElement.Text();

            return new WeaponCategory(category);
        }
    }
}
