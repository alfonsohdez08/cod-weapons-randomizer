
using System.Text.Json.Serialization;

namespace CodWeaponsRandomizer;
public class WeaponBuildDto: IdNameDto
{
    [JsonPropertyName("weaponType")]
    public string WeaponType { get; set; }

    [JsonPropertyName("imageServerPath")]
    public string ImageServerPath { get; set; }

    [JsonPropertyName("attachments")]
    public List<AttachmentDto> Attachments { get; set; }
} 
