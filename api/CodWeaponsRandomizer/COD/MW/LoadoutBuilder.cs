
using CodWeaponsRandomizer.COD.MW.Data;

namespace CodWeaponsRandomizer.COD.MW;
public class LoadoutBuilder
{
    private readonly MwDb _mwDb;
    private readonly Random _random;

    private LoadoutHints _hints;

    private readonly WeaponBuilder _weaponBuilder;

    public LoadoutBuilder(MwDb mwDb, WeaponBuilder weaponBuilder)
    {
        _mwDb = mwDb;
        _random = new Random();
    }

    public Loadout Build(LoadoutHints hints = null)
    {
        _hints = hints;
        // Select primary weapon category

        // Based on the primary weapon category, select a weapon

        // Based on a weapon selected, calculate how many different attachments you would put in your weapon (maximum 5),
        // list the attachment categories and for each category selected, pick an arbitrary attachment

        // Whoola! Your build is done. Make sure you to filter out this weapon, so can't be selected in the same loadout

        var weapons = _mwDb.Weapons;
        bool forceUseAllAttachmentSlots = _hints.EnforceAllAttachmentSlots;

        var primaryWeaponBuild = _weaponBuilder.BuildWeapon(weapons, forceUseAllAttachmentSlots);
        var secondaryWeaponBuild = _weaponBuilder.BuildWeapon(weapons, forceUseAllAttachmentSlots);

        var perks = GetPerks();

        var lethal = GetLethal();
        var tactical = GetTactical();

        return new Loadout()
        {
            PrimaryWeapon = primaryWeaponBuild,
            SecondaryWeapon = secondaryWeaponBuild,
            Perks = perks,
            Lethal = lethal,
            Tactical = tactical
        };
    }

    private string GetLethal()
    {
        return "";
    }

    private string GetTactical()
    {
        return "";
    }

    private List<Perk> GetPerks()
    {
        throw new Exception();
    }

    private int GenerateRandomIndex(int end) => _random.Next(0, end);
}
