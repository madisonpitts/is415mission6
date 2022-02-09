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
            return View();
        }

        [HttpPost]
        public IActionResult Tasks(TaskResponse tr)
        {
            if (ModelState.IsValid)
            {
                TaskResponseContext.Add(tr);
                TaskResponseContext.SaveChanges();

                return View("Quadrants", tr);
            }
            else
            {
                ViewBag.Categories = TaskResponseContext.Categories.ToList();
                return View(tr);
            }
        }

        public IActionResult Quadrants()
        {
            return View();
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
