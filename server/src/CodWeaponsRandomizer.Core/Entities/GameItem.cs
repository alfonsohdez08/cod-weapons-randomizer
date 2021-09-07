using System.Text.Json.Serialization;

namespace CodWeaponsRandomizer.Core.Entities
{
    public class GameItem
    {
        [JsonInclude]
        public int Id { get; private set; }

        [JsonInclude]
        public string Name { get; private set; }

        public GameItem(string name) => (Name) = (name);

        public void SetId(int id) => Id = id;
    }
}
