namespace MishMashWebPREP.ViewModels.Home
{
    using MishMashWebPREP.ViewModels.Channels;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LoggedInIndexViewModel
    {
        public string UserRole { get; set; }
        public IEnumerable<BaseChannelViewModel> YourChannels { get; set; }
        public IEnumerable<BaseChannelViewModel> SuggestedChannels { get; set; }
        public IEnumerable<BaseChannelViewModel> SeeOtherChannels { get; set; }
    }
}
