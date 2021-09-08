using CodWeaponsRandomizer.Core.COD;
using CodWeaponsRandomizer.Core.COD.Cw;
using CodWeaponsRandomizer.Core.COD.Mw;
using CodWeaponsRandomizer.Core.Entities;
using Xunit;

namespace CodWeaponsRandomizer.Tests
{
    public static class LoadoutAssert
    {
        private static readonly MwLoadoutOrdinalWeapons _mwLoadoutOrdinalWeapons;

        static LoadoutAssert()
        {
            _mwLoadoutOrdinalWeapons = new MwLoadoutOrdinalWeapons();
        }

        public static void IsValidMwLoadout(Loadout loadout, MwDb mwDb, bool assertOverkill)
        {
            Assert.Equal(3, loadout.Perks.Count);
            for (int i = 0; i < loadout.Perks.Count; i++)
            {
                int perkTier = i + 1;
                Assert.Contains(loadout.Perks[i], mwDb.PerkTiers.Single(p => p.Tier == perkTier).Perks);
            }

            WeaponAssert.IsValidWeaponBuild(loadout.PrimaryWeapon, mwDb);
            WeaponAssert.IsValidWeaponBuild(loadout.SecondaryWeapon, mwDb);

            Assert.Contains(loadout.PrimaryWeapon.Weapon.WeaponType, _mwLoadoutOrdinalWeapons.PrimaryWeaponTypes);

            bool isOverkillPerkSelected = loadout.Perks.Any(p => p.Name == "Overkill");
            if (assertOverkill)
                Assert.True(isOverkillPerkSelected);

            if (isOverkillPerkSelected)
                Assert.Contains(loadout.SecondaryWeapon.Weapon.WeaponType, _mwLoadoutOrdinalWeapons.PrimaryWeaponTypes);
            else
                Assert.Contains(loadout.SecondaryWeapon.Weapon.WeaponType, _mwLoadoutOrdinalWeapons.SecondaryWeaponTypes);

            Assert.Contains(loadout.Lethal, mwDb.Lethals);
            Assert.Contains(loadout.Tactical, mwDb.Tacticals);
        }

        public static void IsValidWzLoadout(Loadout loadout, MwDb mwDb, CwDb cwDb)
        {

        }


        static class WeaponAssert
        {
            public static void IsValidWeaponBuild(WeaponBuild weaponBuild, CodDb mwDb)
            {
                Assert.Contains(weaponBuild.Weapon, mwDb.Weapons);

                foreach (AttachmentType attachmentType in weaponBuild.Attachments)
                {
                    Assert.Single(attachmentType.Attachments);
                    Assert.Contains(weaponBuild.Weapon.SupportedAttachments, attch => attch.Id == attachmentType.Id);
                }
            }
        }
    }
}
