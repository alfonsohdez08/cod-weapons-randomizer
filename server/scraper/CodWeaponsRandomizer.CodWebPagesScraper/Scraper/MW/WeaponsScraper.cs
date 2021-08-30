﻿using AngleSharp.Html.Dom;
using CodWeaponsRandomizer.CodWebPagesScraper.Data;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.MW
{
    class WeaponsScraper : WebPageComponentScraper<IHtmlTableElement, IEnumerable<Weapon>>
    {
        public WeaponsScraper(IHtmlTableElement tableElement) : base(tableElement)
        {
        }

        private IEnumerable<string> GetWeaponWikiLinks() => new WeaponLinksScraper(HtmlElement).Scrap();

        private static Weapon ScrapWeapon(string weaponWikiLink) => new WeaponWikiPageScraper(weaponWikiLink).ScrapWeapon();

        public override IEnumerable<Weapon> Scrap()
        {  
            var weapons = new List<Weapon>();

            foreach (string weaponWikiLink in GetWeaponWikiLinks())
                weapons.Add(ScrapWeapon(weaponWikiLink));

            return weapons;
        }
    }
}
