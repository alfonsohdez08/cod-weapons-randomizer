
using CodWeaponsRandomizer.Models;

namespace CodWeaponsRandomizer;
public class LoadoutBuilder
{
    private readonly MwDb _db;

    public LoadoutBuilder(MwDb db)
    {
        _db = db;
    }

    public Loadout Build(LoadoutHints hints = null)
    {


        throw new NotImplementedException();
    }
}

public class LoadoutHints
{
    public bool OverkillPerk { get; set; }
    public bool UseAllAttachmentSlots { get; set; }
}
