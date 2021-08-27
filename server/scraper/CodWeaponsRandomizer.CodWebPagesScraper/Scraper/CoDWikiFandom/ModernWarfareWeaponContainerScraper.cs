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

        private string? GetWeaponImageUrl()
        {
            var imageElement = (IHtmlImageElement)HtmlElement.QuerySelector($"*[{ParseDataSourceAttribute("image")}] img");
            return imageElement?.Source ?? null;
        }

        private string? GetHUDIconUrl()
        {
            var imageElement = (IHtmlImageElement)HtmlElement.QuerySelector($"*[{ParseDataSourceAttribute("HUD")}] img");
            return imageElement?.Source ?? null;
        }

        public override Weapon Scrap()
        {
            var weapon = new Weapon(GetWeaponClass(), GetWeaponTitle());
            
            string? weaponImageUrl = GetWeaponImageUrl();
            string? hudIconUrl = GetHUDIconUrl();
            string imageUrl = string.Empty;

            if (!string.IsNullOrEmpty(weaponImageUrl))
                imageUrl = weaponImageUrl;
            else if (!string.IsNullOrEmpty(hudIconUrl))
                imageUrl = hudIconUrl;

            weapon.WeaponImageUrl = imageUrl;

            return weapon;
        }
    }
}
