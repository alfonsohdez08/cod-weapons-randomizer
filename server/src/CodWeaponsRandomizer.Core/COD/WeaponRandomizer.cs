using CodWeaponsRandomizer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodWeaponsRandomizer.Core.COD
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

            int index = GenerateRandomIndex(weapons.Count);
            return weapons[index];
        }

        private List<AttachmentType> PickAttachments(Weapon weapon)
        {
            if (!weapon.SupportedAttachments.Any())
                return new List<AttachmentType>();

            int maxSupportedAttachments = Math.Min(weapon.SupportedAttachments.Count, _hints!.MaxAttachmentSlots);
            int attachmentSlots = _hints!.EnforceUseAllAttachmentSlots ?
                maxSupportedAttachments : GenerateRandomNumber(1, maxSupportedAttachments + 1);

            var attachmentTypes = new List<AttachmentType>(attachmentSlots);

            List<AttachmentType> weaponAttachments = weapon.SupportedAttachments.Shuffle().ToList();
            for (int i = 0; i < attachmentTypes.Capacity; i++)
            {
                AttachmentType attachmentType = weaponAttachments[i];

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
