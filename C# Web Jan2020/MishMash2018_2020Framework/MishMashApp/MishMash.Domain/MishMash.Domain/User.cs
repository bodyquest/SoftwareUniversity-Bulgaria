namespace MishMash.Domain
{
    using System;
    using System.Collections.Generic;

    using MishMash.Domain.Enums;
    using SIS.MvcFramework;

    public class User : IdentityUser<string>
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Channels = new HashSet<UserChannel>();
        }

        public virtual ICollection<UserChannel> Channels { get; set; }

    }
}
