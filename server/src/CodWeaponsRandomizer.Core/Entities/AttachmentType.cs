namespace CodWeaponsRandomizer.Core.Entities
{
    public class AttachmentType: GameItem, ICloneable
    {
        public List<GameItem> Attachments { get; set; }

        public AttachmentType(string name): base(name)
        {
            Attachments = new List<GameItem>();
        }

        public object Clone()
        {
            var attachmentType = (AttachmentType)this.MemberwiseClone();
            attachmentType.Attachments = new List<GameItem>();

            return attachmentType;
        }
    }
}
