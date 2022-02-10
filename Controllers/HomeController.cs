using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mission6.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace mission6.Controllers
{
    public class HomeController : Controller
    {

        private TaskResponseContext TaskResponseContext { get; set; }

        public HomeController(TaskResponseContext someTask)
        {
            TaskResponseContext = someTask;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Tasks()
        {
            ViewBag.Categories = TaskResponseContext.Categories.ToList();
            return View(new TaskResponse());
        }

        [HttpPost]
        public IActionResult Tasks(TaskResponse tr)
        {
            if (ModelState.IsValid)
            {
                TaskResponseContext.Add(tr);
                TaskResponseContext.SaveChanges();

                return RedirectToAction("Quadrants");
            }
            else
            {
                ViewBag.Categories = TaskResponseContext.Categories.ToList();
                return View(tr);
            }
        }

        public IActionResult Quadrants()
        {
            ViewBag.Quad1 = TaskResponseContext.Responses
                .Where( x => x.Quadrant == 1)
                .ToList();
            ViewBag.Quad2 = TaskResponseContext.Responses
                .Where(x => x.Quadrant == 2)
                .ToList();
            ViewBag.Quad3 = TaskResponseContext.Responses
                .Where(x => x.Quadrant == 3)
                .ToList();
            ViewBag.Quad4 = TaskResponseContext.Responses
                .Where(x => x.Quadrant == 4)
                .ToList();
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.categories = TaskResponseContext.Categories.ToList();

            var item = TaskResponseContext.Responses.Single(x => x.TaskID == id);
            return View("Tasks", item);
        }

        [HttpPost]
        public IActionResult Edit(TaskResponse x)
        {
            TaskResponseContext.Update(x);
            TaskResponseContext.SaveChanges();
            return RedirectToAction("Quadrants");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var item = TaskResponseContext.Responses.Single(x => x.TaskID == id);
            return View(item);
        }
        [HttpPost]
        public IActionResult Delete(TaskResponse tr)
        {
            TaskResponseContext.Responses.Remove(tr);
            TaskResponseContext.SaveChanges();
            return RedirectToAction("Quadrants");
        }

        public IActionResult CheckOff(int id)
        {
            var item = TaskResponseContext.Responses.Single(x => x.TaskID == id);
            if (!item.Completed)
            {
                item.Completed = true;
                TaskResponseContext.SaveChanges();
            }
            return RedirectToAction("Quadrants");
        }


    }
}

//hi

//i dont know what im doing

//making another comments

//adding another comment


//last comment

// this is ben1 speaking. I hope this works
//aidan garry
