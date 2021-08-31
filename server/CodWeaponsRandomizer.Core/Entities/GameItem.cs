namespace CodWeaponsRandomizer.Core.Entities
{
    public class GameItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public GameItem(int id, string name) => (Id, Name) = (id, name);
    }
}
