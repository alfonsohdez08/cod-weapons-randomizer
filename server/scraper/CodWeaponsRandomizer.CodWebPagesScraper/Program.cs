// See https://aka.ms/new-console-template for more information

using CodWeaponsRandomizer.CodWebPagesScraper.Scraper.CoDWikiFandom;
using System.Text;

var weaponCategories = CodMwWeaponsScraper.ScrapWeapons();

#if DEBUG

static string Stuff(char c, int count)
{
    var sb = new StringBuilder();
    for (int i = 0; i < count; i++)
        sb.Append(c);

    return sb.ToString();
}

const string headers = "WEAPON CATEGORY | WEAPON | WEAPON WIKI PATH"; 
Console.WriteLine(headers);
Console.WriteLine(Stuff('-', headers.Length));

foreach (var category in weaponCategories)
    foreach (var weapon in category.Weapons)
        Console.WriteLine($"{category.Name} | {weapon.Name} | {weapon.WeaponDetailsPagePath}");
#endif

Console.ReadLine();