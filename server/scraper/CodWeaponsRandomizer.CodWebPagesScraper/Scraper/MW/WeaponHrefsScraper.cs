using AngleSharp.Html.Dom;
using System.Text;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.MW
{
    class WeaponHrefsScraper : WebPageComponentScraper<IHtmlTableElement, List<string>>
    {
        public WeaponHrefsScraper(IHtmlTableElement tableElement) : base(tableElement)
        {
        }

        public override List<string> Scrap() => GetWeaponHrefs();

        private List<string> GetWeaponHrefs()
        {
            const string first19TableRowsSelector = "tr:nth-child(-n+19)"; // the first 19 table rows correspond to the game weapons
            var sb = new StringBuilder(first19TableRowsSelector)
                .Append(" > ")
                .Append(Selectors.TableAnchors);

            return HtmlElement.SelectAll<IHtmlAnchorElement>(sb.ToString()).Select(a => a.Href).ToList();
        }
    }
}
