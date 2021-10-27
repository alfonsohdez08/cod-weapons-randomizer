using AngleSharp.Html.Dom;
using CodWeaponsRandomizer.Core.Entities;
using System.Collections.Generic;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.Cod
{
    abstract class WikiHomePageScraper: WebPageScraper
    {
        private readonly PerkTableScraper _perkTableScraper;
        private readonly WeaponTableScraper _weaponTableScraper;

        public WikiHomePageScraper(string codWikiHomePageUrl) : base(codWikiHomePageUrl)
        {
            _perkTableScraper = new PerkTableScraper(GetPerksAndScorestreaksTableElement());
            _weaponTableScraper = GetWeaponTableScraper(GetWeaponsTableElement());

            IHtmlTableElement GetWeaponsTableElement()
            {
                IHtmlSpanElement weaponSpanElement = HtmlDocument.SelectFirst<IHtmlSpanElement>("#Weapons");
                return weaponSpanElement!.ParentElement!.NextElementSibling!.SelectFirst<IHtmlTableElement>(Html.Tags.Table);
            }
        }

        protected IHtmlTableElement GetPerksAndScorestreaksTableElement()
        {
            var perksHeadingElement = (IHtmlHeadingElement)HtmlDocument.SelectFirst<IHtmlSpanElement>($"#{PerksScorestreaksSectionId}").ParentElement!;
            return perksHeadingElement.NextElementSibling!.SelectFirst<IHtmlTableElement>(Html.Tags.Table);
        }

        public List<Weapon> ScrapWeapons() => _weaponTableScraper.ScrapWeapons();

        public List<PerkTier> ScrapPerkTiers() => _perkTableScraper.ScrapPerks();

        public List<GameItem> ScrapLethals() => _weaponTableScraper.ScrapLethals();

        public List<GameItem> ScrapTacticals() => _weaponTableScraper.ScrapTacticals();

        protected abstract WeaponTableScraper GetWeaponTableScraper(IHtmlTableElement tableElement);
        protected abstract string PerksScorestreaksSectionId { get; }
    }
}
