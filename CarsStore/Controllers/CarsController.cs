using CarsStore.Interfaces;
using CarsStore.Models;
using CarsStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsStore.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars allCars;
        private readonly IAllCategories allCategories;

        public CarsController(IAllCars allCars, IAllCategories allCategories)
        {
            this.allCars = allCars;
            this.allCategories = allCategories;
        }

        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public IActionResult List(string category)
        {
            string _category = category;
            IEnumerable<Car> cars = null;
            string currentCategory = "";

            if (String.IsNullOrEmpty(category))
                cars = allCars.Cars.OrderBy(i => i.Id);
            else
            {
                if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = allCars.Cars
                        .Where(i => i.Category.CategoryName.Equals("Электромобили"));
                    currentCategory = "Электромобили";
                } else if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = allCars.Cars
                        .Where(i => i.Category.CategoryName.Equals("Классические автомобили"));
                    currentCategory = "Классические автомобили";
                }
            }

            var carObj = new CarsListViewModel
            {
                GetAllCars = cars,
                carCategory = currentCategory
            };

            ViewBag.Title = "Страница с автомобилями";

            return View(carObj);
        }
    }
}
