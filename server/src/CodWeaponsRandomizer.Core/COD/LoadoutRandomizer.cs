using CodWeaponsRandomizer.Core.Entities;

namespace CodWeaponsRandomizer.Core.COD
{
    public abstract class LoadoutRandomizer<TLoadoutHints>: Randomizer<TLoadoutHints, Loadout>
        where TLoadoutHints: LoadoutHints
    {
        protected TLoadoutHints? Hints;

        public override Loadout Randomize(TLoadoutHints? hints)
        {
            Hints = hints;
            try
            {
                List<PerkTier> perks = PickPerks();
                (WeaponBuild primaryWeapon, WeaponBuild secondaryWeapon) = PickWeapons(perks);
                GameItem tactical = PickTactical();
                GameItem lethal = PickLethal();

                return new Loadout(primaryWeapon, secondaryWeapon, perks, tactical, lethal);
            }
            finally
            {
                Hints = null;
            }
        }


        public abstract List<PerkTier> PickPerks();
        public abstract (WeaponBuild primaryWeapon, WeaponBuild secondaryWeapon) PickWeapons(List<PerkTier> selectedPerks);
        public abstract GameItem PickLethal();
        public abstract GameItem PickTactical();
    }
}
