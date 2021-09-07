using System.Text.Json.Serialization;

namespace CodWeaponsRandomizer.Core.Entities
{
    public class Weapon: GameItem
    {
        public string WeaponType { get; set; }
        public string? ImageUrl { get; set; }
        public List<AttachmentType> SupportedAttachments { get; set; } = new List<AttachmentType>();

        public Weapon(string weaponType, string name) : base(name)
        {
            WeaponType = weaponType;
        }

        [JsonConstructor]
        public Weapon(int id, string name, string weaponType, string? imageUrl, List<AttachmentType> supportedAttachments) : base(id, name)
        {
            WeaponType = weaponType;
            ImageUrl = imageUrl;
            SupportedAttachments = supportedAttachments;
        }
    }
}