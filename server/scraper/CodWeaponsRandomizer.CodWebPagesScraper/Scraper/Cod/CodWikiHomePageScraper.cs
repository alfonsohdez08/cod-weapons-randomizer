using AngleSharp.Html.Dom;
using CodWeaponsRandomizer.CodWebPagesScraper.Scraper.MW;
using CodWeaponsRandomizer.Core.Entities;
using System.Text;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.Cod
{
    abstract class CodWikiHomePageScraper: WebPageScraper
    {

        public CodWikiHomePageScraper(string codWikiHomePageUrl) : base(codWikiHomePageUrl)
        {
        }

        private IHtmlTableElement GetWeaponsTableElement()
        {
            IHtmlSpanElement weaponSpanElement = HtmlDocument.SelectFirst<IHtmlSpanElement>("#Weapons");
            return weaponSpanElement!.ParentElement!.NextElementSibling!.SelectFirst<IHtmlTableElement>(Html.Tags.Table);
        }

        public List<Weapon> ScrapWeapons()
        {
            var weaponsTableElement = GetWeaponsTableElement();
            return new WeaponsScraper(weaponsTableElement).Scrap();
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

        public List<GameItem> ScrapLethals()
        {
            var sb = new StringBuilder()
                .Append("tr:nth-last-child(7)")
                .Append(" > ")
                .Append(Selectors.TableAnchors);

            IHtmlTableElement weaponsTableElement = GetWeaponsTableElement();

            var tacticals = weaponsTableElement.SelectAll<IHtmlAnchorElement>(sb.ToString()).Select(a => new GameItem(a.Text));
            var set = new Set<GameItem>();
            foreach (GameItem tactical in tacticals)
                set.Add(tactical);

            return set.ToList();
        }

        public List<GameItem> ScrapTacticals()
        {
            var sb = new StringBuilder()
                .Append("tr:nth-last-child(5)")
                .Append(" > ")
                .Append(Selectors.TableAnchors);

            IHtmlTableElement weaponsTableElement = GetWeaponsTableElement();

            var tacticals = weaponsTableElement.SelectAll<IHtmlAnchorElement>(sb.ToString()).Select(a => new GameItem(a.Text));
            var set = new Set<GameItem>();
            foreach (GameItem tactical in tacticals)
                set.Add(tactical);

            return set.ToList();
        }
    }
}
