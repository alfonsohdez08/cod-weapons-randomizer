namespace CodWeaponsRandomizer.Core.COD.Cw
{
    internal class CwLoadoutOrdinalWeapons : LoadoutOrdinalWeapons
    {
        private readonly HashSet<string> _primaryWeaponTypes;
        private readonly HashSet<string> _secondaryWeaponTypes;

        public override HashSet<string> PrimaryWeaponTypes => _primaryWeaponTypes;

        public override HashSet<string> SecondaryWeaponTypes => _secondaryWeaponTypes;

        public CwLoadoutOrdinalWeapons()
        {
            _primaryWeaponTypes = HashSetHelper.ParseSet("Assault Rifle", "Submachine Gun", "Sniper Rifle", "Tactical Rifle", "Shotgun", "Light Machine Gun");
            _secondaryWeaponTypes = HashSetHelper.ParseSet("Pistol", "Launcher", "Melee");
        }
    }
}
