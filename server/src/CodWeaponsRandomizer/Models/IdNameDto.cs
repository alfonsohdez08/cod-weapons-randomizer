
using System.Text.Json.Serialization;

namespace CodWeaponsRandomizer.Models;
public class IdNameDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }
}
