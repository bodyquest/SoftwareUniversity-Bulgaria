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
    public class TopicController : Controller
    {
        private readonly ForumDbContext context;

        //we define the controller
        public TopicController(ForumDbContext context)
        {
            this.context = context;
        }

        public IActionResult Details (int? id)
        {
            //1. learn to always check your input data
            if (id == null)
            {
                //if null, send the   in the Home Controller(page-a) of Index Action
                return RedirectToAction("Index", "Home");
            }

            var topic = this.context
                .Topics
                .Include(t => t.Author)
                .Include(t => t.Comments)
                .ThenInclude(c => c.Author)
                .Where(t => t.Id == id)
                .FirstOrDefault();

            if (topic == null)
            {
                return RedirectToAction("Index", "Home");
            }
            //2. when we are sure that there is existing valid topic in the database (by sending null entries to home otherwise), then we give it to the View()

            return View(topic);
        }

        //to create we need to have GET ACTION and POST ACTION. The first gets the info to be filled, the second sends it 
        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {

            //right click on "View" and then select "Add View" then OK and Create.cshtml will be created
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(Topic topic)
        {
            //this will VALIDATE if the data for this topic are correct
            if (ModelState.IsValid)
            {
                // Add missing properties if valid
                topic.CreatedDate = DateTime.Now;
                topic.LastUpdatedDate = DateTime.Now;

                //we find the user(from the db) who creates now the new topic
                var userId = this.context.Users.Where(u => u.UserName == User.Identity.Name)
                    .FirstOrDefault()
                    .Id;

                topic.AuthorId = userId;
                // Add to db
                this.context.Topics.Add(topic);
                // Save db
                this.context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            //if not valid we return to the view with the valid data only
            return View(topic);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            Topic topic = this.context
                .Topics
                .Include(t=>t.Author)
                .Where(t => t.Id == id)
                .FirstOrDefault();

            if (topic == null)
            {
                return RedirectToAction("Index", "Home");
            }
            //we want to ask the user- if he is sure to DELETE the topic and therefore we return what he entered. When validated by user then we proceed.

            return View(topic);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Delete(int id)
        {
            Topic topic = this.context
                .Topics
                .Include(t =>t.Author)
                .Where(t => t.Id == id)
                .FirstOrDefault();

            if (topic == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (topic.Author.UserName != User.Identity.Name)
            {
                return RedirectToAction("Index", "Home");
            }

            this.context.Topics.Remove(topic);
            this.context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public IActionResult Edit (int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            //get topic from db
            Topic topic = this.context
                .Topics
                .Include(t => t.Author)
                .Where(t => t.Id == id)
                .FirstOrDefault();
            //check if topic exists
            if (topic == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (topic.Author.UserName != User.Identity.Name)
            {
                return RedirectToAction("Index", "Home");
            }
            //pass the model to view
            return View (topic);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(Topic topic)
        {

            if (ModelState.IsValid)
            {
                //get from db
                Topic dbTopic = this.context
                    .Topics
                    .Where(t => t.Id == topic.Id)
                    .FirstOrDefault();

                if (dbTopic == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                // update properties of entity
                dbTopic.Title = topic.Title;
                dbTopic.Description = topic.Description;
                dbTopic.LastUpdatedDate = DateTime.Now;
                //save to db
                this.context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(topic);
        }
    }
}