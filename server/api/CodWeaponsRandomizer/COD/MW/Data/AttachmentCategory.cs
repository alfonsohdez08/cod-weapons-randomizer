
using System.Text.Json.Serialization;

namespace CodWeaponsRandomizer.COD.MW.Data;
public class AttachmentCategory: GameItem
{
    [JsonInclude]
    public List<Attachment> Attachments { get; private set; }
}
