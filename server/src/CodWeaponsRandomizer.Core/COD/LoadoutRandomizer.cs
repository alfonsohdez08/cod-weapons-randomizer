using CodWeaponsRandomizer.Core.COD.Mw;
using CodWeaponsRandomizer.Core.COD.Wz;
using CodWeaponsRandomizer.Core.Entities;

namespace CodWeaponsRandomizer.Core.COD
{
    public class LoadoutRandomizer: Randomizer<LoadoutHints, Loadout>
    {
        private readonly MwLoadoutRandomizer _mwLoadoutRandomizer;
        private readonly WzLoadoutRandomizer _wzLoadoutRandomizer;

        public LoadoutRandomizer(MwLoadoutRandomizer mwLoadoutRandomizer, WzLoadoutRandomizer wzLoadoutRandomizer)
        {
            _mwLoadoutRandomizer = mwLoadoutRandomizer;
            _wzLoadoutRandomizer = wzLoadoutRandomizer;
        }

        public override Loadout Randomize(LoadoutHints hints)
        {
            Loadout loadout;

            switch (hints) // case order matters
            {
                case WzLoadoutHints wzLoadoutHints:
                    loadout = _wzLoadoutRandomizer.Randomize(wzLoadoutHints);
                    break;
                case MwLoadoutHints mwLoadoutHints:
                    loadout = _mwLoadoutRandomizer.Randomize(mwLoadoutHints);
                    break;
                default:
                    throw new NotSupportedException();
            }

            return loadout;
        }
    }
}
