using System.Collections.Generic;

namespace CodWeaponsRandomizer.Core.COD
{
    internal abstract class LoadoutOrdinalWeapons
    {
        public abstract HashSet<string> PrimaryWeaponTypes { get; }
        public abstract HashSet<string> SecondaryWeaponTypes { get; }
    }
}
