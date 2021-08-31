namespace CodWeaponsRandomizer.Core.Entities
{
    public class AttachmentType: GameItem
    {
        public List<GameItem> Attachments { get; set; }

        public AttachmentType(string name): base(name)
        {
            Attachments = new List<GameItem>();
        }
    }
}
