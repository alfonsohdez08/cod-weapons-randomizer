
using CodWeaponsRandomizer.COD.MW.Data;

namespace CodWeaponsRandomizer.COD.MW;
public class WeaponBuilder: GameItemBuilder
{
    public CustomWeaponBuild BuildWeapon(List<WeaponCategory> weapons, bool forceUseAllAttachmentSlots)
    {
        var weaponCategory = GetWeaponCategory(weapons);
        var weapon = GetWeapon(weaponCategory);
        var attachments = GetWeaponAttachments(weapon, forceUseAllAttachmentSlots);

        return new CustomWeaponBuild(weapon, attachments);
    }

    private WeaponCategory GetWeaponCategory(List<WeaponCategory> weapons) => weapons[GenerateRandomIndex(weapons.Count)];

    private Weapon GetWeapon(WeaponCategory weaponCategory) => weaponCategory.Weapons[GenerateRandomIndex(weaponCategory.Weapons.Count)];

    private List<Attachment> GetWeaponAttachments(Weapon weapon, bool forceUseAllAttachmentSlots)
    {
        const int maxAttachmentSlots = 5;

        int attachmentSlots = forceUseAllAttachmentSlots ? maxAttachmentSlots : GenerateRandomNumber(1, maxAttachmentSlots);
        var attachments = new List<Attachment>(attachmentSlots);

        var attachmentCategories = new List<AttachmentCategory>(weapon.Gunsmith);
        for (int index = 0; index < attachments.Count; index++)
        {
            var attachmentCategoryIdx = GenerateRandomIndex(attachmentCategories.Count);
            var attachmentCategory = attachmentCategories[attachmentCategoryIdx];

            var attachment = GetAttachment(attachmentCategory);
            attachments.Add(attachment);

            attachmentCategories.RemoveAt(attachmentCategoryIdx);
        }

        return attachments;
    }

    private Attachment GetAttachment(AttachmentCategory attachmentCategory)
        => attachmentCategory.Attachments[GenerateRandomIndex(attachmentCategory.Attachments.Count)];
}
