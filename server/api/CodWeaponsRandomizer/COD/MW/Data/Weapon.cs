
using System.Text.Json.Serialization;

namespace CodWeaponsRandomizer.COD.MW.Data;
public class Weapon: GameItem
{
    [JsonInclude]
    public WeaponCategory Category { get; private set; }

    [JsonInclude]
    public List<AttachmentCategory> Gunsmith { get; private set; }
}
