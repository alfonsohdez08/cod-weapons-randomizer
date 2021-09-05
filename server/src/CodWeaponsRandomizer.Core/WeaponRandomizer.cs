using CodWeaponsRandomizer.Core.Entities;

namespace CodWeaponsRandomizer.Core
{
    class WeaponRandomizer: Randomizer<WeaponHints, WeaponBuild>
    {
        private readonly Dictionary<string, List<Weapon>> _weaponTypes;

        private WeaponHints? _hints;
       
        public WeaponRandomizer(IEnumerable<Weapon> weapons)
        {
            _weaponTypes = weapons.GroupBy(w => w.WeaponType).ToDictionary(g => g.Key, g => g.ToList());
        }


        private string PickWeaponType()
        {
            int index = GenerateRandomIndex(_weaponTypes.Count);
            return _weaponTypes.ElementAt(index).Key;
        }

        private Weapon PickWeapon(string weaponType)
        {
            List<Weapon> weapons = _weaponTypes[weaponType];
            if (_hints?.ExcludedWeapon != null && _hints.ExcludedWeapon.WeaponType == weaponType)// TODO: I should lift this up (it is a loadout thing)
                weapons = weapons.Where(w => w != _hints.ExcludedWeapon).ToList();

            int index = GenerateRandomIndex(weapons.Count);
            return weapons[index];
        }

        private List<AttachmentType> PickAttachments(Weapon weapon)
        {
            int attachmentSlots = _hints!.EnforceUseAllAttachmentSlots ?
                _hints.MaxAttachmentSlots : GenerateRandomNumber(1, _hints.MaxAttachmentSlots + 1);

            var attachmentTypes = new List<AttachmentType>(attachmentSlots);
            foreach (AttachmentType attachmentType in weapon.SupportedAttachments.Shuffle())
            {
                var attachmentTypeCopy = (AttachmentType)attachmentType.Clone();
                attachmentTypeCopy.Attachments.Add(attachmentType.Attachments[GenerateRandomIndex(attachmentType.Attachments.Count)]);

                attachmentTypes.Add(attachmentTypeCopy);
            }

            return attachmentTypes;
        }

        public override WeaponBuild Randomize(WeaponHints? hints)
        {
            _hints = hints;
            try
            {
                string weaponType = PickWeaponType();
                Weapon weapon = PickWeapon(weaponType);
                List<AttachmentType> attachments = PickAttachments(weapon);

                return new WeaponBuild(weapon, attachments);
            }
            finally
            {
                _hints = null;
            }
        }
    }
}
