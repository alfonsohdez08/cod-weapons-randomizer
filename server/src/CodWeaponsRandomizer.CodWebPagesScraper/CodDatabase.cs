using CodWeaponsRandomizer.CodWebPagesScraper.Scraper.Cod;
using CodWeaponsRandomizer.Core.Entities;
using System.Text.Json;

namespace CodWeaponsRandomizer.CodWebPagesScraper
{
    abstract class CodDatabase
    {
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        private readonly List<Weapon> _weapons;
        private readonly List<PerkTier> _perkTiers;
        private readonly List<GameItem> _tacticals;
        private readonly List<GameItem> _lethals;

        private string _dbExportPath = string.Empty;

        public CodDatabase(WikiHomePageScraper codWikiHomePageScraper)
        {
            _jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
#if DEBUG
            _jsonSerializerOptions.WriteIndented = true;
#endif
            _weapons = codWikiHomePageScraper.ScrapWeapons();
            _perkTiers = codWikiHomePageScraper.ScrapPerkTiers();
            _tacticals = codWikiHomePageScraper.ScrapTacticals();
            _lethals = codWikiHomePageScraper.ScrapLethals();
        }

        private void CreateFolderIfNotExists()
        {
            if (Directory.Exists(_dbExportPath))
                return;

            Directory.CreateDirectory(_dbExportPath);
        }

        protected void Export<T>(string filename, T data) where T: class
        {
            string path = Path.Combine(_dbExportPath, filename);
            string json = JsonSerializer.Serialize(data, _jsonSerializerOptions);

            if (File.Exists(path))
                File.Delete(path);

            File.WriteAllText(path, json);
        }

        protected virtual void Export()
        {
            Export("weapons.json", _weapons);
            Export("perks.json", _perkTiers);
            Export("tacticals.json", _tacticals);
            Export("lethals.json", _lethals);
        }

        public void Export(string path)
        {
            _dbExportPath = Path.Combine(path, ExportRootFolder);
            try
            {
                CreateFolderIfNotExists();
                Export();
            }
            finally
            {
                _dbExportPath = string.Empty;
            }
        }

        protected abstract string ExportRootFolder { get; }
    }
}
