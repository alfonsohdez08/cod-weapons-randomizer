﻿using AngleSharp.Html.Dom;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.MW
{
    class WeaponWikiLinksScraper : WebPageComponentScraper<IHtmlTableElement, List<string>>
    {
        public WeaponWikiLinksScraper(IHtmlTableElement tableElement) : base(tableElement)
        {
        }

        public override List<string> Scrap()
        {
            var weaponWikiLinks = new List<string>();
            foreach (var weaponCategoryDataCell in GetWeaponCategoryDataCellElements())
                weaponWikiLinks.AddRange(ParseWeaponLinks(weaponCategoryDataCell));

            return weaponWikiLinks;
        }

        private static IEnumerable<string> ParseWeaponLinks(IHtmlTableDataCellElement weaponCategoryDataCell)
            => weaponCategoryDataCell!.NextElementSibling!.SelectAll<IHtmlAnchorElement>(Html.Tags.Anchor).Select(a => a.Href);

        private IEnumerable<IHtmlTableDataCellElement> GetWeaponCategoryDataCellElements()
        {
            foreach (var dataCell in HtmlElement.SelectAll<IHtmlTableDataCellElement>($"{Html.Tags.TableDataCell}.navbox-group"))
            {
                var weaponCategoryAnchor = dataCell.SelectFirst<IHtmlAnchorElement>(Html.Tags.Anchor);
                if (weaponCategoryAnchor.Text == "Special")
                    yield break;

                yield return dataCell;
            }
        }
    }
}
