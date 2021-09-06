using CodWeaponsRandomizer.Core.Entities;

namespace CodWeaponsRandomizer.Core
{
    class WzLoadoutRandomizer : LoadoutRandomizer
    {
        private readonly MwDb _mwDb;
        private readonly CwDb _cwDb;

        public WzLoadoutRandomizer(MwDb mwDb, CwDb cwDb)
        {
            _mwDb = mwDb;
            _cwDb = cwDb;
        }

        public override List<Weapon> GetWeapons()
        {
            throw new NotImplementedException();
        }
    }
}
