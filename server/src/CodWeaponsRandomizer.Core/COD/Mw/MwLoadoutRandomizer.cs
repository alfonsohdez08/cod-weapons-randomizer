using CodWeaponsRandomizer.Core.Entities;

namespace CodWeaponsRandomizer.Core.COD.Mw
{
    class MwLoadoutRandomizer : LoadoutRandomizer<MwLoadoutHints>
    {
        private readonly MwDb _db;

        public MwLoadoutRandomizer(MwDb db)
        {
            _db = db;
        }

        public override GameItem PickLethal() => _db.Lethals[GenerateRandomIndex(_db.Lethals.Count)];

        public override List<GameItem> PickPerks()
        {
            var perks = new List<GameItem>(3);

            for (var index = 0; index < perks.Capacity; index++)
            {
                PerkTier perkTier = _db.PerkTiers[index];

                GameItem perk =
                    perkTier.Tier == 2 && Hints!.EnforceUseOverkillPerk ? perkTier.Perks.Single(p => p.Name == "Overkill") :
                    perkTier.Perks[GenerateRandomIndex(perkTier.Perks.Count)];

                perks.Add(perk);
            }

            return perks;
        }

        public override GameItem PickTactical() => _db.Tacticals[GenerateRandomIndex(_db.Tacticals.Count)];

        public override (WeaponBuild primaryWeapon, WeaponBuild secondaryWeapon) PickWeapons(List<GameItem> selectedPerks)
        {

            throw new NotImplementedException();
        }
    }
}
