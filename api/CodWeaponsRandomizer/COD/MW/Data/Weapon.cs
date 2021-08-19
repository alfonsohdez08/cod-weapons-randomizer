
namespace CodWeaponsRandomizer.COD.MW.Data;
public class Weapon: GameItem
{
    public WeaponCategory Category { get; set; }
    public List<AttachmentCategory> Gunsmith { get; set; }
}
