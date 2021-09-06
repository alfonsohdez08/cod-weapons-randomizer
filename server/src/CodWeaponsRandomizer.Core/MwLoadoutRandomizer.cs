using CodWeaponsRandomizer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodWeaponsRandomizer.Core
{
    class MwLoadoutRandomizer : LoadoutRandomizer
    {
        private readonly MwDb _db;

        public MwLoadoutRandomizer(MwDb db)
        {
            _db = db;
        }

        public override List<Weapon> GetWeapons()
        {
            throw new NotImplementedException();
        }
    }
}
