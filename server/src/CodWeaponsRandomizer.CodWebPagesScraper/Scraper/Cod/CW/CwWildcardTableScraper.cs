using AngleSharp.Html.Dom;
using CodWeaponsRandomizer.Core.Entities;
using System.Collections.Generic;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.Cod.CW
{
    class CwWildcardTableScraper : TableScraper
    {

        public CwWildcardTableScraper(IHtmlTableElement tableElement): base(tableElement)
        {

        }

        public List<GameItem> ScrapWildcards() => ParseAnchors(GetSingleRowAnchors(9));
    }
}
