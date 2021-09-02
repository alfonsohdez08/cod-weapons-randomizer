using AngleSharp.Html.Dom;
using CodWeaponsRandomizer.CodWebPagesScraper.Scraper.Cod.MW;
using CodWeaponsRandomizer.Core.Entities;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.Cod
{
    abstract class CodWikiHomePageScraper<TWeaponScraper>: WebPageScraper where TWeaponScraper: WeaponTableScraper
    {
        private readonly MwPerkTableScraper _perkTableScraper;

        public CodWikiHomePageScraper(string codWikiHomePageUrl) : base(codWikiHomePageUrl)
        {
            _perkTableScraper = new MwPerkTableScraper(GetPerksTable());

            IHtmlTableElement GetPerksTable()
            {
                var perksHeadingElement = (IHtmlHeadingElement)HtmlDocument.SelectFirst<IHtmlSpanElement>("#Perks_and_Killstreaks").ParentElement!;
                return perksHeadingElement.NextElementSibling!.SelectFirst<IHtmlTableElement>(Html.Tags.Table);
            }
        }

        protected IHtmlTableElement GetWeaponsTableElement()
        {
            IHtmlSpanElement weaponSpanElement = HtmlDocument.SelectFirst<IHtmlSpanElement>("#Weapons");
            return weaponSpanElement!.ParentElement!.NextElementSibling!.SelectFirst<IHtmlTableElement>(Html.Tags.Table);
        }

        public List<Weapon> ScrapWeapons() => WeaponScraper.ScrapWeapons();

        public List<PerkTier> ScrapPerkTiers() => _perkTableScraper.ScrapPerks();

        public List<GameItem> ScrapLethals() => WeaponScraper.ScrapLethals();

        public List<GameItem> ScrapTacticals() => WeaponScraper.ScrapTacticals();

        protected abstract TWeaponScraper WeaponScraper { get; }
    }
}
