using AngleSharp.Dom;
using AngleSharp.Html.Dom;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.MW
{
    class WeaponContainerScraper : WebPageElementScraper<IHtmlElement, Weapon>
    {
        public WeaponContainerScraper(IHtmlElement htmlElement): base(htmlElement)
        {

        }

        private static string ParseDataSourceAttribute(string value) => $"data-source=\"{value}\"";

        private string GetWeaponTitle()
        {
            var headingElement = HtmlElement.QuerySelector<IHtmlHeadingElement>($"h2[{ParseDataSourceAttribute("title")}]");
            return headingElement.TextContent;
        }

        private string GetWeaponClass()
        {
            var anchorElement = HtmlElement.QuerySelector<IHtmlAnchorElement>($"div[{ParseDataSourceAttribute("class")}] a");
            return anchorElement.Text;
        }

        private string? GetWeaponImageUrl()
        {
            var imageElement = HtmlElement.QuerySelector<IHtmlImageElement>($"*[{ParseDataSourceAttribute("image")}] img");
            return imageElement?.Source ?? null;
        }

        private string? GetHUDIconUrl()
        {
            var imageElement = HtmlElement.QuerySelector<IHtmlImageElement>($"*[{ParseDataSourceAttribute("HUD")}] img");
            return imageElement?.GetAttribute("data-src") ?? null;
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
