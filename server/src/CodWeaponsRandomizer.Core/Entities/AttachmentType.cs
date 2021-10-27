using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CodWeaponsRandomizer.Core.Entities
{
    public class AttachmentType: GameItem, ICloneable
    {
        [JsonInclude]
        public List<GameItem> Attachments { get; private set; }

        public AttachmentType(string name, List<GameItem> attachments): base(name)
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
