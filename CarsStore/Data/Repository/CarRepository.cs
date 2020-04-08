using CarsStore.Interfaces;
using CarsStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsStore.Data.Repository
{
    public class CarRepository : IAllCars
    {
        private readonly CarsStoreContext carStoreContext;

        public CarRepository(CarsStoreContext carStoreContext)
        {
            this.carStoreContext = carStoreContext;
        }
        public IEnumerable<Car> Cars => carStoreContext.Car.Include(c => c.Category);

        public IEnumerable<Car> GetFavCars => carStoreContext.Car.Where(p => p.IsFavorite).Include(c => c.Category);

        public Car GetCar(int carId) => carStoreContext.Car.FirstOrDefault(p => p.Id == carId);
    }
}
