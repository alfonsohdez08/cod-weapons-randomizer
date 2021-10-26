using CodWeaponsRandomizer.Core.Entities;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace CodWeaponsRandomizer.Core.COD
{
    public abstract class CodDb
    {
        private readonly string _dbPath;
        private readonly JsonSerializerOptions _deserializerOptions;

        public List<Weapon> Weapons { get; }
        public List<GameItem> Lethals { get; }
        public List<GameItem> Tacticals { get; }
        public List<PerkTier> PerkTiers { get; }

        public CodDb(string path)
        {
            _dbPath = path;
            _deserializerOptions = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };

            Weapons = Load<List<Weapon>>("weapons.json");
            Lethals = Load<List<GameItem>>("lethals.json");
            Tacticals = Load<List<GameItem>>("tacticals.json");
            PerkTiers = Load<List<PerkTier>>("perks.json");
        }

        protected T Load<T>(string filename) where T: class
        {
            string jsonFilePath = Path.Combine(_dbPath, filename);
            string json = File.ReadAllText(jsonFilePath);

            return JsonSerializer.Deserialize<T>(json, _deserializerOptions)!;
        }
    }
}
