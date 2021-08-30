using CodWeaponsRandomizer.CodWebPagesScraper.Data;
using CodWeaponsRandomizer.CodWebPagesScraper.Scraper.MW;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper
{
    class CodMwDatabase : ICodDatabase
    {
        private readonly IEnumerable<Weapon> _weapons;
        private readonly IEnumerable<PerkTier> _perkTiers;
        private readonly IEnumerable<string> _tacticals;
        private readonly IEnumerable<string> _lethals;

        public string FolderName => "mw";

        public CodMwDatabase()
        {
            _weapons = new WeaponsScraper().Scrap();
            _perkTiers = new PerksScraper().Scrap();
            _tacticals = new TacticalsScraper().Scrap();
            _lethals = new LethalsScraper().Scrap();
        }

        public void Export(string folderPath)
        {

        }
    }
}
