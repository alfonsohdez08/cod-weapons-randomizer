using CodWeaponsRandomizer.Core.COD.Cw;
using CodWeaponsRandomizer.Core.COD.Mw;
using CodWeaponsRandomizer.Core.Entities;

namespace CodWeaponsRandomizer.Core.COD.Wz
{

    public class WzLoadoutRandomizer : MwBaseLoadoutRandomizer<WzLoadoutHints>
    {
        private readonly CwDb _cwDb;
        private readonly CwLoadoutOrdinalWeapon _cwLoadoutOrdinalWeapon;

        public WzLoadoutRandomizer(MwDb mwDb, CwDb cwDb) : base(mwDb)
        {
            _cwDb = cwDb;
            _cwLoadoutOrdinalWeapon = new CwLoadoutOrdinalWeapon();
        }

        protected override List<Weapon> GetPrimaryWeapons()
        {
            List<Weapon> mwPrimaryWeapons = base.GetPrimaryWeapons();
            List<Weapon> cwPrimaryWeapons = _cwDb.Weapons.Where(w => _cwLoadoutOrdinalWeapon.PrimaryWeaponTypes.Contains(w.WeaponType)).ToList();

            return mwPrimaryWeapons.Concat(cwPrimaryWeapons).ToList();
        }

        protected override List<Weapon> GetSecondaryWeapons()
        {
            List<Weapon> mwSecondaryWeapons = base.GetSecondaryWeapons();
            List<Weapon> cwSecondaryWeapons = _cwDb.Weapons.Where(w => _cwLoadoutOrdinalWeapon.SecondaryWeaponTypes.Contains(w.WeaponType)).ToList();

            return mwSecondaryWeapons.Concat(cwSecondaryWeapons).ToList();
        }
    }
}
