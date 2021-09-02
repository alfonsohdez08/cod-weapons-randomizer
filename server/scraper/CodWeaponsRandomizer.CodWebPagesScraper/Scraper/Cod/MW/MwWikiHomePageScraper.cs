namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.Cod.MW
{
    class MwWikiHomePageScraper : CodWikiHomePageScraper<MwWeaponTableScraper>
    {
        private const string MwWikiHomePageUrl = "https://callofduty.fandom.com/wiki/Call_of_Duty:_Modern_Warfare_(2019)";

        private readonly MwWeaponTableScraper _mwWeaponTableScraper;

        public MwWikiHomePageScraper() : base(MwWikiHomePageUrl)
        {
            _mwWeaponTableScraper = new MwWeaponTableScraper(GetWeaponsTableElement());
        }

        protected override MwWeaponTableScraper WeaponScraper => _mwWeaponTableScraper;
    }
}
