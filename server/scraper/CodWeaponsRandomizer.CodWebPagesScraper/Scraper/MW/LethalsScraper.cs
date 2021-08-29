using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.MW
{
    class LethalsScraper : WikiHomePage<IEnumerable<string>>
    {

        private IHtmlTableDataCellElement FindLethalDataCellElement()
        {
            const string titleAttributeCondition = "title=\"Lethal\"";
            const string classAttributeCondition = "class=\"mw-redirect\"";
            string anchorAttributeConditions =
                string.Join("", (new string[2] { titleAttributeCondition, classAttributeCondition }).Select(c => $"[{c}]"));

            return (IHtmlTableDataCellElement)HtmlDocument.SelectFirst<IHtmlAnchorElement>($"{Html.Tags.Anchor}{anchorAttributeConditions}").ParentElement!;
        }

        private static IEnumerable<string> ParseLethals(IHtmlTableDataCellElement dataCellElement)
            => dataCellElement.SelectAll<IHtmlAnchorElement>(Html.Tags.Anchor).Select(a => a.Text);

        public override IEnumerable<string> Scrap()
        {
            IHtmlTableDataCellElement tacticalDataCellElement = FindLethalDataCellElement();

            return ParseLethals((IHtmlTableDataCellElement)tacticalDataCellElement.NextElementSibling!);
        }
    }
}
