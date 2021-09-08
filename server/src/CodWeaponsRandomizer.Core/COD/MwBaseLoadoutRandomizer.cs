using CodWeaponsRandomizer.Core.COD.Mw;
using CodWeaponsRandomizer.Core.Entities;

namespace CodWeaponsRandomizer.Core.COD
{
    public class MwBaseLoadoutRandomizer<THints> : Randomizer<THints, Loadout> where THints : MwLoadoutHints
    {
        private readonly Predicate<GameItem> _isOverkillPerk = (g) => g.Name == "Overkill";
        private readonly Predicate<Weapon> _isRiotShield = (w) => w.Name == "Riot Shield";
        private readonly CodDb _db;
        private readonly MwLoadoutOrdinalWeapons _mwLoadoutOrdinalWeapons;

        protected THints? Hints;

        public MwBaseLoadoutRandomizer(CodDb db)
        {
            _db = db;
            _mwLoadoutOrdinalWeapons = new MwLoadoutOrdinalWeapons();
        }

        public override Loadout Randomize(THints hints)
        {
            Hints = hints;
            try
            {
                List<GameItem> perks = PickPerks();
                WeaponBuild primaryWeapon = PickPrimaryWeapon();
                WeaponBuild secondaryWeapon = perks.Any(p => _isOverkillPerk(p)) ? PickPrimaryWeapon(primaryWeapon.Weapon) : PickSecondaryWeapon();
                GameItem lethal = PickLethal();
                GameItem tactical = PickTactical();

                return new Loadout(primaryWeapon, secondaryWeapon, perks, tactical, lethal);
            }
            finally
            {
                Hints = null;
            }
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
                    perk = perkTier.Perks.Single(p => _isOverkillPerk(p));
                else
                    perk = perkTier.Perks[GenerateRandomIndex(perkTier.Perks.Count)];

                perks.Add(perk);
            }

            return perks;
        }

        protected WeaponBuild RandomizeWeapon(IEnumerable<Weapon> weapons)
        {
            var weaponRandomizer = new WeaponRandomizer(weapons);
            var weaponHints = new WeaponHints()
            {
                MaxAttachmentSlots = 5,
                EnforceUseAllAttachmentSlots = Hints != null && Hints.EnforceUseAllWeaponAttachmentSlots
            };

            return weaponRandomizer.Randomize(weaponHints);
        }

        protected virtual WeaponBuild PickPrimaryWeapon(Weapon? excludedWeapon = null)
        {
            List<Weapon> primaryWeapons = GetPrimaryWeapons();
            if (excludedWeapon != null)
                primaryWeapons = primaryWeapons.Where(w => w != excludedWeapon).ToList();

            return RandomizeWeapon(primaryWeapons);
        }

        protected virtual WeaponBuild PickSecondaryWeapon()
        {
            List<Weapon> secondaryWeapons = GetSecondaryWeapons();
            return RandomizeWeapon(secondaryWeapons);
        }

        protected virtual List<Weapon> GetPrimaryWeapons()
        {
            List<Weapon> primaryWeapons = _db.Weapons.Where(w => _mwLoadoutOrdinalWeapons.PrimaryWeaponTypes.Contains(w.WeaponType)).ToList();
            primaryWeapons.RemoveAll(w => w.WeaponType == "Melee" && !_isRiotShield(w)); // removes all melee weapons except riot shield

            return primaryWeapons;
        }

        protected virtual List<Weapon> GetSecondaryWeapons()
        {
            List<Weapon> secondaryWeapons = _db.Weapons.Where(w => _mwLoadoutOrdinalWeapons.SecondaryWeaponTypes.Contains(w.WeaponType)).ToList();
            secondaryWeapons.RemoveAll(_isRiotShield);

            return secondaryWeapons;
        }
    }
}
