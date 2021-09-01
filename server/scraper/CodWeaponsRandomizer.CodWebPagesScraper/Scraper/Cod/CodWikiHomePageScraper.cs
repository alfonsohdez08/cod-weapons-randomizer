using AngleSharp.Html.Dom;
using CodWeaponsRandomizer.CodWebPagesScraper.Scraper.MW;
using CodWeaponsRandomizer.Core.Entities;
using System.Text;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.Cod
{
    abstract class CodWikiHomePageScraper: WebPageScraper
    {
        private readonly WeaponTableScraper _weaponTableScraper;
        private readonly IHtmlTableElement _weaponTableElement;

        public CodWikiHomePageScraper(string codWikiHomePageUrl) : base(codWikiHomePageUrl)
        {
            _weaponTableElement = GetWeaponsTableElement();
            _weaponTableScraper = new WeaponTableScraper(_weaponTableElement);

            IHtmlTableElement GetWeaponsTableElement()
            {
                IHtmlSpanElement weaponSpanElement = HtmlDocument.SelectFirst<IHtmlSpanElement>("#Weapons");
                return weaponSpanElement!.ParentElement!.NextElementSibling!.SelectFirst<IHtmlTableElement>(Html.Tags.Table);
            }
        }

        public List<Weapon> ScrapWeapons() => new WeaponsScraper(_weaponTableElement).Scrap();

        public List<PerkTier> ScrapPerkTiers()
        {
            IHtmlTableElement perksTableElment = GetPerksTable();

            IHtmlTableElement GetPerksTable()
            {
                var perksHeadingElement = (IHtmlHeadingElement)HtmlDocument.SelectFirst<IHtmlSpanElement>("#Perks_and_Killstreaks").ParentElement!;
                return perksHeadingElement.NextElementSibling!.SelectFirst<IHtmlTableElement>(Html.Tags.Table);
            }

            return new PerksScraper(perksTableElment).Scrap();
        }

        public List<GameItem> ScrapLethals() => _weaponTableScraper.ScrapLethals();

        public List<GameItem> ScrapTacticals() => _weaponTableScraper.ScrapTacticals();
    }
}
