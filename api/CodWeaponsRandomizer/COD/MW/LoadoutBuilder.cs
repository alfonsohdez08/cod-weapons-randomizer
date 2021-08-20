
using CodWeaponsRandomizer.COD.MW.Data;

namespace CodWeaponsRandomizer.COD.MW;
public class LoadoutBuilder
{
    private readonly MwDb _mwDb;
    private readonly Random _random;

    private LoadoutHints _hints;

    public LoadoutBuilder(MwDb mwDb)
    {
        _mwDb = mwDb;
        _random = new Random();
    }

    public Loadout Build(LoadoutHints hints = null)
    {
        _hints = hints;
        // Select primary weapon category

        // Based on the primary weapon category, select a weapon

        // Based on a weapon selected, calculate how many different attachments you would put in your weapon (maximum 5),
        // list the attachment categories and for each category selected, pick an arbitrary attachment

        // Whoola! Your build is done. Make sure you to filter out this weapon, so can't be selected in the same loadout

        var primaryWeaponBuild = GetWeaponBuild(true);
        var secondaryWeaponBuild = GetWeaponBuild(false);
        var perks = GetPerks();

        var lethal = GetLethal();
        var tactical = GetTactical();

        return new Loadout()
        {
            PrimaryWeapon = primaryWeaponBuild,
            SecondaryWeapon = secondaryWeaponBuild,
            Perks = perks,
            Lethal = lethal,
            Tactical = tactical
        };
    }

    private string GetLethal()
    {
        return "";
    }

    private string GetTactical()
    {
        return "";
    }

    private List<Perk> GetPerks()
    {
        throw new Exception();
    }

    private CustomWeaponBuild GetWeaponBuild(bool isForPrimaryUsage)
    {
        var weaponCategory = GetWeaponCategory(isForPrimaryUsage);
        var weapon = GetWeapon(weaponCategory);
        var attachments = GetAttachments(weapon);

        return new CustomWeaponBuild(weapon, attachments);
    }

    private List<Attachment> GetAttachments(Weapon weapon)
    {
        throw new Exception();
    }

    private Weapon GetWeapon(WeaponCategory weaponCategory) => weaponCategory.Weapons[GenerateRandomIndex(weaponCategory.Weapons.Count)];

    private WeaponCategory GetWeaponCategory(bool isForPrimaryUsage)
    {
        var weaponCategories = _mwDb.Weapons.Where(w => w.IsForPrimaryUsage == isForPrimaryUsage).ToList();

        return weaponCategories[GenerateRandomIndex(weaponCategories.Count)];
    }

    //private List<Attachment> GetAttachments(Weapon weapon)
    //{
    //    const int maxAttachments = 5;
    //    int attachmentCount =
    //        _hints != null & _hints.EnforceAllAttachmentSlots ? maxAttachments : (GenerateRandomIndex(maxAttachments) + 1);

    //    List<int> attachmentCategories = Enumerable.Range(0, weapon.Gunsmith.Count).ToList();
        
    //    var attachments = new List<Attachment>(attachmentCount);
    //    for (var index = 0; index < attachments.Count; index++)
    //    {
    //        var attachmentCategory = GetAttachmentCategory(weapon, attachmentCategories);
    //        var attachment = GetAttachment(attachmentCategory.attachmentCategory);

    //        attachments.Add(attachment);

    //        attachmentCategories.RemoveAt(attachmentCategory.index);
    //    }

    //    return attachments;
    //}

    //private (int index, AttachmentCategory attachmentCategory) GetAttachmentCategory(Weapon weapon, List<int> attachmentCategories)
    //{
    //    var idx = GenerateRandomIndex(attachmentCategories.Count);

    //    return (idx, weapon.Gunsmith[idx]);
    //}

    //private Attachment GetAttachment(AttachmentCategory category)
    //{
    //    var index = GenerateRandomIndex(category.Attachments.Count);

    //    return category.Attachments[index];
    //}

    //private Weapon GetWeapon(WeaponCategory weaponCategory)
    //{
    //    int index = GenerateRandomIndex(_mwDb.Weapons.Count);

    //    return null;
    //    //return weaponCategory.Weapons[index];
    //}

    //private WeaponCategory GetWeaponCategory()
    //{
    //    int index = GenerateRandomIndex(_mwDb.Weapons.Count);

    //    return _mwDb.Weapons[index];
    //}

    private int GenerateRandomIndex(int end) => _random.Next(0, end);
}
