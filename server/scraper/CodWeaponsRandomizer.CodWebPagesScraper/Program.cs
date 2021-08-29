// See https://aka.ms/new-console-template for more information

using CodWeaponsRandomizer.CodWebPagesScraper.Scraper.MW;
using System.Text.Json;

Console.ForegroundColor = ConsoleColor.Green;

var weapons = new WeaponsScraper().Scrap();

#if DEBUG
Console.WriteLine($"Obtained {weapons.Count()} from Cod MW 2019.");

string weaponsJson = JsonSerializer.Serialize(weapons, new JsonSerializerOptions()
{
    WriteIndented = true
});

const string weaponsJsonFilePath = @".\weapons.json";
if (File.Exists(weaponsJsonFilePath))
    File.Delete(weaponsJsonFilePath);

File.WriteAllText(@".\weapons.json", weaponsJson);

#endif

return 0;