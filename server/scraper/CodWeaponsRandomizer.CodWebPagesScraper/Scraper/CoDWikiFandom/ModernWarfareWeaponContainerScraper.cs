using AngleSharp.Html.Dom;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.CoDWikiFandom
{
    class ModernWarfareWeaponContainerScraper : WebPageElementScraper<IHtmlElement, Weapon>
    {
        public ModernWarfareWeaponContainerScraper(IHtmlElement htmlElement): base(htmlElement)
        {

        }

        private static string ParseDataSourceAttribute(string value) => $"data-source=\"{value}\"";

        private string GetWeaponTitle()
        {
            var headingElement = (IHtmlHeadingElement)HtmlElement.QuerySelector($"h2[{ParseDataSourceAttribute("title")}]");
            return headingElement.TextContent;
        }

        private string GetWeaponClass()
        {
            var anchorElement = (IHtmlAnchorElement)HtmlElement.QuerySelector($"div[{ParseDataSourceAttribute("class")}] a");
            return anchorElement.Text;
        }

        private string GetWeaponImageUrl()
        {
            var imageElement = (IHtmlImageElement)HtmlElement.QuerySelector($"*[{ParseDataSourceAttribute("image")}] img");
            return imageElement.Source!;
        }

        public override Weapon Scrap()
        {
            var weapon = new Weapon(GetWeaponClass(), GetWeaponTitle())
            {
                WeaponImageUrl = GetWeaponImageUrl()
            };

            return weapon;
        }
    }
}
