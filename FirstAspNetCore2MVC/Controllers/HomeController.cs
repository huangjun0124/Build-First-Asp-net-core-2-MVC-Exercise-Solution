using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstAspNetCore2MVC.Models;
using FirstAspNetCore2MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstAspNetCore2MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository PieRepository;

        public HomeController(IPieRepository pieRepository)
        {
            // will be injected automaticlly as a result of configred in StartUp.cs
            PieRepository = pieRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            HomeViewModel model = new HomeViewModel()
            {
                PieList = PieRepository.GetAllPies().OrderBy(p => p.Name),
                Title = "Jun's Pie Home Page"
            };
            return View(model);
        }
    }
}
