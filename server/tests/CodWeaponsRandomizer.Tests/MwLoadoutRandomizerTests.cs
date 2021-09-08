using CodWeaponsRandomizer.Core.COD.Mw;
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

        LoadoutAssert.IsValidMwLoadout(loadout, _fixture.MwDb, assertOverkill: false);
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

        LoadoutAssert.IsValidMwLoadout(loadout, _fixture.MwDb, assertOverkill: true);
    }

    [Fact]
    public void RandomizeLoadout_ShouldReturnValidLoadout()
    {
        var mwLoadoutHints = new MwLoadoutHints();

        Loadout loadout = _fixture.MwLoadoutRandomizer.Randomize(mwLoadoutHints);

        LoadoutAssert.IsValidMwLoadout(loadout, _fixture.MwDb, assertOverkill: false);
    }
}

public class MwLoadoutRandomizerFixture
{
    public MwLoadoutRandomizer MwLoadoutRandomizer { get; }
    public MwDb MwDb { get; }

    public MwLoadoutRandomizerFixture()
    {
        MwDb = new MwDb(@"test-dbs\mw");
        MwLoadoutRandomizer = new MwLoadoutRandomizer(MwDb);
    }
}