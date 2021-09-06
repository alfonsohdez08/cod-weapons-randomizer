using CodWeaponsRandomizer.Core.COD.Cw;
using CodWeaponsRandomizer.Core.COD.Mw;
using CodWeaponsRandomizer.Core.Entities;

namespace CodWeaponsRandomizer.Core.COD.Wz
{
    class WzLoadoutRandomizer : LoadoutRandomizer<WzLoadoutHints>
    {
        private readonly MwDb _mwDb;
        private readonly CwDb _cwDb;

        public WzLoadoutRandomizer(MwDb mwDb, CwDb cwDb)
        {
            _mwDb = mwDb;
            _cwDb = cwDb;
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
