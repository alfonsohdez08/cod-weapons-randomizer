namespace CodWeaponsRandomizer.Core.Entities
{
    public class Weapon: GameItem
    {
        public string WeaponType { get; set; }
        public string? ImageUrl { get; set; }
        public List<AttachmentType> SupportedAttachments { get; set; }

        public Weapon(string weaponType, string name) : base(name)
        {
            WeaponType = weaponType;
            SupportedAttachments = new List<AttachmentType>();
        }
    }
}