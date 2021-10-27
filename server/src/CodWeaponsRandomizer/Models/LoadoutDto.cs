
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CodWeaponsRandomizer.Models;
public class LoadoutDto
{
    [JsonPropertyName("primaryWeapon")]
    public WeaponBuildDto PrimaryWeapon { get; set; }

    [JsonPropertyName("secondaryWeapon")]
    public WeaponBuildDto SecondaryWeapon { get; set; }

    [JsonPropertyName("perks")]
    public List<IdNameDto> Perks { get; set; }

    [JsonPropertyName("lethal")]
    public IdNameDto Lethal { get; set; }
    
    [JsonPropertyName("tactical")]
    public IdNameDto Tactical { get; set; }
}
