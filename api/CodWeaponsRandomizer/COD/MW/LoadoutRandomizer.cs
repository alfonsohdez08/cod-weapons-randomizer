
using CodWeaponsRandomizer.COD.MW.Data;

namespace CodWeaponsRandomizer.COD.MW;
public class LoadoutRandomizer: CodRandomizer
{
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

    public Loadout Build(LoadoutHints hints = null)
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
        _primaryWeapon = _weaponBuildRandomizer.Build(_hints.EnforceAllAttachmentSlots, true);
    }

    private void PickSecondaryWeapon()
    {
        bool buildSecondaryWeaponAsPrimary = _hints.EnforceOverkillPerk || _perks.Single(p => p.Slot.Slot == 2).Name == "Overkill";

        _secondaryWeapon = _weaponBuildRandomizer.Build(_hints.EnforceAllAttachmentSlots, buildSecondaryWeaponAsPrimary, _primaryWeapon.Weapon);
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
        _perks = new List<Perk>(3);

        var perkSlots = new List<PerkSlot>(_mwDb.Perks);
        for (int index = 0; index < _perks.Count; index++)
        {
            var perkSlotIndex = GenerateRandomIndex(perkSlots.Count);
            var perkSlot = perkSlots[perkSlotIndex];

            var perk = PickPerk(perkSlot);
            _perks.Add(perk);

            perkSlots.RemoveAt(perkSlotIndex);
        }
    }

    private Perk PickPerk(PerkSlot perkSlot) => perkSlot.Perks[GenerateRandomIndex(perkSlot.Perks.Count)];
}
