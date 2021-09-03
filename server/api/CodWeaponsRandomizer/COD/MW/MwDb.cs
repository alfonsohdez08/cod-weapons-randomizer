
using CodWeaponsRandomizer.COD.MW.Data;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CodWeaponsRandomizer.COD.MW;
public class MwDb
{
    public List<WeaponCategory> WeaponCategories { get; private set; }
    public List<PerkSlot> PerkSlots { get; private set; }
    public List<GameItem> Tacticals { get; private set; }
    public List<GameItem> Lethals { get; private set; }

    private readonly string _rootPath;

    private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions()
    {
        PropertyNameCaseInsensitive = true,
        ReferenceHandler = ReferenceHandler.Preserve
    };

    private MwDb(string rootPath)
    {
        _rootPath = rootPath;
        LoadDb();
    }

    private void LoadDb()
    {
        WeaponCategories = LoadWeaponCategories();
        PerkSlots = LoadPerkSlots();
        Tacticals = LoadTacticals();
        Lethals = LoadLethals();
    }

    private T Load<T>(string file)
    {
        using (var jsonStream = File.OpenRead(Path.Combine(_rootPath, file)))
        {
            return JsonSerializer.Deserialize<T>(jsonStream, _jsonSerializerOptions);
        }
    }

    private List<WeaponCategory> LoadWeaponCategories() => Load<List<WeaponCategory>>("weapons.json");

    private List<PerkSlot> LoadPerkSlots() => Load<List<PerkSlot>>("perks.json");

    private List<GameItem> LoadTacticals() => Load<List<GameItem>>("tacticals.json");

    private List<GameItem> LoadLethals() => Load<List<GameItem>>("lethals.json");

    public static MwDb Load(string path)
    {
        return new MwDb(path);
    }
}
