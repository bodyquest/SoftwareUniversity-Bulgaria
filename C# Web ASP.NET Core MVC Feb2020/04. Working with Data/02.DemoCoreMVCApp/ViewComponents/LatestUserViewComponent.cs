namespace _02.DemoCoreMVCApp.ViewComponents
{
    using _02.DemoCoreMVCApp.Services;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class LatestUserViewComponent : ViewComponent
    {
        private readonly IUsersService usersService;

        public LatestUserViewComponent(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public IViewComponentResult Invoke()
        {
            return this.View(new LatestUserViewComponentViewModel {Username = usersService.LatestUsername() });
        }
    }

    public class LatestUserViewComponentViewModel
    {
        public string Username { get; set; }
    }
}
