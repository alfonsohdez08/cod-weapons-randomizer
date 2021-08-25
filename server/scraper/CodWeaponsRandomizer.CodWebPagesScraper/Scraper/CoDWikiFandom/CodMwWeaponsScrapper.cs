using AngleSharp.Dom;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.CoDWikiFandom
{
    class CodMwWeaponsScrapper : WikiScraper<IEnumerable<WeaponCategory>>
    {
        private CodMwWeaponsScrapper() : base("Call_of_Duty:_Modern_Warfare_(2019)")
        {
        }
        private static IEnumerable<IElement> GetWeaponAnchorElements(IElement weaponsCell) => weaponsCell.QuerySelectorAll("a");

        private static IEnumerable<AttachmentCategory> GetWeaponAttachmentCategories(Weapon weapon)
            => CodMwWeaponAttachmentsScrapper.ScrapAttachmentCategories(weapon.WeaponDetailsPagePath);

        private IElement GetWeaponTableElement()
        {
            var weaponsHeader = Document.GetElementById("Weapons");
            if (weaponsHeader is null)
                throw new InvalidOperationException("Did not find the header HTML tag for the Weapons section. Please, make sure you are in the Wiki home page " +
                    "for Call of Duty Modern Warfare 2019.");

            return weaponsHeader.ParentElement.NextElementSibling.QuerySelector("table");
        }

        public override IEnumerable<WeaponCategory> Scrap()
        {
            var weaponCategories = new List<WeaponCategory>();

            IElement weaponTableElement = GetWeaponTableElement();
            foreach (IElement weaponCategoryCell in weaponTableElement.QuerySelectorAll("td.navbox-group"))
            {
                WeaponCategory weaponCategory = WeaponCategory.Parse(weaponCategoryCell.QuerySelector("a"));
                weaponCategories.Add(weaponCategory);

                foreach (IElement weaponAnchorElement in GetWeaponAnchorElements(weaponCategoryCell.NextElementSibling))
                {
                    Weapon weapon = Weapon.Parse(weaponAnchorElement);
                    
                    weapon.Category = weaponCategory;
                    weaponCategory.AddWeapon(weapon);

                    weapon.AttachmentCategories = GetWeaponAttachmentCategories(weapon);
                }
            }

            return weaponCategories;
        }

        public static IEnumerable<WeaponCategory> ScrapWeapons() => new CodMwWeaponsScrapper().Scrap();
    }
}
