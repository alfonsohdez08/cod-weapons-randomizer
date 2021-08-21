
using CodWeaponsRandomizer.COD.MW.Data;

namespace CodWeaponsRandomizer.COD.MW;
public class WeaponBuildRandomizer: CodRandomizer
{
    private readonly List<WeaponCategory> _weaponCategories;

    private WeaponCategory _weaponCategory;
    private Weapon _weapon;
    private List<Attachment> _attachments;
    private bool _useAllAttachmentSlots;
    private bool _primaryWeapon;

    public WeaponBuildRandomizer(MwDb mwDb) => _weaponCategories = mwDb.Weapons;

    public CustomWeaponBuild Build(bool forceUseAllAttachmentSlots, bool primaryWeapon, Weapon weaponExcluded = null)
    {
        _useAllAttachmentSlots = forceUseAllAttachmentSlots;
        _primaryWeapon = primaryWeapon;
        try
        {
            PickWeaponCategory();
            PickWeapon();
            PickWeaponAttachments();

            return new CustomWeaponBuild(_weapon, _attachments);
        }
        finally
        {
            _weaponCategory = null;
            _weapon = null;
            _attachments = null;
            _useAllAttachmentSlots = false;
        }
    }

    private void PickWeaponCategory() => _weaponCategory = _weaponCategories[GenerateRandomIndex(_weaponCategories.Count)];

    private void PickWeapon() => _weapon = _weaponCategory.Weapons[GenerateRandomIndex(_weaponCategory.Weapons.Count)];

    private void PickWeaponAttachments()
    {
        const int maxAttachmentSlots = 5;

        int attachmentSlots = _useAllAttachmentSlots ? maxAttachmentSlots : GenerateRandomNumber(1, maxAttachmentSlots);
        _attachments = new List<Attachment>(attachmentSlots);

        var attachmentCategories = new List<AttachmentCategory>(_weapon.Gunsmith);
        for (int index = 0; index < _attachments.Count; index++)
        {
            var attachmentCategoryIdx = GenerateRandomIndex(attachmentCategories.Count);
            var attachmentCategory = attachmentCategories[attachmentCategoryIdx];

            var attachment = PickAttachment(attachmentCategory);
            _attachments.Add(attachment);

            attachmentCategories.RemoveAt(attachmentCategoryIdx);
        }
    }

    private Attachment PickAttachment(AttachmentCategory attachmentCategory)
        => attachmentCategory.Attachments[GenerateRandomIndex(attachmentCategory.Attachments.Count)];
}
