namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.Cod.CW
{
    class CwWeaponPageScraper : WeaponPageScraper
    {
        public CwWeaponPageScraper(string weaponWikiPage) : base(weaponWikiPage)
        {
        }

        public override string CodGameElementId => "Call_of_Duty:_Black_Ops_Cold_War";
    }
}
