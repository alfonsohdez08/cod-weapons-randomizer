using CodWeaponsRandomizer.Core.Entities;
using Xunit;

namespace CodWeaponsRandomizer.Tests
{
    public class WzLoadoutRandomizerTests: IClassFixture<WzLoadoutRandomizerFixture>
    {
        private WzLoadoutRandomizerFixture _fixture;

        public WzLoadoutRandomizerTests(WzLoadoutRandomizerFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void RandomizeLoadout_ShouldReturnValidLoadout()
        {
            var wzLoadoutHints = new WzLoadoutHints();

            Loadout loadout = _fixture.WzLoadoutRandomizer.Randomize(wzLoadoutHints);

            LoadoutAssert.IsValidWzLoadout(loadout, _fixture.MwDb, _fixture.CwDb, assertOverkillPerk: false);
        }
    }
}
