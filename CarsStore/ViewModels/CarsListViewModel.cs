using CarsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsStore.ViewModels
{
    public class CarsListViewModel
    {
        public IEnumerable<Car> GetAllCars { get; set; }
        public string carCategory { get; set; }
    }
}
