namespace MishMashWebPREP.ViewModels.Channels
{
    using MishMashWebPREP.Models;
    using MishMashWebPREP.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ChannelsDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ChannelType Type { get; set; }

        public string Description { get; set; }

        public IEnumerable<string> Tags { get; set; }

        public string TagsAsString => string.Join(", ", this.Tags);

        public int FollowersCount { get; set; }
    }
}
