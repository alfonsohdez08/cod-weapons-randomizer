using System.Collections.Generic;

namespace CodWeaponsRandomizer.Core.COD.Mw
{
    internal class MwLoadoutOrdinalWeapons : LoadoutOrdinalWeapons
    {
        private readonly HashSet<string> _primaryWeaponTypes;
        private readonly HashSet<string> _secondaryWeaponTypes;

        public override HashSet<string> PrimaryWeaponTypes => _primaryWeaponTypes;
        public override HashSet<string> SecondaryWeaponTypes => _secondaryWeaponTypes;

        public MwLoadoutOrdinalWeapons()
        {
            _primaryWeaponTypes = HashSetHelper.ParseSet("Assault Rifle", "Submachine Gun", "Sniper Rifle", "Marksman Rifle", "Shotgun", "Light Machine Gun", "Melee");
            _secondaryWeaponTypes = HashSetHelper.ParseSet("Handgun", "Launcher", "Melee");
        }
    }
}