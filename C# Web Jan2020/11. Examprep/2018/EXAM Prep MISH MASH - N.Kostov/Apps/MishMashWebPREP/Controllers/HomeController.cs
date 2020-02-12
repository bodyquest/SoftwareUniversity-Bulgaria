namespace MishMashWebPREP.Controllers
{
    using MishMashWebPREP.ViewModels.Channels;
    using MishMashWebPREP.ViewModels.Home;
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class HomeController : BaseController
    {
        [HttpGet("/Home/Index")]
        public IHttpResponse Index()
        {
            if (this.User.IsLoggedIn)
            {
                var model = new LoggedInIndexViewModel();
                model.UserRole = this.User.Role.ToString();

                model.YourChannels = this.Context.Channels
                    .Where(x => x.Followers.Any(f => f.User.Username == this.User.Username))
                    .Select(x => new BaseChannelViewModel
                    {
                        Id = x.Id,
                        Type = x.Type,
                        Name = x.Name,
                        FollowersCount = x.Followers.Count()
                    }).ToList();

                var followedChannelsTags = this.Context.Channels
                     .Where(x => x.Followers.Any(f => f.User.Username == this.User.Username))
                     .SelectMany(x => x.Tags.Select(t => t.TagId)).ToList();


                model.SuggestedChannels = this.Context.Channels
                    .Where(x => !x.Followers
                                 .Any(f => f.User.Username == this.User.Username)
                                 && x.Tags.Any(t => followedChannelsTags.Contains(t.TagId)))
                    .Select(x => new BaseChannelViewModel
                    {
                        Id = x.Id,
                        Type = x.Type,
                        Name = x.Name,
                        FollowersCount = x.Followers.Count()
                    }).ToList();

                var ids = model.YourChannels.Select(x => x.Id).ToList();
                ids = ids.Concat(model.SuggestedChannels.Select(x => x.Id)).ToList();
                ids = ids.Distinct().ToList();

                model.SeeOtherChannels = this.Context.Channels
                    .Where(x => !ids.Contains(x.Id))
                    .Select(x => new BaseChannelViewModel
                    {
                        Id = x.Id,
                        Type = x.Type,
                        Name = x.Name,
                        FollowersCount = x.Followers.Count()
                    }).ToList();



                return this.View("Home/IndexLoggedIn", model);
            }

            return this.View("Home/Index");
        }

        [HttpGet("/")]
        public IHttpResponse RootIndex()
        {
            return this.Index();
        }
    }
}
