
using CodWeaponsRandomizer.COD.MW.Data;
using System.Text.Json;

namespace CodWeaponsRandomizer.COD.MW;
public class MwDb
{
    public List<WeaponCategory> Weapons { get; private set; }
    public List<PerkSlot> Perks { get; private set; }
    public List<GameItem> Tacticals { get; private set; }
    public List<GameItem> Lethals { get; private set; }

    private readonly string _rootPath;

    private MwDb(string rootPath)
    {
        _rootPath = rootPath;
        LoadDb();

        UpdateWeaponReferences();
    }

    private void UpdateWeaponReferences()
    {
        foreach (var weaponCategory in Weapons)
        {
            foreach (var weapon in weaponCategory.Weapons)
            {
                weapon.Category = weaponCategory;
                foreach (var attachmentCategory in weapon.Gunsmith)
                {
                    foreach (var attachment in attachmentCategory.Attachments)
                        attachment.Category = attachmentCategory;
                }
            }
        }
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

    private List<GameItem> LoadTacticals() => Load<List<GameItem>>("tacticals.json");

    private List<GameItem> LoadLethals() => Load<List<GameItem>>("lethals.json");

    public static MwDb Load(string path)
    {
        return new MwDb(path);
    }
}
