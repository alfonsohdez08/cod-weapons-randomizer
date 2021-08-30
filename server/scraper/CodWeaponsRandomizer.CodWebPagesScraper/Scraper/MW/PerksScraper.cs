using AngleSharp.Html.Dom;
using CodWeaponsRandomizer.CodWebPagesScraper.Data;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.MW
{
    class PerksScraper: WebPageComponentScraper<IHtmlTableElement, IEnumerable<PerkTier>>
    {

        public PerksScraper(IHtmlTableElement tableElement): base(tableElement)
        {

        }

        private static IEnumerable<string> ParsePerks(IHtmlTableDataCellElement dataCellElement)
            => dataCellElement.SelectAll<IHtmlAnchorElement>(Html.Tags.Anchor).Select(a => a.Text);

        public override IEnumerable<PerkTier> Scrap()
        {
            var perkTiers = new List<PerkTier>();

            var perkTierDataCells = HtmlElement.SelectAll<IHtmlTableDataCellElement>($"{Html.Tags.TableDataCell}.navbox-group").Take(3).ToList();
            for (int index = 0; index < perkTierDataCells.Count; index++)
            {
                int perkTier = index + 1;
                IEnumerable<string> perks = ParsePerks((IHtmlTableDataCellElement)perkTierDataCells[index].NextElementSibling!);

                perkTiers.Add(new PerkTier(perkTier, perks));
            }

            return perkTiers;
        }
    }
}
