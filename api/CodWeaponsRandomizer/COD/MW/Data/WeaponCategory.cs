
using System.Text.Json.Serialization;

namespace CodWeaponsRandomizer.COD.MW.Data;
public class WeaponCategory: GameItem
{
    [JsonInclude]
    public List<Weapon> Weapons { get; private set; }

    [JsonInclude]
    public bool IsForPrimaryUsage { get; private set; }
}
