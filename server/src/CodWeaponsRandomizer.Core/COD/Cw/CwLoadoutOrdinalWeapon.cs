namespace CodWeaponsRandomizer.Core.COD.Cw
{
    internal class CwLoadoutOrdinalWeapon : LoadoutOrdinalWeapon
    {
        private readonly HashSet<string> _primaryWeaponTypes;
        private readonly HashSet<string> _secondaryWeaponTypes;

        public override HashSet<string> PrimaryWeaponTypes => _primaryWeaponTypes;

        public override HashSet<string> SecondaryWeaponTypes => _secondaryWeaponTypes;

        public CwLoadoutOrdinalWeapon()
        {
            _primaryWeaponTypes = ParseWeaponTypes("Assault Rifle", "Submachine Gun", "Sniper Rifle", "Tactical Rifle", "Shotgun", "Light Machine Gun");
            _secondaryWeaponTypes = ParseWeaponTypes("Handgun", "Launcher", "Melee");
        }
    }
}
