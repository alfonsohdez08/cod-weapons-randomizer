using CodWeaponsRandomizer.CodWebPagesScraper.Scraper.Cod.CW;
using CodWeaponsRandomizer.Core.Entities;
using System.Text.Json;

namespace CodWeaponsRandomizer.CodWebPagesScraper
{
    class CwDatabase : ICodDatabase
    {
        public string FolderName => "cw";

        private readonly List<Weapon> _weapons;
        private readonly List<GameItem> _tacticals;
        private readonly List<GameItem> _lethals;
        private readonly List<PerkTier> _perks;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        private string _dbExportPath = string.Empty;
        public CwDatabase()
        {
            var cwWikiHomePageScraper = new CwWikiHomePageScraper();

            _weapons = cwWikiHomePageScraper.ScrapWeapons();
            _tacticals = cwWikiHomePageScraper.ScrapTacticals();
            _lethals = cwWikiHomePageScraper.ScrapLethals();
            _perks = cwWikiHomePageScraper.ScrapPerkTiers();

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
                Export("tacticals.json", _tacticals);
                Export("lethals.json", _lethals);
                Export("perks.json", _perks);

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

        private void Export<T>(string filename, T data) where T : class
        {
            string path = Path.Combine(_dbExportPath, filename);
            string json = JsonSerializer.Serialize(data, _jsonSerializerOptions);

            if (File.Exists(path))
                File.Delete(path);

            File.WriteAllText(path, json);
        }
    }
}
