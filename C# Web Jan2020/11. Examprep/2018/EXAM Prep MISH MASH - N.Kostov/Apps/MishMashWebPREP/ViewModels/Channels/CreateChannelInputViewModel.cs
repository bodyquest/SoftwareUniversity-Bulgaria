namespace MishMashWebPREP.ViewModels.Channels
{
    using MishMashWebPREP.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CreateChannelInputViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public string Tags { get; set; } 

    }
}
