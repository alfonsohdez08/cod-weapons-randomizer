using AngleSharp.Html.Dom;
using CodWeaponsRandomizer.Core.Entities;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.MW
{
    class MwWikiHomePage: WebPageScraper
    {
        private const string MwWikiHomePageUrl = "https://callofduty.fandom.com/wiki/Call_of_Duty:_Modern_Warfare_(2019)";

        public MwWikiHomePage() : base(MwWikiHomePageUrl)
        {
        }

        private IHtmlTableElement FindWeaponsTableElement()
        {
            IHtmlSpanElement weaponSpanElement = HtmlDocument.SelectFirst<IHtmlSpanElement>("#Weapons");
            return weaponSpanElement!.ParentElement!.NextElementSibling!.SelectFirst<IHtmlTableElement>(Html.Tags.Table);
        }

        public IEnumerable<Weapon> ScrapWeapons()
        {
            var weaponsTableElement = FindWeaponsTableElement();
            return new WeaponsScraper(weaponsTableElement).Scrap();
        }

        private IHtmlTableElement FindPerksTable()
        {
            var perksHeadingElement = (IHtmlHeadingElement)HtmlDocument.SelectFirst<IHtmlSpanElement>("#Perks_and_Killstreaks").ParentElement!;
            return perksHeadingElement.NextElementSibling!.SelectFirst<IHtmlTableElement>(Html.Tags.Table);
        }

        public List<PerkTier> ScrapPerkTiers()
        {
            IHtmlTableElement perksTableElment = FindPerksTable();
            return new PerksScraper(perksTableElment).Scrap();
        }

        private IHtmlTableDataCellElement FindTableDataCellElement(string attributeConditions) =>
            (IHtmlTableDataCellElement)HtmlDocument.SelectFirst<IHtmlAnchorElement>($"{Html.Tags.Anchor}{attributeConditions}").ParentElement!;

        public IEnumerable<string> ScrapLethals()
        {
            string attributeConditions = SelectorAttributeConditionsBuilder.Create().Class("mw-redirect").Title("Lethal").Build();
            var lethalsDataCellElement = FindTableDataCellElement(attributeConditions);

            return new GenericAnchorsScraper(lethalsDataCellElement).Scrap();
        }

        public IEnumerable<string> ScrapTacticals()
        {
            string attributeConditions = SelectorAttributeConditionsBuilder.Create().Class("mw-disambig").Title("Tactical").Build();
            var lethalsDataCellElement = FindTableDataCellElement(attributeConditions);

            return new GenericAnchorsScraper(lethalsDataCellElement).Scrap();
        }
    }
}
