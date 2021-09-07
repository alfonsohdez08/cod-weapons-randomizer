
using System.Text.Json.Serialization;

namespace CodWeaponsRandomizer;
public class LoadoutHintsDto
{
    [JsonPropertyName("enforceUseAllWeaponAttachmentSlots")]
    public bool EnforceUseAllWeaponAttachmentSlots { get; set; }
}
