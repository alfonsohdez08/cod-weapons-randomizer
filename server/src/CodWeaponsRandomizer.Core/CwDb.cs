﻿using CodWeaponsRandomizer.Core.Entities;

namespace CodWeaponsRandomizer.Core
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
