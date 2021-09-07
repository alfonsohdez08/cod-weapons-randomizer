using CodWeaponsRandomizer.Core.COD.Cw;
using CodWeaponsRandomizer.Core.COD.Mw;
using CodWeaponsRandomizer.Core.Entities;

namespace CodWeaponsRandomizer.Core.COD.Wz
{

    public class WzLoadoutRandomizer : IwLoadoutRandomizer<WzLoadoutHints>
    {
        private readonly CwDb _cwDb;

        private readonly string[] _primaryWeaponTypes = new string[] { "Assault Rifle", "Submachine Gun", "Sniper Rifle", "Tactical Rifle", "Shotgun", "Light Machine Gun" };
        private readonly string[] _secondaryWeaponTypes = new string[] { "Handgun", "Launcher", "Melee" };

        private readonly HashSet<string> _primaryWeaponTypeSet;
        private readonly HashSet<string> _secondaryWeaponTypeSet;

        public WzLoadoutRandomizer(MwDb mwDb, CwDb cwDb) : base(mwDb)
        {
            _cwDb = cwDb;
            _primaryWeaponTypeSet = new HashSet<string>(_primaryWeaponTypes);
            _secondaryWeaponTypeSet = new HashSet<string>(_secondaryWeaponTypes);
        }

        protected override List<Weapon> GetPrimaryWeapons()
        {
            List<Weapon> mwPrimaryWeapons = base.GetPrimaryWeapons();
            List<Weapon> cwPrimaryWeapons = _cwDb.Weapons.Where(w => _primaryWeaponTypeSet.Contains(w.WeaponType)).ToList();

            return mwPrimaryWeapons.Concat(cwPrimaryWeapons).ToList();
        }

        protected override List<Weapon> GetSecondaryWeapons()
        {
            List<Weapon> mwSecondaryWeapons = base.GetSecondaryWeapons();
            List<Weapon> cwSecondaryWeapons = _cwDb.Weapons.Where(w => _secondaryWeaponTypeSet.Contains(w.WeaponType)).ToList();

            return mwSecondaryWeapons.Concat(cwSecondaryWeapons).ToList();
        }
    }
}
