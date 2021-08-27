using AngleSharp.Html.Dom;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.CoDWikiFandom
{
    class ModernWarfareWeaponDetailsPageScraper : WebPageScraper<Weapon>
    {
        public ModernWarfareWeaponDetailsPageScraper(string weaponWikiPage): base(weaponWikiPage)
        {

        }

        private bool IsExclusiveMwWeapon() => HtmlDocument.GetElementById("Call_of_Duty:_Modern_Warfare") == null;

        private IHtmlElement FindWeaponAsideElement()
        {
            if (IsExclusiveMwWeapon())
                return HtmlDocument.QuerySelector("aside") as IHtmlElement;
            else
                return HtmlDocument.GetElementById("Call_of_Duty:_Modern_Warfare").ParentElement.NextElementSibling.NextElementSibling as IHtmlElement;
        }

        public override Weapon Scrap()
        {
            IHtmlElement asideElement = FindWeaponAsideElement();

            return new ModernWarfareWeaponContainerScraper(asideElement).Scrap();
        }
    }
}
