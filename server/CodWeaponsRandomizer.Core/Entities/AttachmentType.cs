namespace CodWeaponsRandomizer.Core.Entities
{
    public class AttachmentType: GameItem
    {
        public List<GameItem> Attachments { get; set; }

        public AttachmentType(int id, string name): base(id, name)
        {
            Attachments = new List<GameItem>();
        }
    }
}
