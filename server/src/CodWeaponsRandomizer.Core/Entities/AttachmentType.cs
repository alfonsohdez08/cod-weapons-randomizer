using System.Text.Json.Serialization;

namespace CodWeaponsRandomizer.Core.Entities
{
    public class AttachmentType: GameItem, ICloneable
    {
        public List<GameItem> Attachments { get; set; } = new List<GameItem>();

        public AttachmentType(string name): base(name)
        {
        }

        [JsonConstructor]
        public AttachmentType(int id, string name, List<GameItem> attachments) : base(id, name)
        {
            Attachments = attachments;
        }

        public object Clone()
        {
            var attachmentType = (AttachmentType)this.MemberwiseClone();
            attachmentType.Attachments = new List<GameItem>();

            return attachmentType;
        }
    }
}
