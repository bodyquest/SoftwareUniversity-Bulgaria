namespace MishMash.Domain
{
    using MishMash.Domain;

    public class ChannelTag
    {
        public int Id { get; set; }

        public virtual Tag Tags { get; set; }
        public int TagId { get; set; }

        public virtual Channel Channel { get; set; }
        public int ChannelId { get; set; }
    }
}
