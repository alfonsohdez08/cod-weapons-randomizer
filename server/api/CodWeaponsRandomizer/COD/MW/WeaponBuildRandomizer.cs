
using CodWeaponsRandomizer.COD.MW.Data;

namespace CodWeaponsRandomizer.COD.MW;
public class WeaponBuildRandomizer: CodRandomizer
{
    private readonly List<WeaponCategory> _weaponCategories;

    private WeaponCategory _weaponCategory;
    private Weapon _weapon;
    private List<Attachment> _attachments;
    private bool _useAllWeaponAttachments;
    private bool _primaryWeapon;
    private Weapon _excludedWeapon;

    public WeaponBuildRandomizer(MwDb mwDb) => _weaponCategories = mwDb.WeaponCategories;

    public CustomWeaponBuild Randomize(bool forceUseAllWeaponAttachments, bool primaryWeapon, Weapon excludedWeapon = null)
    {
        _useAllWeaponAttachments = forceUseAllWeaponAttachments;
        _primaryWeapon = primaryWeapon;
        _excludedWeapon = excludedWeapon;

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
            _useAllWeaponAttachments = false;
            _primaryWeapon = false;
            _excludedWeapon = null;
        }
    }

    private void PickWeaponCategory()
    {
        Func<WeaponCategory, bool> filterInWeaponCategoriesBasedOnWeaponSelectionOrder;
        if (_primaryWeapon)
            filterInWeaponCategoriesBasedOnWeaponSelectionOrder = w => w.IsForPrimaryUsage;
        else
            filterInWeaponCategoriesBasedOnWeaponSelectionOrder = w => !w.IsForPrimaryUsage;

        var weaponCategories = _weaponCategories.Where(filterInWeaponCategoriesBasedOnWeaponSelectionOrder).ToList();

        _weaponCategory = weaponCategories[GenerateRandomIndex(weaponCategories.Count)];
    }

    private void PickWeapon()
    {
        List<Weapon> weapons =
            _excludedWeapon != null && _excludedWeapon.Category == _weaponCategory ? 
                _weaponCategory.Weapons.Where(w => w != _excludedWeapon).ToList() : _weaponCategory.Weapons;

        _weapon = weapons[GenerateRandomIndex(weapons.Count)];
    }

    private void PickWeaponAttachments()
    {
        const int gameMaxAttachmentSlots = 5;

        if (!_weapon.Gunsmith.Any())
        {
            _attachments = new List<Attachment>();
            return;
        }

        int maxAttachmentSlots = _weapon.Gunsmith.Count < gameMaxAttachmentSlots ? _weapon.Gunsmith.Count : gameMaxAttachmentSlots;
        int attachmentSlots = _useAllWeaponAttachments ? gameMaxAttachmentSlots : GenerateRandomNumber(1, maxAttachmentSlots + 1);
        _attachments = new List<Attachment>(attachmentSlots);

        var attachmentCategories = new List<AttachmentCategory>(_weapon.Gunsmith);
        for (int slot = 1; slot <= attachmentSlots; slot++)
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
