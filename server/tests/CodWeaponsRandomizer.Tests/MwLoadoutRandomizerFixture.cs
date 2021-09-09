using CodWeaponsRandomizer.Core.COD.Mw;

namespace CodWeaponsRandomizer.Tests;

public class MwLoadoutRandomizerFixture
{
    public MwLoadoutRandomizer MwLoadoutRandomizer { get; }
    public MwDb MwDb { get; }

    public MwLoadoutRandomizerFixture()
    {
        MwDb = new MwDb(@"test-dbs\mw");
        MwLoadoutRandomizer = new MwLoadoutRandomizer(MwDb);
    }
}