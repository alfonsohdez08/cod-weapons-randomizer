
using System.Collections.ObjectModel;

namespace CodWeaponsRandomizer.COD.MW.Data;
public class CustomWeaponBuild
{
    public Weapon Weapon { get; private set; }
    public ReadOnlyCollection<Attachment> Attachments { get; private set; }

    public CustomWeaponBuild(Weapon weapon, List<Attachment> attachments)
    {
        Weapon = weapon;
        Attachments = attachments.AsReadOnly();
    }
}
