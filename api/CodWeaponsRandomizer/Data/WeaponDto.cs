
namespace CodWeaponsRandomizer.Data;
public class WeaponDto: NameDto
{
    public IEnumerable<AttachmentDto> Attachments { get; set; }
}
