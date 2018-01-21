using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstAspNetCore2MVC.Models;

namespace FirstAspNetCore2MVC.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Pie> PieList;

        public string Title;
    }
}
