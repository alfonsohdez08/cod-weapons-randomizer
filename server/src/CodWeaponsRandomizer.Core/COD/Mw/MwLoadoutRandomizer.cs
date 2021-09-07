using CodWeaponsRandomizer.Core.Entities;

namespace CodWeaponsRandomizer.Core.COD.Mw
{
    public class MwLoadoutRandomizer: Randomizer<MwLoadoutHints, Loadout>
    {
        private readonly Func<GameItem, bool> _filterInOverkillPerk = (g) => g.Name == "Overkill";

        private readonly MwDb _db;
        private readonly string[] _mwPrimaryWeaponTypes = new string[] { "Assault Rifle", "Submachine Gun", "Sniper Rifle", "Marksman Rifle", "Shotgun" };

        protected readonly List<Weapon> MwPrimaryWeapons;
        protected readonly List<Weapon> MwSecondaryWeapons;

        protected virtual List<Weapon> PrimaryWeapons => MwPrimaryWeapons;
        protected virtual List<Weapon> SecondaryWeapons => MwSecondaryWeapons;

        protected MwLoadoutHints? Hints;

        public MwLoadoutRandomizer(MwDb db)
        {
            _db = db;

            (List<Weapon> primaryWeapons, List<Weapon> secondaryWeapons) = GetWeapons();

            MwPrimaryWeapons = primaryWeapons;
            MwSecondaryWeapons = secondaryWeapons;

            (List<Weapon> primaryWeapons, List<Weapon> secondaryWeapons) GetWeapons()
            {
                var primaryWeaponTypeSet = new HashSet<string>(_mwPrimaryWeaponTypes);

                List<Weapon> primaryWeapons = _db.Weapons.Where(w => primaryWeaponTypeSet.Contains(w.WeaponType)).ToList();

                Weapon riotShield = db.Weapons.Single(w => w.Name == "Riot Shield");
                primaryWeapons.Add(riotShield);

                List<Weapon> secondaryWeapons = _db.Weapons.Where(w => !primaryWeaponTypeSet.Contains(w.WeaponType)).ToList();
                secondaryWeapons.Remove(riotShield);

                return (primaryWeapons, secondaryWeapons);
            }
        }

        public override Loadout Randomize(MwLoadoutHints? hints)
        {
            Hints = hints;
            try
            {
                List<GameItem> perks = PickPerks();
                (WeaponBuild primaryWeapon, WeaponBuild secondaryWeapon) = PickWeapons(perks.Any(_filterInOverkillPerk));
                GameItem tactical = PickTactical();
                GameItem lethal = PickLethal();

                return new Loadout(primaryWeapon, secondaryWeapon, perks, tactical, lethal);
            }
            finally
            {
                Hints = null;
            }
            throw new NotImplementedException();
        }

        private GameItem PickLethal() => _db.Lethals[GenerateRandomIndex(_db.Lethals.Count)];

        private GameItem PickTactical() => _db.Tacticals[GenerateRandomIndex(_db.Tacticals.Count)];

        private List<GameItem> PickPerks()
        {
            var perks = new List<GameItem>(3);

            foreach (PerkTier perkTier in _db.PerkTiers)
            {
                GameItem perk;
                if (perkTier.Tier == 2 && Hints != null && Hints.EnforceUseOverkillPerk)
                    perk = perkTier.Perks.Single(_filterInOverkillPerk);
                else
                    perk = perkTier.Perks[GenerateRandomIndex(perkTier.Perks.Count)];

                perks.Add(perk);
            }

            return perks;
        }

        private (WeaponBuild primaryWeapon, WeaponBuild secondaryWeapon) PickWeapons(bool hasOverkillPerk)
        {
            var weaponHints = new WeaponHints()
            {
                MaxAttachmentSlots = 5,
                EnforceUseAllAttachmentSlots = Hints != null && Hints.EnforceUseAllWeaponAttachmentSlots
            };

            var primaryWeaponRandomizer = new WeaponRandomizer(PrimaryWeapons);
            WeaponBuild primaryWeaponBuild = primaryWeaponRandomizer.Randomize(weaponHints);

            List<Weapon> secondaryWeapons = hasOverkillPerk ? PrimaryWeapons.Where(w => w != primaryWeaponBuild.Weapon).ToList() : SecondaryWeapons;

            var secondaryWeaponRandomizer = new WeaponRandomizer(secondaryWeapons);
            WeaponBuild secondaryWeaponBuild = secondaryWeaponRandomizer.Randomize(weaponHints);

            return (primaryWeaponBuild, secondaryWeaponBuild);
        }
    }
}
