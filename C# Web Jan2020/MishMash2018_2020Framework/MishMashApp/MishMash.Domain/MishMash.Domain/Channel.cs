namespace MishMash.Domain
{
    using System.Collections.Generic;

    using MishMash.Domain.Enums;

    public class Channel
    {
        public Channel()
        {
            this.Followers = new HashSet<User>();
            this.Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ChannelType Type { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<User> Followers { get; set; }
    }
}
