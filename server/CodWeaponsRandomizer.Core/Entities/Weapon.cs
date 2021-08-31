namespace CodWeaponsRandomizer.Core.Entities
{
    public class Weapon: GameItem
    {
        public List<AttachmentType> SupportedAttachments { get; set; }

        public Weapon(int id, string name) : base(id, name)
        {
            SupportedAttachments = new List<AttachmentType>();
        }
    }
}