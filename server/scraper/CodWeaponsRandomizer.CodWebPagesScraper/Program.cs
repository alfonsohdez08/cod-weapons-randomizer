// See https://aka.ms/new-console-template for more information

using CodWeaponsRandomizer.CodWebPagesScraper.Scraper.MW;
using System.Text.Json;

Console.ForegroundColor = ConsoleColor.Green;

var weapons = new WeaponsScraper().Scrap();
var perkTiers = new PerksScraper().Scrap();
var tacticals = new TacticalsScraper().Scrap();
var lethals = new LethalsScraper().Scrap();

#if DEBUG
var jsonSerializerOptions = new JsonSerializerOptions()
{
    WriteIndented = true
};

Console.WriteLine($"Obtained {weapons.Count()} weapons from Cod MW 2019.");
string weaponsJson = JsonSerializer.Serialize(weapons, jsonSerializerOptions);
SaveFile("weapons.json", weaponsJson);

Console.WriteLine($"Obtained {perkTiers.Count()} perk tiers from Cod MW 2019.");
string perkTiersJson = JsonSerializer.Serialize(perkTiers, jsonSerializerOptions);
SaveFile("perks.json", perkTiersJson);

Console.WriteLine($"Obtained {tacticals.Count()} tacticals from Cod MW 2019.");
string tacticalsJson = JsonSerializer.Serialize(tacticals, jsonSerializerOptions);
SaveFile("tacticals.json", tacticalsJson);

Console.WriteLine($"Obtained {lethals.Count()} lethals from Cod MW 2019.");
string lethalsJson = JsonSerializer.Serialize(lethals, jsonSerializerOptions);
SaveFile("lethals.json", lethalsJson);

static void SaveFile(string filename, string fileContent)
{
    string filepath = $".\\{filename}";

    if (File.Exists(filepath))
        File.Delete(filepath);

    File.WriteAllText(filepath, fileContent);
}
#endif

return 0;