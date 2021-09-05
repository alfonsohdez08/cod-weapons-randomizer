namespace CodWeaponsRandomizer.Core.Entities
{
    public class WeaponHints
    {
        public bool EnforceUseAllAttachmentSlots { get; set; }
        public int MaxAttachmentSlots { get; set; }
        public Weapon? ExcludedWeapon { get; set; }
    }
}
