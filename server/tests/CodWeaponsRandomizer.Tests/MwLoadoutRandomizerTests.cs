using CodWeaponsRandomizer.Core.Entities;
using Xunit;

namespace CodWeaponsRandomizer.Tests;
public class MwLoadoutRandomizerTests: IClassFixture<MwLoadoutRandomizerFixture>
{
    private MwLoadoutRandomizerFixture _fixture;

    public MwLoadoutRandomizerTests(MwLoadoutRandomizerFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void RandomizeLoadout_EnforceUseAllWeaponAttachmentSlots_ShouldReturnLoadoutWhereWeaponsUseAllAttachmentSlots()
    {
        var mwLoadoutHints = new MwLoadoutHints()
        {
            EnforceUseAllWeaponAttachmentSlots = true,
            EnforceUseOverkillPerk = false
        };

        Loadout loadout = _fixture.MwLoadoutRandomizer.Randomize(mwLoadoutHints);

        LoadoutAssert.IsValidMwLoadout(loadout, _fixture.MwDb, assertOverkillPerk: false);
    }

    [Fact]
    public void RandomizeLoadout_EnforceUseOverkillPerk_ShouldReturnLoadoutThatHasTwoPrimaryWeaponsAndOverkillPerkSelected()
    {
        var mwLoadoutHints = new MwLoadoutHints()
        {
            EnforceUseAllWeaponAttachmentSlots = false,
            EnforceUseOverkillPerk = true
        };

        Loadout loadout = _fixture.MwLoadoutRandomizer.Randomize(mwLoadoutHints);

        LoadoutAssert.IsValidMwLoadout(loadout, _fixture.MwDb, assertOverkillPerk: true);
    }

    [Fact]
    public void RandomizeLoadout_ShouldReturnValidLoadout()
    {
        var mwLoadoutHints = new MwLoadoutHints();

        Loadout loadout = _fixture.MwLoadoutRandomizer.Randomize(mwLoadoutHints);

        LoadoutAssert.IsValidMwLoadout(loadout, _fixture.MwDb, assertOverkillPerk: false);
    }
}
