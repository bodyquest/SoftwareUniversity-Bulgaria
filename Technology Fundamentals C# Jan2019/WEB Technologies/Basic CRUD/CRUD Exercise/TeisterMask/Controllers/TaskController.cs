using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc; // add this
using TeisterMask.Data;
using TeisterMask.Models;

namespace TeisterMask.Controllers
{
    public class TaskController : Controller // add inheritance
    {
        public IActionResult Index()
        {
            //LISTS THE DATA FROM THE DATABASE!!!
            //opens connection to the database and it closes when we finish work
            using (var db = new TeisterMaskDbContext())
            {
                var tasks = db.Tasks.ToList();
                return View(tasks);
            }
        }
        //OPERATIONS ON THE DATABASE
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create (Task task)
        {
            using (var db = new TeisterMaskDbContext())
            {
                db.Tasks.Add(task);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new TeisterMaskDbContext())
            {
                Task task = db.Tasks.Find(id);
                return View(task);
            }
        }

        [HttpPost]
        public IActionResult Edit(Task task)
        {
            using (var db = new TeisterMaskDbContext())
            {
                db.Tasks.Update(task);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (var db = new TeisterMaskDbContext())
            {
                Task task = db.Tasks.Find(id);
                return View(task);
            }
        }

        [HttpPost]
        public IActionResult Delete(Task task)
        {
            using (var db = new TeisterMaskDbContext())
            {
                db.Tasks.Remove(task);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
