using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using CodWeaponsRandomizer.CodWebPagesScraper.Data;

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
            var headingElement = HtmlElement.SelectFirst<IHtmlHeadingElement>($"{Html.Tags.Heading2}[{ParseDataSourceAttribute("title")}]");
            return headingElement.TextContent;
        }

        private string GetWeaponClass()
        {
            var anchorElement = HtmlElement.SelectFirst<IHtmlAnchorElement>($"{Html.Tags.Div}[{ParseDataSourceAttribute("class")}] {Html.Tags.Anchor}");
            return anchorElement.Text;
        }

        private string? GetWeaponImageUrl()
        {
            var imageElement = HtmlElement.QuerySelector<IHtmlImageElement>($"*[{ParseDataSourceAttribute("image")}] {Html.Tags.Image}");
            return imageElement?.Source ?? null;
        }

        private string? GetHUDIconUrl()
        {
            var imageElement = HtmlElement.QuerySelector<IHtmlImageElement>($"*[{ParseDataSourceAttribute("HUD")}] {Html.Tags.Image}");
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

            weapon.ImageUrl = imageUrl;

            return weapon;
        }
    }
}
