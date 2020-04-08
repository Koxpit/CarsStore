using CarsStore.Interfaces;
using CarsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsStore.Mocks
{
    public class MockCategory : IAllCategories
    {
        public IEnumerable<Category> GetCategories
        {
            get => new List<Category> {
                new Category { CategoryName = "Электромобили", Description = "Соврееменный вид транспорта" },
                new Category { CategoryName = "Классические автомобили", Description = "Вид автомобилей с двигателями внутреннего сгорания" }
            };
        }
    }
}
