using AngleSharp.Html.Dom;
using CodWeaponsRandomizer.CodWebPagesScraper.Data;

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

        public IEnumerable<PerkTier> ScrapPerkTiers()
        {
            IHtmlTableElement perksTableElment = FindPerksTable();
            return new PerksScraper(perksTableElment).Scrap();
        }

        private IHtmlTableDataCellElement FindTableDataCellElement(Dictionary<string, string> attributeConditions)
        {
            string selectorAttributeConditions = string.Join("", attributeConditions.Select(kv => $"[{kv.Key}=\"{kv.Value}\"]"));

            return (IHtmlTableDataCellElement)HtmlDocument.SelectFirst<IHtmlAnchorElement>($"{Html.Tags.Anchor}{selectorAttributeConditions}").ParentElement!;
        }

        public IEnumerable<string> ScrapLethals()
        {
            var lethalsDataCellElement = FindTableDataCellElement(new Dictionary<string, string>()
            {
                {"class", "mw-redirect" },
                {"title", "Lethal" },
            });
            return new GenericAnchorsScraper(lethalsDataCellElement).Scrap();
        }

        public IEnumerable<string> ScrapTacticals()
        {
            var lethalsDataCellElement = FindTableDataCellElement(new Dictionary<string, string>()
            {
                {"class", "mw-disambig" },
                {"title", "Tactical" },
            });
            return new GenericAnchorsScraper(lethalsDataCellElement).Scrap();
        }
    }
}
