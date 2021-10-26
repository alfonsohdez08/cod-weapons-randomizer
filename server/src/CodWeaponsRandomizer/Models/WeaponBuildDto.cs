
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CodWeaponsRandomizer.Models;
public class WeaponBuildDto: IdNameDto
{
    [JsonPropertyName("weaponType")]
    public string WeaponType { get; set; }

    [JsonPropertyName("imageServerPath")]
    public string ImageServerPath { get; set; }

    [JsonPropertyName("attachments")]
    public List<AttachmentDto> Attachments { get; set; }
} 
