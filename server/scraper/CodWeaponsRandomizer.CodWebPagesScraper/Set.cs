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

        public void AddRange(IEnumerable<T> items)
        {
            foreach (T item in items)
                Add(GenerateId(), item);
        }

        private void Add(int id, T item)
        {
            item.SetId(id);
            _set.Add(item);
        }

        public List<T> ToList() => new List<T>(_set);
    }
}
