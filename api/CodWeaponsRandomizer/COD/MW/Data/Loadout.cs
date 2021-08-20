
namespace CodWeaponsRandomizer.COD.MW.Data;
public class Loadout
{
    public CustomWeaponBuild PrimaryWeapon { get; set; }
    public CustomWeaponBuild SecondaryWeapon { get; set; }
    public List<Perk> Perks { get; set; }
    public string Tactical { get; set; }
    public string Lethal { get; set; }
}
