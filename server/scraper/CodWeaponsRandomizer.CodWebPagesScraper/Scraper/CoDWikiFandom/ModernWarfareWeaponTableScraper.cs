using AngleSharp.Html.Dom;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.CoDWikiFandom
{
    class ModernWarfareWeaponTableScraper : WebPageElementScraper<IHtmlTableElement, IEnumerable<string>>
    {
        public ModernWarfareWeaponTableScraper(string htmlElement) : base(htmlElement)
        {
        }

        public override IEnumerable<string> Scrap()
        {
            throw new NotImplementedException();
        }
    }
}
