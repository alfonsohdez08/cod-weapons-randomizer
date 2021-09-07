using System.Text.Json.Serialization;

namespace CodWeaponsRandomizer.Core.Entities
{
    public class Weapon: GameItem
    {
        [JsonInclude]
        public string WeaponType { get; private set; }
        public string? ImageUrl { get; set; }
        public List<AttachmentType> SupportedAttachments { get; set; } = new List<AttachmentType>();

        public Weapon(string weaponType, string name) : base(name)
        {
            WeaponType = weaponType;
        }
    }
}