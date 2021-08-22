
namespace CodWeaponsRandomizer.Data;
public class WeaponDto: NameDto
{
    public string Category { get; set; }
    public IEnumerable<AttachmentDto> Attachments { get; set; }
}
