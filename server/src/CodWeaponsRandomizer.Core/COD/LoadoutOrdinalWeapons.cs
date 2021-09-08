namespace CodWeaponsRandomizer.Core.COD
{
    internal abstract class LoadoutOrdinalWeapons
    {
        public abstract HashSet<string> PrimaryWeaponTypes { get; }
        public abstract HashSet<string> SecondaryWeaponTypes { get; }

        public static HashSet<string> ParseWeaponTypes(params string[] weaponTypes) => new HashSet<string>(weaponTypes);
    }
}
