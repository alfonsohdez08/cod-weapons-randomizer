
using System.Text.Json.Serialization;

namespace CodWeaponsRandomizer.Models;
public class AttachmentDto: IdNameDto
{
    [JsonPropertyName("variant")]
    public IdNameDto Variant { get; set; }
}
