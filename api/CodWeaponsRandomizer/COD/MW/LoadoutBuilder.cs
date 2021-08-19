
using CodWeaponsRandomizer.COD.MW.Data;

namespace CodWeaponsRandomizer.COD.MW;
public class LoadoutBuilder
{
    private readonly MwDb _mwDb;

    public LoadoutBuilder(MwDb mwDb)
    {
        _mwDb = mwDb;
    }

    public Loadout Build(LoadoutHints hints = null)
    {
        throw new NotImplementedException();
    }
}
