using System.Text.Json.Serialization;

namespace CodWeaponsRandomizer.Core.Entities
{
    public class GameItem
    {
        [JsonInclude]
        public int Id { get; private set; }
        public string Name { get; set; }

        public GameItem(string name) => (Name) = (name);

        [JsonConstructor]
        public GameItem(int id, string name): this(name) => Id = id;

        public void SetId(int id) => Id = id;
    }
}
