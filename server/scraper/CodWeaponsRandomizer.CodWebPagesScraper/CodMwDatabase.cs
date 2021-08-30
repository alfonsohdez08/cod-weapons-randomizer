using CodWeaponsRandomizer.CodWebPagesScraper.Data;
using CodWeaponsRandomizer.CodWebPagesScraper.Scraper.MW;
using System.Text.Json;

namespace CodWeaponsRandomizer.CodWebPagesScraper
{
    class CodMwDatabase : ICodDatabase
    {
        private readonly IEnumerable<Weapon> _weapons;
        private readonly IEnumerable<PerkTier> _perkTiers;
        private readonly IEnumerable<string> _tacticals;
        private readonly IEnumerable<string> _lethals;

        private readonly JsonSerializerOptions _jsonSerializerOptions;

        private string _dbExportPath = string.Empty;

        public string FolderName => "mw";

        public CodMwDatabase()
        {
            _weapons = new WeaponsScraper().Scrap();
            _perkTiers = new PerksScraper().Scrap();
            _tacticals = new TacticalsScraper().Scrap();
            _lethals = new LethalsScraper().Scrap();

            _jsonSerializerOptions = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
        }

        public void Export(string path)
        {
            _dbExportPath = Path.Combine(path, FolderName);
            try
            {
                CreateFolderIfNotExists();

                Export("weapons.json", _weapons);
                Export("perkTiers.json", _perkTiers);
                Export("tacticals.json", _tacticals);
                Export("lethals.json", _lethals);
            }
            finally
            {
                _dbExportPath = string.Empty;
            }
        }

        private void CreateFolderIfNotExists()
        {
            if (Directory.Exists(_dbExportPath))
                return;

            Directory.CreateDirectory(_dbExportPath);
        }

        private void Export<T>(string filename, T data) where T: class
        {
            string path = Path.Combine(_dbExportPath, filename);
            string json = JsonSerializer.Serialize(data, _jsonSerializerOptions);

            if (File.Exists(path))
                File.Delete(path);

            File.WriteAllText(path, json);
        }
    }
}
