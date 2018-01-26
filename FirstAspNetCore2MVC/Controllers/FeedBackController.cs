using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstAspNetCore2MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FirstAspNetCore2MVC.Controllers
{
    [Authorize]
    public class FeedBackController : Controller
    {
        private IFeedBackRepository repository;
        public FeedBackController(IFeedBackRepository repository)
        {
            this.repository = repository;
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(FeedBack feedBack)
        {
            // Model binding happens before Index method is invoked, Model validation the same
            // when model binding happens, a Site property ModelState is created, which contains
            // the error encountered
            if (ModelState.IsValid)
            {
                repository.AddFeedBack(feedBack);
                return RedirectToAction("FeedBackDone");
            }
            // asp-validation-summary or <span asp-validation-for> in html will show the errors
            return View(feedBack);
        }

        // GET
        public IActionResult FeedBackDone()
        {
            return View();
        }
    }
}