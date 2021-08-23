
using CodWeaponsRandomizer.COD.MW.Data;

namespace CodWeaponsRandomizer.COD.MW;
public class LoadoutRandomizer: CodRandomizer
{
    private const string OverkillPerk = "Overkill";

    private readonly MwDb _mwDb;
    private readonly WeaponBuildRandomizer _weaponBuildRandomizer;

    private LoadoutHints _hints;
    private CustomWeaponBuild _primaryWeapon;
    private CustomWeaponBuild _secondaryWeapon;
    private List<Perk> _perks;
    private GameItem _lethal;
    private GameItem _tactical;

    public LoadoutRandomizer(MwDb mwDb, WeaponBuildRandomizer weaponBuildRandomizer)
    {
        _mwDb = mwDb;
        _weaponBuildRandomizer = weaponBuildRandomizer;
    }

    public Loadout Randomize(LoadoutHints hints = null)
    {
        _hints = hints ?? new LoadoutHints();

        try
        {
            PickPerks();

            PickPrimaryWeapon();
            PickSecondaryWeapon();

            PickLethal();
            PickTactical();

            return new Loadout(_primaryWeapon, _secondaryWeapon, _perks, _tactical, _lethal);
        }
        finally
        {
            _primaryWeapon = null;
            _secondaryWeapon = null;
            _perks = null;
            _tactical = null;
            _lethal = null;
            _hints = null;
        }
    }

    private void PickPrimaryWeapon()
    {
        _primaryWeapon = _weaponBuildRandomizer.Randomize(_hints.EnforceUseAllWeaponAttachments, true);
    }

    private void PickSecondaryWeapon()
    {
        bool buildSecondaryWeaponAsAPrimaryOne = IsOverkillPerkSelected();

        _secondaryWeapon = _weaponBuildRandomizer.Randomize(_hints.EnforceUseAllWeaponAttachments, buildSecondaryWeaponAsAPrimaryOne, _primaryWeapon.Weapon);

        bool IsOverkillPerkSelected() => _perks.Single(p => p.Slot.Slot == 2).Name == OverkillPerk;
    }

    private void PickLethal()
    {
        _lethal = _mwDb.Lethals[GenerateRandomIndex(_mwDb.Lethals.Count)];
    }

    private void PickTactical()
    {
        _tactical = _mwDb.Tacticals[GenerateRandomIndex(_mwDb.Tacticals.Count)];
    }

    private void PickPerks()
    {
        const int perksCount = 3;

        _perks = new List<Perk>(perksCount);

        for (int index = 0; index < perksCount; index++)
        {
            var perkSlot = _mwDb.PerkSlots[index];
            Perk perk = index == 1 && _hints.EnforceUseOverkillPerk ? PickOverkillPerk(perkSlot) : PickPerk(perkSlot);

            _perks.Add(perk);
        }


        Perk PickOverkillPerk(PerkSlot perkSlot) => perkSlot.Perks.Single(p => p.Name == OverkillPerk);
    }

    private Perk PickPerk(PerkSlot perkSlot) => perkSlot.Perks[GenerateRandomIndex(perkSlot.Perks.Count)];
}
