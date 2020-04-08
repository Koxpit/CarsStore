using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarsStore.Models;
using CarsStore.Interfaces;
using CarsStore.ViewModels;

namespace CarsStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllCars carRep;
        public HomeController(IAllCars carRep)
        {
            this.carRep = carRep;
        }

        public ViewResult Index()
        {
            var homeCars = new HomeViewModel
            {
                FavCars = carRep.GetFavCars
            };
            return View(homeCars);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
