using CodWeaponsRandomizer.CodWebPagesScraper.Scraper.Cod;
using CodWeaponsRandomizer.Core.Entities;
using System.Text.Json;

namespace CodWeaponsRandomizer.CodWebPagesScraper
{
    abstract class CodDbExporter
    {
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        private readonly List<Weapon> _weapons;
        private readonly List<PerkTier> _perkTiers;
        private readonly List<GameItem> _tacticals;
        private readonly List<GameItem> _lethals;

        private string _dbExportPath = string.Empty;

        public CodDbExporter(WikiHomePageScraper codWikiHomePageScraper)
        {
            _jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
//#if DEBUG
//            _jsonSerializerOptions.WriteIndented = true;
//#endif
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
            ExportWeapons();
            Export("perks.json", _perkTiers);
            Export("tacticals.json", _tacticals);
            Export("lethals.json", _lethals);
        }

        private void ExportWeapons()
        {
            /* TODO: think a better solution to the images exporting
                This is a code smell because this method has a side effect: export images and update weapons collection to add the filename.
                The fact that updates the weapon collection should be explicit.
             */
            ExportWeaponImages();
            Export("weapons.json", _weapons);

            void ExportWeaponImages()
            {
                string weaponImagesFolder = $"{ExportRootFolder}_weapon_images";
                string weaponImagesFolderPath = Path.Combine(_dbExportPath, weaponImagesFolder);
                if (!Directory.Exists(weaponImagesFolderPath))
                    Directory.CreateDirectory(weaponImagesFolderPath);

                using var httpClient = new HttpClient();

                foreach (Weapon weapon in _weapons.Where(w => !string.IsNullOrEmpty(w.ImageUrl)))
                {
                    string weaponImageFilename = ParseImageFilename(weapon);
                    DownloadImage(httpClient, weapon.ImageUrl!, Path.Combine(weaponImagesFolderPath, weaponImageFilename));

                    weapon.ImageRelativePath = $"{weaponImagesFolder}/{weaponImageFilename}";
                }
            }

            static void DownloadImage(HttpClient httpClient, string url, string fullImagePath)
            {
                HttpResponseMessage responseMessage = httpClient.GetAsync(url).Result;
                byte[] content = responseMessage.Content.ReadAsByteArrayAsync().Result;

                File.WriteAllBytes(fullImagePath, content);
            }

            static string ParseImageFilename(Weapon weapon) => $"wt_{weapon.WeaponType.Replace(" ", "").ToLower()}_wid_{weapon.Id}.webp";
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
