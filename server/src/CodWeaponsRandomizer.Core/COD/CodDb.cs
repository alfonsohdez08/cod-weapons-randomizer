using CodWeaponsRandomizer.Core.Entities;
using System.IO;
using System.Text.Json;

namespace CodWeaponsRandomizer.Core.COD
{
    public abstract class CodDb
    {
        protected string DbPath { get; }

        public List<Weapon> Weapons { get; }
        public List<GameItem> Lethals { get; }
        public List<GameItem> Tacticals { get; }
        public List<PerkTier> PerkTiers { get; }

        public CodDb(string path)
        {
            DbPath = path;

            Weapons = Load<List<Weapon>>("weapons.json");
            Lethals = Load<List<GameItem>>("lethals.json");
            Tacticals = Load<List<GameItem>>("tacticals.json");
            PerkTiers = Load<List<PerkTier>>("perks.json");
        }

        protected T Load<T>(string filename) where T:class
        {
            string jsonFilePath = Path.Combine(DbPath, filename);
            return JsonSerializer.Deserialize<T>(jsonFilePath)!;
        }
    }
}
