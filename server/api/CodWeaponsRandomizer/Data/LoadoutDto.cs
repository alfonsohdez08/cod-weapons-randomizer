
namespace CodWeaponsRandomizer.Data;
public class LoadoutDto
{
    public WeaponDto PrimaryWeapon { get; set; }
    public WeaponDto SecondaryWeapon { get; set; }
    public IEnumerable<PerkDto> Perks { get; set; }
    public string Tactical { get; set; }
    public string Lethal { get; set; }
}
