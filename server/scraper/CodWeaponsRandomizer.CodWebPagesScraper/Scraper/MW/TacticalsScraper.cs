using AngleSharp.Html.Dom;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.MW
{
    class TacticalsScraper : WikiHomePage<IEnumerable<string>>
    {

        private IHtmlTableDataCellElement FindTacticalDataCell()
        {
            const string titleAttributeCondition = "title=\"Tactical\"";
            const string classAttributeCondition = "class=\"mw-disambig\"";
            string anchorAttributeConditions =
                string.Join("", (new string[2] { titleAttributeCondition, classAttributeCondition }).Select(c => $"[{c}]"));            

            return (IHtmlTableDataCellElement)HtmlDocument.SelectFirst<IHtmlAnchorElement>($"{Html.Tags.Anchor}{anchorAttributeConditions}").ParentElement!;
        }

        private static IEnumerable<string> ParseTacticals(IHtmlTableDataCellElement dataCellElement)
            => dataCellElement.SelectAll<IHtmlAnchorElement>(Html.Tags.Anchor).Select(a => a.Text);

        public override IEnumerable<string> Scrap()
        {
            IHtmlTableDataCellElement tacticalDataCellElement = FindTacticalDataCell();

            return ParseTacticals((IHtmlTableDataCellElement)tacticalDataCellElement.NextElementSibling!);
        }
    }
}
