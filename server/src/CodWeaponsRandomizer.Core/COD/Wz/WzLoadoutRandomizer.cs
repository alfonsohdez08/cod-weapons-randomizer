using CodWeaponsRandomizer.Core.COD.Cw;
using CodWeaponsRandomizer.Core.COD.Mw;
using CodWeaponsRandomizer.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CodWeaponsRandomizer.Core.COD.Wz
{

    public class WzLoadoutRandomizer : MwBaseLoadoutRandomizer<WzLoadoutHints>
    {
        private readonly CwDb _cwDb;
        private readonly CwLoadoutOrdinalWeapons _cwLoadoutOrdinalWeapons;

        public WzLoadoutRandomizer(MwDb mwDb, CwDb cwDb) : base(mwDb)
        {
            _cwDb = cwDb;
            _cwLoadoutOrdinalWeapons = new CwLoadoutOrdinalWeapons();
        }

        protected override List<Weapon> GetPrimaryWeapons()
        {
            List<Weapon> mwPrimaryWeapons = base.GetPrimaryWeapons();
            List<Weapon> cwPrimaryWeapons = _cwDb.Weapons.Where(w => _cwLoadoutOrdinalWeapons.PrimaryWeaponTypes.Contains(w.WeaponType)).ToList();

            return mwPrimaryWeapons.Concat(cwPrimaryWeapons).ToList();
        }

        protected override List<Weapon> GetSecondaryWeapons()
        {
            List<Weapon> mwSecondaryWeapons = base.GetSecondaryWeapons();
            List<Weapon> cwSecondaryWeapons = _cwDb.Weapons.Where(w => _cwLoadoutOrdinalWeapons.SecondaryWeaponTypes.Contains(w.WeaponType)).ToList();

            return mwSecondaryWeapons.Concat(cwSecondaryWeapons).ToList();
        }
    }
}
