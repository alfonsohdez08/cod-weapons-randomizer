using AngleSharp.Html.Dom;
using CodWeaponsRandomizer.Core.Entities;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.MW
{
    class PerksScraper: WebPageComponentScraper<IHtmlTableElement, List<PerkTier>>
    {
        public PerksScraper(IHtmlTableElement tableElement): base(tableElement)
        {

        }

        private static List<GameItem> ParsePerks(IHtmlTableDataCellElement dataCellElement)
        {
            var perkSet = new Set<GameItem>();

            IEnumerable<GameItem> perks = dataCellElement.SelectAll<IHtmlAnchorElement>(Html.Tags.Anchor).Select(a => new GameItem(a.Text));
            foreach (GameItem perk in perks)
                perkSet.Add(perk);

            return perkSet.ToList();
        }

        public override List<PerkTier> Scrap()
        {
            var perkTiers = new List<PerkTier>();

            var perkTierDataCells = HtmlElement.SelectAll<IHtmlTableDataCellElement>($"{Html.Tags.TableDataCell}.navbox-group").Take(3).ToList();
            for (var index = 0; index < perkTierDataCells.Count; index++)
            {
                var perkTier = index + 1;
                List<GameItem> perks = ParsePerks((IHtmlTableDataCellElement)perkTierDataCells[index].NextElementSibling!);

                perkTiers.Add(new PerkTier(perkTier) { Perks = perks});
            }

            return perkTiers;
        }
    }
}
