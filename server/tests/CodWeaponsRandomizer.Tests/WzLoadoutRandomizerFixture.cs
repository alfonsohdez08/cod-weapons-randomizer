using CodWeaponsRandomizer.Core.COD.Cw;
using CodWeaponsRandomizer.Core.COD.Mw;
using CodWeaponsRandomizer.Core.COD.Wz;

namespace CodWeaponsRandomizer.Tests
{
    public class WzLoadoutRandomizerFixture
    {
        public WzLoadoutRandomizer WzLoadoutRandomizer { get; }
        public MwDb MwDb { get; }
        public CwDb CwDb { get; }

        public WzLoadoutRandomizerFixture()
        {
            MwDb = new MwDb(@"test-dbs\mw");
            CwDb = new CwDb(@"test-dbs\cw");

            WzLoadoutRandomizer = new WzLoadoutRandomizer(MwDb, CwDb);
        }
    }
}
