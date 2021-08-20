
using System.Text.Json.Serialization;

namespace CodWeaponsRandomizer.COD.MW.Data;
public class Attachment: GameItem
{
    [JsonInclude]
    public AttachmentCategory Category { get; private set; }
}
