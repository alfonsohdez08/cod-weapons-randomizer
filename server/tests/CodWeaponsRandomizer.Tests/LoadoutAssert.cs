using CodWeaponsRandomizer.Core.COD;
using CodWeaponsRandomizer.Core.COD.Cw;
using CodWeaponsRandomizer.Core.COD.Mw;
using CodWeaponsRandomizer.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CodWeaponsRandomizer.Tests
{
    public static class LoadoutAssert
    {
        private static readonly MwLoadoutOrdinalWeapons _mwLoadoutOrdinalWeapons;
        private static readonly CwLoadoutOrdinalWeapons _cwLoadoutOrdinalWeapons;

        static LoadoutAssert()
        {
            _mwLoadoutOrdinalWeapons = new MwLoadoutOrdinalWeapons();
            _cwLoadoutOrdinalWeapons = new CwLoadoutOrdinalWeapons();
        }

        public static void IsValidMwLoadout(Loadout loadout, MwDb mwDb, bool assertOverkillPerk)
        {
            IsValidMwLoadout(loadout, mwDb, mwDb.Weapons, _mwLoadoutOrdinalWeapons.PrimaryWeaponTypes, _mwLoadoutOrdinalWeapons.SecondaryWeaponTypes, assertOverkillPerk);
        }

        private static void IsValidMwLoadout(Loadout loadout, MwDb mwDb, List<Weapon> weapons, HashSet<string> primaryWeaponTypes, HashSet<string> secondaryWeaponTypes, bool assertOverkillPerk)
        {
            bool isOverkillPerkSelected = loadout.Perks.Any(p => p.Name == "Overkill");
            AssertPerks(loadout, mwDb, isOverkillPerkSelected, assertOverkillPerk);

            AssertWeapons(loadout, weapons, isOverkillPerkSelected, primaryWeaponTypes, secondaryWeaponTypes);

            Assert.Contains(loadout.Lethal, mwDb.Lethals);
            Assert.Contains(loadout.Tactical, mwDb.Tacticals);
        }

        public static void IsValidWzLoadout(Loadout loadout, MwDb mwDb, CwDb cwDb, bool assertOverkillPerk)
        {
            List<Weapon> warzoneWeapons = mwDb.Weapons.Concat(cwDb.Weapons).ToList();
            HashSet<string> primaryWeaponTypes = _mwLoadoutOrdinalWeapons.PrimaryWeaponTypes.Concat(_cwLoadoutOrdinalWeapons.PrimaryWeaponTypes).ToHashSet();
            HashSet<string> secondaryWeaponTypes = _mwLoadoutOrdinalWeapons.SecondaryWeaponTypes.Concat(_cwLoadoutOrdinalWeapons.SecondaryWeaponTypes).ToHashSet();

            IsValidMwLoadout(loadout, mwDb, warzoneWeapons, primaryWeaponTypes, secondaryWeaponTypes, assertOverkillPerk);
        }

        private static void AssertPerks(Loadout loadout, CodDb mwDb, bool isOverkillPerkSelected, bool assertOverkillPerk)
        {
            Assert.Equal(3, loadout.Perks.Count);
            for (int i = 0; i < loadout.Perks.Count; i++)
            {
                int perkTier = i + 1;
                Assert.Contains(loadout.Perks[i], mwDb.PerkTiers.Single(p => p.Tier == perkTier).Perks);
            }

            if (assertOverkillPerk)
                Assert.True(isOverkillPerkSelected);
        }

        private static void AssertWeapons(Loadout loadout, List<Weapon> weapons, bool isOverkillPerkSelected, HashSet<string> primaryWeaponTypes, HashSet<string> secondaryWeaponTypes)
        {
            WeaponAssert.IsValidWeaponBuild(loadout.PrimaryWeapon, weapons);
            WeaponAssert.IsValidWeaponBuild(loadout.SecondaryWeapon, weapons);

            Assert.Contains(loadout.PrimaryWeapon.Weapon.WeaponType, primaryWeaponTypes);

            if (isOverkillPerkSelected)
                Assert.Contains(loadout.SecondaryWeapon.Weapon.WeaponType, primaryWeaponTypes);
            else
                Assert.Contains(loadout.SecondaryWeapon.Weapon.WeaponType, secondaryWeaponTypes);
        }

        static class WeaponAssert
        {
            public static void IsValidWeaponBuild(WeaponBuild weaponBuild, List<Weapon> weapons)
            {
                Assert.Contains(weaponBuild.Weapon, weapons);

                foreach (AttachmentType attachmentType in weaponBuild.Attachments)
                {
                    Assert.Single(attachmentType.Attachments);
                    Assert.Contains(weaponBuild.Weapon.SupportedAttachments, attch => attch.Id == attachmentType.Id);
                }
            }
        }
    }
}
