
namespace CodWeaponsRandomizer.Models;
public class Weapon
{
    public string Name { get; set; }
    public WeaponCategory Category { get; set; }
    public List<AttachmentCategory> Attachments { get; set; }
}
