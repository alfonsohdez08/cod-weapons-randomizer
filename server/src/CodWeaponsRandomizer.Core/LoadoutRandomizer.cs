using CodWeaponsRandomizer.Core.Entities;

namespace CodWeaponsRandomizer.Core
{
    public abstract class LoadoutRandomizer: Randomizer<LoadoutHints, Loadout>
    {
        public override Loadout Randomize(LoadoutHints? hints)
        {
            List<Weapon> weapons = GetWeapons();

            throw new NotImplementedException();
        }

        public abstract List<Weapon> GetWeapons();

    }
}
