
using System.Text.Json.Serialization;

namespace CodWeaponsRandomizer.COD.MW.Data;
public class Perk: GameItem
{
    [JsonInclude]
    public PerkSlot Slot { get; private set; }
}
