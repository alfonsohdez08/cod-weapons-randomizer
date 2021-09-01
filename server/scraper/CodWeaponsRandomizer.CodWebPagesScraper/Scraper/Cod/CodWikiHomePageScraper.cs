using AngleSharp.Html.Dom;
using CodWeaponsRandomizer.CodWebPagesScraper.Scraper.Cod.MW;
using CodWeaponsRandomizer.Core.Entities;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.Cod
{
    abstract class CodWikiHomePageScraper: WebPageScraper
    {
        private readonly MwWeaponTableScraper _weaponTableScraper;
        private readonly MwPerkTableScraper _perkTableScraper;

        public CodWikiHomePageScraper(string codWikiHomePageUrl) : base(codWikiHomePageUrl)
        {
            _weaponTableScraper = new MwWeaponTableScraper(GetWeaponsTableElement());
            _perkTableScraper = new MwPerkTableScraper(GetPerksTable());

            IHtmlTableElement GetWeaponsTableElement()
            {
                IHtmlSpanElement weaponSpanElement = HtmlDocument.SelectFirst<IHtmlSpanElement>("#Weapons");
                return weaponSpanElement!.ParentElement!.NextElementSibling!.SelectFirst<IHtmlTableElement>(Html.Tags.Table);
            }

            IHtmlTableElement GetPerksTable()
            {
                var perksHeadingElement = (IHtmlHeadingElement)HtmlDocument.SelectFirst<IHtmlSpanElement>("#Perks_and_Killstreaks").ParentElement!;
                return perksHeadingElement.NextElementSibling!.SelectFirst<IHtmlTableElement>(Html.Tags.Table);
            }
        }

        public List<Weapon> ScrapWeapons() => _weaponTableScraper.ScrapWeapons();

        public List<PerkTier> ScrapPerkTiers() => _perkTableScraper.ScrapPerks();

        public List<GameItem> ScrapLethals() => _weaponTableScraper.ScrapLethals();

        public List<GameItem> ScrapTacticals() => _weaponTableScraper.ScrapTacticals();
    }
}
