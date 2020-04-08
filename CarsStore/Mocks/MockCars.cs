using CarsStore.Interfaces;
using CarsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsStore.Mocks
{
    public class MockCars : IAllCars
    {
        private readonly IAllCategories allCategories = new MockCategory();
        public IEnumerable<Car> Cars
        {
            get
            {
                return new List<Car> {
                    new Car
                    {
                        Name = "Tesla",
                        ShortDescrip = "",
                        LongDescrip = "",
                        Image = "/images/tesla1.jpg",
                        Price = 45000,
                        IsFavorite = true,
                        Available = true,
                        Category = allCategories.GetCategories.First()
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
                        Category = allCategories.GetCategories.First()
                    }
                };
            }
        }
        public IEnumerable<Car> GetFavCars { get; }

        public Car GetCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
