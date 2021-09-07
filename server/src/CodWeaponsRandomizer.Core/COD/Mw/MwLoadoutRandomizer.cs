using CodWeaponsRandomizer.Core.Entities;

namespace CodWeaponsRandomizer.Core.COD.Mw
{
    public class MwLoadoutRandomizer : IwLoadoutRandomizer<MwLoadoutHints>
    {
        public MwLoadoutRandomizer(MwDb db) : base(db)
        {
        }
    }
}
