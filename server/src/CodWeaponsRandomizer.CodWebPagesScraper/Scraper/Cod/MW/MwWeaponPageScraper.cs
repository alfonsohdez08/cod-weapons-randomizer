namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.Cod.MW
{
    class MwWeaponPageScraper : WeaponPageScraper
    {
        public MwWeaponPageScraper(string weaponWikiPage) : base(weaponWikiPage)
        {
        }

        public override string CodGameElementId => "Call_of_Duty:_Modern_Warfare";
    }
}
