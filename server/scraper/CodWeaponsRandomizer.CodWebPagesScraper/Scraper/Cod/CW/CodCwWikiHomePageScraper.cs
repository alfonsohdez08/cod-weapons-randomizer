namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.Cod.CW
{
    class CodCwWikiHomePageScraper : CodWikiHomePageScraper<CwWeaponTableScraper>
    {
        private const string CwWikiHomePageUrl = "https://callofduty.fandom.com/wiki/Call_of_Duty:_Black_Ops_Cold_War";

        private readonly CwWeaponTableScraper _cwWeaponTableScraper;

        public CodCwWikiHomePageScraper() : base(CwWikiHomePageUrl)
        {
            _cwWeaponTableScraper = new CwWeaponTableScraper(GetWeaponsTableElement());
        }

        protected override CwWeaponTableScraper WeaponScraper => _cwWeaponTableScraper;
    }
}
