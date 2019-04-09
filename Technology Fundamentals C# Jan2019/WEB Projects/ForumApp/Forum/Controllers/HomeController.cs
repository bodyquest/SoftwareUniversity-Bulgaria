namespace Forum.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Forum.Models;
    using Forum.Data;
    using Microsoft.EntityFrameworkCore;

    public class HomeController : Controller
    {
        private readonly ForumDbContext context;

        //we get as parameter the ForumDbContext 
        public HomeController(ForumDbContext db)
        {
            this.context = db;
        }

        public IActionResult Index()
        {
            var topics = this.context
                .Topics
                .Include(t => t.Author)
                .Include(t => t.Comments)
                .ThenInclude(c => c.Author)
                .OrderByDescending(t => t.CreatedDate)
                .ThenByDescending(t => t.LastUpdatedDate)
                .ToList();
            // add to each topic info about its author
            return View(topics);
        }
    }
}
