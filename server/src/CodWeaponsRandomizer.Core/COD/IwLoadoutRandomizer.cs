using CodWeaponsRandomizer.Core.Entities;

namespace CodWeaponsRandomizer.Core.COD
{
    public class IwLoadoutRandomizer<THints> : Randomizer<THints, Loadout> where THints : MwLoadoutHints
    {
        private readonly Func<GameItem, bool> _filterInOverkillPerk = (g) => g.Name == "Overkill";
        private readonly Func<Weapon, bool> _filterInRiotShield = (w) => w.Name == "Riot Shield";
        
        private readonly string[] _primaryWeaponTypes = new string[] { "Assault Rifle", "Submachine Gun", "Sniper Rifle", "Marksman Rifle", "Shotgun", "Light Machine Gun" };
        private readonly string[] _secondaryWeaponTypes = new string[] { "Handgun", "Launcher", "Melee" };

        private readonly HashSet<string> _primaryWeaponTypeSet;
        private readonly HashSet<string> _secondaryWeaponTypeSet;

        private readonly CodDb _db;

        protected THints? Hints;

        public IwLoadoutRandomizer(CodDb db)
        {
            _db = db;

            _primaryWeaponTypeSet = new HashSet<string>(_primaryWeaponTypes);
            _secondaryWeaponTypeSet = new HashSet<string>(_secondaryWeaponTypes);
        }

        public override Loadout Randomize(THints hints)
        {
            Hints = hints;
            try
            {
                List<GameItem> perks = PickPerks();
                WeaponBuild primaryWeapon = PickPrimaryWeapon();
                WeaponBuild secondaryWeapon = perks.Any(_filterInOverkillPerk) ? PickPrimaryWeapon(primaryWeapon.Weapon) : PickSecondaryWeapon();
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
                    perk = perkTier.Perks.Single(_filterInOverkillPerk);
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
            List<Weapon> primaryWeapons = _db.Weapons.Where(w => _primaryWeaponTypeSet.Contains(w.WeaponType)).ToList();
            primaryWeapons.Add(_db.Weapons.Single(_filterInRiotShield));

            return primaryWeapons;
        }

        protected virtual List<Weapon> GetSecondaryWeapons()
        {
            List<Weapon> secondaryWeapons = _db.Weapons.Where(w => _secondaryWeaponTypeSet.Contains(w.WeaponType)).ToList();
            secondaryWeapons.Remove(_db.Weapons.Single(_filterInRiotShield));

            return secondaryWeapons;
        }
    }
}
