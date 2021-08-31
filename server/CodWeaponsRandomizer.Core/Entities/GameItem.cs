namespace CodWeaponsRandomizer.Core.Entities
{
    public class GameItem
    {
        public int Id { get; private set; }
        public string Name { get; set; }

        public GameItem(string name) => (Name) = (name);

        public void SetId(int id) => Id = id;
    }
}
