using AngleSharp.Html.Dom;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.CoDWikiFandom
{
    class ModernWarfareWeaponContainerScraper : WebPageElementScraper<IHtmlElement, Weapon>
    {
        public ModernWarfareWeaponContainerScraper(IHtmlElement htmlElement): base(htmlElement)
        {

        }

        public override Weapon Scrap()
        {
            throw new NotImplementedException();
        }
    }
}
