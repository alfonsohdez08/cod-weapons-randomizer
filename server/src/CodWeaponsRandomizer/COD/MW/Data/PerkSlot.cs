using System.Text.Json.Serialization;

namespace CodWeaponsRandomizer.COD.MW.Data;
public class PerkSlot
{
    [JsonInclude]
    public int Slot { get; private set; }

    [JsonInclude]
    public List<Perk> Perks { get; private set; }
}
