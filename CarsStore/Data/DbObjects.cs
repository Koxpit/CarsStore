using CarsStore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsStore.Data
{
    public class DbObjects
    {
        public static void Initialize(CarsStoreContext content)
        {
            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));

            if (!content.Car.Any())
            {
                content.AddRange(
                    new Car
                    {
                        Name = "Tesla",
                        ShortDescrip = "",
                        LongDescrip = "",
                        Image = "/images/tesla1.jpg",
                        Price = 45000,
                        IsFavorite = true,
                        Available = true,
                        Category = Categories["Электромобили"]
                    },
                    new Car
                    {
                        Name = "Tesla 2",
                        ShortDescrip = "",
                        LongDescrip = "",
                        Image = "/images/tesla2.jpeg",
                        Price = 55000,
                        IsFavorite = true,
                        Available = true,
                        Category = Categories["Электромобили"]
                    },
                    new Car
                    {
                        Name = "Labmorgini",
                        ShortDescrip = "",
                        LongDescrip = "",
                        Image = "/images/lamborgini.jpg",
                        Price = 80000,
                        IsFavorite = true,
                        Available = true,
                        Category = Categories["Классические автомобили"]
                    }
                );
            }

            content.SaveChanges();
        }

        private static Dictionary<string, Category> _categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if(_categories == null)
                {
                    var list = new Category[]
                    {
                        new Category { CategoryName = "Электромобили", Description = "Соврееменный вид транспорта" },
                        new Category { CategoryName = "Классические автомобили", Description = "Вид автомобилей с двигателями внутреннего сгорания" }
                    };

                    _categories = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        _categories.Add(el.CategoryName, el);
                }
                return _categories;
            }
        }
    }
}
