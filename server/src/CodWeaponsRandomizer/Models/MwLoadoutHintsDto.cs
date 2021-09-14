
using System.Text.Json.Serialization;

namespace CodWeaponsRandomizer.Models;
public class MwLoadoutHintsDto: LoadoutHintsDto
{
    [JsonPropertyName("enforceUseOverkillPerk")]
    public bool EnforceUseOverkillPerk { get; set; }
}
