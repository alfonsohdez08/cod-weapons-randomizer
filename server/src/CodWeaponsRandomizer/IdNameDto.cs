
using System.Text.Json.Serialization;

namespace CodWeaponsRandomizer;
public class IdNameDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }
}
