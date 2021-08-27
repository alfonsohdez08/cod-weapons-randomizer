namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.CoDWikiFandom
{
    class CodMwWeaponDetailsScraper : WebPageScraper<Weapon>
    {
        public CodMwWeaponDetailsScraper(string weaponWikiPage): base(weaponWikiPage)
        {

        }

        public override Weapon Scrap()
        {
            throw new NotImplementedException();
        }
    }
}
