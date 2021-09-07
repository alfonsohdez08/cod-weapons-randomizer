namespace CodWeaponsRandomizer.Core.Entities
{
    public class WeaponBuild
    {
        public Weapon Weapon { get; }
        public List<AttachmentType> Attachments { get; }

        public WeaponBuild(Weapon weapon, List<AttachmentType> attachments) => (Weapon, Attachments) = (weapon, attachments);
    }
}
