using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Data
{
    class PerkTier
    {
        public int Tier { get; set; }
        public IEnumerable<string> Perks { get; set; }

        public PerkTier(int tier, IEnumerable<string> perks) => (Tier, Perks) = (tier, perks);
    }
}
