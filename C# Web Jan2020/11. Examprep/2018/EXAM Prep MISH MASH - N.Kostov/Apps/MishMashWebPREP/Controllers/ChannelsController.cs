namespace MishMashWebPREP.Controllers
{
    using System.Linq;

    using MishMashWebPREP.ViewModels.Channels;
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MishMashWebPREP.Models;

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
        [HttpGet("/Channels/Followed")]
        public IHttpResponse Followed()
        {
            var followedChannels = this.Context.Channels.Where(x => x.Followers.Any(f => f.User.Username == this.User.Username))
                .Select(x => new BaseChannelViewModel
                {
                    Id = x.Id,
                    Type = x.Type,
                    Name = x.Name,
                    FollowersCount = x.Followers.Count()
                }).ToList();

            var model = new AllFollowedChannelsViewModel { FollowedChannels = followedChannels };

            return this.View("/Channels/Followed", model);
        }

        [Authorize]
        [HttpGet("/Channels/Follow")]
        public IHttpResponse Follow(int id)
        {
            var user = this.Context.Users.FirstOrDefault(x => x.Username == this.User.Username);

            if (!this.Context.UserChannel.Any(x => x.UserId == user.Id && x.ChannelId == id))
            {
                this.Context.UserChannel.Add(new UserChannel
                {
                    ChannelId = id,
                    UserId = user.Id
                });

                this.Context.SaveChanges();
            }

            return this.Redirect("/Channels/Followed");
        }

        [Authorize]
        [HttpGet("/Channels/Unfollow")]
        public IHttpResponse Unfollow(int id)
        {
            var user = this.Context.Users.FirstOrDefault(x => x.Username == this.User.Username);

            var userChannel = this.Context.UserChannel.FirstOrDefault(x => x.UserId == user.Id && x.ChannelId == id);

            this.Context.UserChannel.Remove(userChannel);

                this.Context.SaveChanges();

            return this.Redirect("/Channels/Followed");
        }
    }
}
