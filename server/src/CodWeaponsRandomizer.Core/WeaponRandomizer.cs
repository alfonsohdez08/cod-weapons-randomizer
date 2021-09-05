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

        private void PickAttachments(Weapon weapon)
        {

        }

        public override WeaponBuild Randomize(WeaponHints? hints)
        {
            _hints = hints;
            try
            {
                string weaponType = PickWeaponType();
                Weapon weapon = PickWeapon(weaponType);
                PickAttachments(weapon);
            }
            finally
            {
                _hints = null;
            }

            throw new NotImplementedException();
        }
    }
}
