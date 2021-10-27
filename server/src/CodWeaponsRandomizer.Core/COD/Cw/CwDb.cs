using CodWeaponsRandomizer.Core.Entities;
using System.Collections.Generic;

namespace CodWeaponsRandomizer.Core.COD.Cw
{
    public class CwDb : CodDb
    {
        public List<GameItem> Wildcards { get; }

        public CwDb(string path) : base(path)
        {
            Wildcards = Load<List<GameItem>>("wildcards.json");
        }
    }
}
