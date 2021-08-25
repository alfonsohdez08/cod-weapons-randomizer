
namespace CodWeaponsRandomizer.COD.MW.Data;
public class Loadout
{
    public CustomWeaponBuild PrimaryWeapon { get; private set; }
    public CustomWeaponBuild SecondaryWeapon { get; private set; }
    public List<Perk> Perks { get; private set; }
    public GameItem Tactical { get; private set; }
    public GameItem Lethal { get; private set; }

    public Loadout(CustomWeaponBuild primaryWeapon, CustomWeaponBuild secondaryWeapon, List<Perk> perks, GameItem tactical, GameItem lethal)
        => (PrimaryWeapon, SecondaryWeapon, Perks, Tactical, Lethal) = (primaryWeapon, secondaryWeapon, perks, tactical, lethal);
}
