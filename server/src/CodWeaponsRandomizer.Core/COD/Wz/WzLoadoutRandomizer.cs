using CodWeaponsRandomizer.Core.COD.Cw;
using CodWeaponsRandomizer.Core.COD.Mw;
using CodWeaponsRandomizer.Core.Entities;

namespace CodWeaponsRandomizer.Core.COD.Wz
{

    public class WzLoadoutRandomizer : MwLoadoutRandomizer
    {
        private readonly List<Weapon> _primaryWeapons;
        private readonly List<Weapon> _secondaryWeapons;

        protected override List<Weapon> PrimaryWeapons => _primaryWeapons;
        protected override List<Weapon> SecondaryWeapons => _secondaryWeapons;

        public WzLoadoutRandomizer(MwDb mwDb, CwDb cwDb) : base(mwDb)
        {
            _primaryWeapons = new List<Weapon>(MwPrimaryWeapons);

            _secondaryWeapons = new List<Weapon>(MwSecondaryWeapons);

        }
    }
}
