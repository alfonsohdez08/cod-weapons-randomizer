using CodWeaponsRandomizer.CodWebPagesScraper.Scraper.MW;
using CodWeaponsRandomizer.Core.Entities;
using System.Text.Json;

namespace CodWeaponsRandomizer.CodWebPagesScraper
{
    class CodMwDatabase : ICodDatabase
    {
        private readonly List<Weapon> _weapons;
        private readonly List<PerkTier> _perkTiers;
        private readonly List<GameItem> _tacticals;
        private readonly List<GameItem> _lethals;

        private readonly JsonSerializerOptions _jsonSerializerOptions;

        private string _dbExportPath = string.Empty;

        public string FolderName => "mw";

        public CodMwDatabase()
        {
            var mwWikiHomePageScraper = new MwWikiHomePage();
            _weapons = mwWikiHomePageScraper.ScrapWeapons();
            _perkTiers = mwWikiHomePageScraper.ScrapPerkTiers();
            _tacticals = mwWikiHomePageScraper.ScrapTacticals();
            _lethals = mwWikiHomePageScraper.ScrapLethals();

            _jsonSerializerOptions = new JsonSerializerOptions()
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
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
