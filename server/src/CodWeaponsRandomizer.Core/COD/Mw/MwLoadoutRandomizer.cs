using CodWeaponsRandomizer.Core.Entities;

namespace CodWeaponsRandomizer.Core.COD.Mw
{
    class MwLoadoutRandomizer : LoadoutRandomizer<MwLoadoutHints>
    {
        private readonly MwDb _db;

        public MwLoadoutRandomizer(MwDb db)
        {
            _db = db;
        }

        public override GameItem PickLethal()
        {
            throw new NotImplementedException();
        }

        public override List<PerkTier> PickPerks()
        {
            throw new NotImplementedException();
        }

        public override GameItem PickTactical()
        {
            throw new NotImplementedException();
        }

        public override (WeaponBuild primaryWeapon, WeaponBuild secondaryWeapon) PickWeapons(List<PerkTier> selectedPerks)
        {
            throw new NotImplementedException();
        }
    }
}
