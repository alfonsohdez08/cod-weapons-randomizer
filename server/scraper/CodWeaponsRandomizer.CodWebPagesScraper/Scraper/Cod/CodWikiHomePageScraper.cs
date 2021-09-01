using AngleSharp.Html.Dom;
using CodWeaponsRandomizer.CodWebPagesScraper.Scraper.Cod.MW;
using CodWeaponsRandomizer.Core.Entities;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.Cod
{
    abstract class CodWikiHomePageScraper: WebPageScraper
    {
        private readonly MwWeaponTableScraper _weaponTableScraper;

        public CodWikiHomePageScraper(string codWikiHomePageUrl) : base(codWikiHomePageUrl)
        {
            _weaponTableScraper = new MwWeaponTableScraper(GetWeaponsTableElement());

            IHtmlTableElement GetWeaponsTableElement()
            {
                IHtmlSpanElement weaponSpanElement = HtmlDocument.SelectFirst<IHtmlSpanElement>("#Weapons");
                return weaponSpanElement!.ParentElement!.NextElementSibling!.SelectFirst<IHtmlTableElement>(Html.Tags.Table);
            }
        }

        public List<Weapon> ScrapWeapons()
        {
            var weaponSet = new Set<Weapon>();
            foreach (string weaponWikiHref in _weaponTableScraper.ScrapWeaponHrefs())
            {
                var weaponScraper = new WeaponPageScraper(weaponWikiHref);
                
                weaponSet.Add(weaponScraper.ScrapWeapon());
            }

            return weaponSet.ToList();
        }

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
