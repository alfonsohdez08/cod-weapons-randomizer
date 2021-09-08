namespace CodWeaponsRandomizer.Core.COD.Mw
{
    internal class MwLoadoutOrdinalWeapon : LoadoutOrdinalWeapon
    {
        private readonly HashSet<string> _primaryWeaponTypes;
        private readonly HashSet<string> _secondaryWeaponTypes;

        public override HashSet<string> PrimaryWeaponTypes => _primaryWeaponTypes;
        public override HashSet<string> SecondaryWeaponTypes => _secondaryWeaponTypes;

        public MwLoadoutOrdinalWeapon()
        {
            _primaryWeaponTypes = ParseWeaponTypes("Assault Rifle", "Submachine Gun", "Sniper Rifle", "Marksman Rifle", "Shotgun", "Light Machine Gun", "Melee");
            _secondaryWeaponTypes = ParseWeaponTypes("Handgun", "Launcher", "Melee");
        }
    }
}