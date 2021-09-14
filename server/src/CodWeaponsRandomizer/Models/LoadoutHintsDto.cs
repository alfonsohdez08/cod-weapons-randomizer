
using System.Text.Json.Serialization;

namespace CodWeaponsRandomizer.Models;
public class LoadoutHintsDto
{
    [JsonPropertyName("enforceUseAllWeaponAttachmentSlots")]
    public bool EnforceUseAllWeaponAttachmentSlots { get; set; }
}
