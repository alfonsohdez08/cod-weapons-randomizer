
using CodWeaponsRandomizer.Models;
using System.Text.Json;

namespace CodWeaponsRandomizer;
public class MwDb
{
    public List<WeaponCategory> Weapons { get; private set; }
    public List<PerkSlot> Perks { get; private set;  }
    public List<Tactical> Tacticals { get; private set; }
    public List<Lethal> Lethals { get; private set; }

    private readonly string _rootPath;

    private MwDb(string rootPath)
    {
        _rootPath = rootPath;
        LoadDb();
    }

    private void LoadDb()
    {
        Weapons = LoadWeapons();
        Perks = LoadPerks();
        Tacticals = LoadTacticals();
        Lethals = LoadLethals();
    }

    private T Load<T>(string file)
    {
        using (var jsonStream = File.OpenRead(Path.Combine(_rootPath, file)))
        {
            return JsonSerializer.Deserialize<T>(jsonStream);
        }
    }

    private List<WeaponCategory> LoadWeapons() => Load<List<WeaponCategory>>("weapons.json");

    private List<PerkSlot> LoadPerks() => Load<List<PerkSlot>>("perks.json");

    private List<Tactical> LoadTacticals() => Load<List<Tactical>>("tacticals.json");

    private List<Lethal> LoadLethals() => Load<List<Lethal>>("lethals.json");

    public static MwDb Load(string path)
    {
        return new MwDb(path);
    }
}
