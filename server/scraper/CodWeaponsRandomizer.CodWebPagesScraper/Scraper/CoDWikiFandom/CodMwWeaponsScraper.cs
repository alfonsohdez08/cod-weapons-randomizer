using AngleSharp.Dom;
using AngleSharp.Html.Dom;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.CoDWikiFandom
{
    class CodMwWeaponsScraper : WikiScraper<IEnumerable<Weapon>>
    {
        private CodMwWeaponsScraper() : base("Call_of_Duty:_Modern_Warfare_(2019)")
        {
        }
        private static IEnumerable<IElement> GetWeaponAnchorElements(IElement weaponsCell) => weaponsCell.QuerySelectorAll("a");

        private static IEnumerable<AttachmentCategory> GetWeaponAttachmentCategories(Weapon weapon)
            => CodMwWeaponAttachmentsScraper.ScrapAttachmentCategories(weapon.WeaponDetailsPagePath);

        private IHtmlTableElement FindWeaponTableElement()
        {
            IHtmlHeadingElement weaponsHeading = FindWeaponsSectionHeadingElement();

            return weaponsHeading.ParentElement.NextElementSibling.QuerySelector<IHtmlTableElement>("table");
        }

        private IHtmlHeadingElement FindWeaponsSectionHeadingElement()
            => HtmlDocument.QuerySelector<IHtmlHeadingElement>("#Weapons");

        private static IEnumerable<IHtmlTableDataCellElement> GetWeaponTableDataCellElements(IHtmlTableElement tableElement)
            => tableElement.QuerySelectorAll<IHtmlTableDataCellElement>("td.navbox-group");

        public override IEnumerable<Weapon> Scrap()
        {
            IHtmlTableElement weaponTableElement = FindWeaponTableElement();
            foreach (IHtmlTableDataCellElement dataCellElement in GetWeaponTableDataCellElements(weaponTableElement))
            {

            }


            throw new NotImplementedException();
        }

        //public override IEnumerable<Weapon> Scrap()
        //{
        //    var weaponCategories = new List<WeaponCategory>();

        //    IElement weaponTableElement = FindWeaponTableElement();
        //    foreach (IElement weaponCategoryCell in weaponTableElement.QuerySelectorAll("td.navbox-group"))
        //    {
        //        WeaponCategory weaponCategory = WeaponCategory.Parse(weaponCategoryCell.QuerySelector("a"));
        //        if (weaponCategory.Name == "Attachments")
        //            break;

        //        weaponCategories.Add(weaponCategory);

        //        foreach (IElement weaponAnchorElement in GetWeaponAnchorElements(weaponCategoryCell.NextElementSibling))
        //        {
        //            Weapon weapon = Weapon.Parse(weaponAnchorElement);

        //            weapon.Category = weaponCategory;
        //            weaponCategory.AddWeapon(weapon);

        //            //weapon.AttachmentCategories = GetWeaponAttachmentCategories(weapon);
        //        }
        //    }

        //    throw new NotImplementedException();

        //}

        public static IEnumerable<Weapon> ScrapWeapons() => new CodMwWeaponsScraper().Scrap();
    }
}
