using System;
using System.Collections.Generic;
using System.Linq;
using Forum.Data;
using Forum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Forum.Controllers
{
    public class CommentController : Controller
    {
        private readonly ForumDbContext context;

        //we define the controller
        public CommentController(ForumDbContext context)
        {
            this.context = context;
        }

        [Authorize]
        [HttpGet]
        [Route("/Topic/Details/{id}/Comment/Create")]
        public IActionResult Create(int id)
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [Route("/Topic/Details/{TopicId}/Comment/Create")]
        public IActionResult Create(Comment comment)
        {
            if (ModelState.IsValid)
            {

                //set CreatedDated and LastUpdatedDate
                comment.CreatedDate = DateTime.Now;
                comment.LastUpdatedDate = DateTime.Now;

                //AuthorId
                string authorId = context
                    .Users
                    .Where(user => user.UserName == User.Identity.Name)
                    .SingleOrDefault()
                    .Id;

                if (authorId == null)
                {
                    return Redirect($"/Topic/Details/{comment.TopicId}");
                }

                comment.AuthorId = authorId;

                // add to context
                Topic topic = context
                    .Topics
                    .Find(comment.TopicId);
                topic.LastUpdatedDate = DateTime.Now;

                // save changes
                context.Comments.Add(comment);
                context.SaveChanges();

                return Redirect($"/Topic/Details/{comment.TopicId}");
            }

            return View(comment);
        }

        [Authorize]
        [HttpGet]
        [Route("/Topic/Details/{TopicId}/Comment/Edit/{id}")]
        public IActionResult Edit(int? topicId, int? id)
        {
            if (id == null)
            {
                return RedirectPermanent($"/Topic/Details/{topicId}");
            }

            Comment comment = context
                .Comments
                .FirstOrDefault(c => c.CommentId == id);

            if (comment == null)
            {
                return RedirectPermanent($"/Topic/Details/{topicId}");
            }

            return View(comment);
        }

        [Authorize]
        [HttpPost]
        [Route("/Topic/Details/{TopicId}/Comment/Edit/{id}")]
        public IActionResult Edit(Comment comment)
        {
            if (ModelState.IsValid)
            {
                // get comment from db
                Comment dbComment = context
                    .Comments
                    .FirstOrDefault(c => c.CommentId == comment.CommentId);

                if (dbComment == null)
                {
                    return RedirectPermanent($"/Topic/Details/{comment.TopicId}");
                }

                // set properties (Descr, LastUpdatedDate)
                dbComment.Description = comment.Description;
                dbComment.LastUpdatedDate = DateTime.Now;

                // get topic and update
                Topic topic = context
                    .Topics
                    .FirstOrDefault(t=> t.Id == comment.TopicId);

                if (topic == null)
                {
                    return RedirectPermanent($"/Topic/Details/{comment.TopicId}");
                }

                topic.LastUpdatedDate = DateTime.Now;

                context.SaveChanges();
            }

            return Redirect($"/Topic/Details/{comment.TopicId}");
        }

        [Authorize]
        [HttpGet]
        [Route("/Topic/Details/{TopicId}/Comment/Delete/{id}")]
        public IActionResult Delete(int topicId, int? id)
        {
            if (id == null)
            {
                return Redirect($"/Topic/Details/{topicId}");
            }

            Comment comment = context
                .Comments
                .Include(c=>c.Author)
                .FirstOrDefault(c=>c.CommentId == id);

            if (comment == null)
            {
                return Redirect($"/Topic/Details/{topicId}");
            }

            return View(comment);
        }

        [Authorize]
        [HttpPost]
        [Route("/Topic/Details/{TopicId}/Comment/Delete/{id}")]
        public IActionResult Delete(int? topicId, int? id)
        {
            if (id == null)
            {
                return Redirect($"/Topic/Details/{topicId}");
            }

            Comment comment = context
                .Comments
                .FirstOrDefault(c=> c.CommentId == id);
            if (comment == null)
            {
                return Redirect($"/Topic/Details/{topicId}");
            }

            context.Comments.Remove(comment);

            if (topicId == null)
            {
                return Redirect($"/Topic/Details/{topicId}");
            }
            Topic topic = context
                .Topics
                .FirstOrDefault(t=>t.Id == topicId);

            if (topic == null)
            {
                return Redirect($"/Topic/Details/{topicId}");
            }

            topic.LastUpdatedDate = DateTime.Now;
            context.SaveChanges();

            return Redirect($"/Topic/Details/{topicId}");
        }
    }
}