using AngleSharp.Html.Dom;
using CodWeaponsRandomizer.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.Cod.MW
{
    class MwWeaponTableScraper : WeaponTableScraper
    {
        public override int WeaponRowCount => 19;
        public override int LethalRowNumber => 29;
        public override int TacticalRowNumber => 31;

        public MwWeaponTableScraper(IHtmlTableElement tableElement) : base(tableElement)
        {

        }

        public override List<GameItem> ScrapLethals()
        {
            // Drop two last lethals because they are actually data garbage
            return base.ScrapLethals().SkipLast(2).ToList();
        }

        protected override WeaponPageScraper GetWeaponPageScraper(string weaponHref) => new MwWeaponPageScraper(weaponHref);
    }
}
