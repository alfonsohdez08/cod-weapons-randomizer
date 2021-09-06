namespace CodWeaponsRandomizer.Core.Entities
{
    public class Loadout
    {
        public WeaponBuild PrimaryWeapon { get; }
        public WeaponBuild SecondaryWeapon { get; }
        public List<PerkTier> Perks { get; }
        public GameItem Tactical { get;  }
        public GameItem Lethal { get; }

        public Loadout(WeaponBuild primaryWeapon, WeaponBuild secondaryWeapon, List<PerkTier> perks, GameItem tactical, GameItem lethal)
            => (PrimaryWeapon, SecondaryWeapon, Perks, Tactical, Lethal) = (primaryWeapon, secondaryWeapon, perks, tactical, lethal);
    }
}
