using CodWeaponsRandomizer.Core.Entities;

namespace CodWeaponsRandomizer.CodWebPagesScraper
{
    class Set<T> where T: GameItem
    {
        private readonly List<T> _set;

        public Set()
        {
            _set = new List<T>();
        }
        private int GenerateId() => _set.Count + 1;

        public T Add(T item)
        {
            Add(GenerateId(), item);
            return item;
        }

        private void Add(int id, T item)
        {
            item.Id = id;
            _set.Add(item);
        }

        public List<T> ToList() => _set;
    }
}
