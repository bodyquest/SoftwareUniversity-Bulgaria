namespace MishMashWebPREP.Controllers
{
    using MishMashWebPREP.ViewModels.Channels;
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ChannelsController :BaseController
    {
        [Authorize]
        public IHttpResponse Details(int id)
        {
            var viewModel = this.Context.Channels
                            .Select(x => new ChannelsDetailsViewModel
                            {
                                Id = x.Id,
                                Name = x.Name,
                                Type = x.Type,
                                Description = x.Description,
                                Tags = x.Tags.Select(t => t.Tag.Name),
                                FollowersCount = x.Followers.Count()
                            })
                            .FirstOrDefault(x => x.Id == id);

            if (viewModel == null)
            {
                return this.BadRequestErrorWithView("Invalid Channel id.");
            }

            return this.View("Channels/Details", viewModel);
        }

        [Authorize]
        public IHttpResponse Followed()
        {
            var followedChannels = this.Context.Channels.Where(x => x.Followers.Any(f => f.User.Username == this.User.Username))
                .Select(x => new FollowedChannelViewModel
                {
                    Id = x.Id,
                    Type = x.Type,
                    Name = x.Name,
                    FollowersCount = x.Followers.Count()
                }).ToList();

            var model = new AllFollowedChannelsViewModel { FollowedChannels = followedChannels };

            return this.View("/Channels/Followed", model);
        }
    }
}
