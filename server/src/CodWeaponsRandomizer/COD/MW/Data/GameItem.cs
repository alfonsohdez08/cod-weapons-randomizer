
using System.Text.Json.Serialization;

namespace CodWeaponsRandomizer.COD.MW.Data;
public class GameItem
{
    [JsonInclude]
    public string Name { get; protected set; }
}
