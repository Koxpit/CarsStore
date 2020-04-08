using CarsStore.Interfaces;
using CarsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsStore.Data.Repository
{
    public class CategoryRepository : IAllCategories
    {
        private readonly CarsStoreContext carStoreContext;

        public CategoryRepository(CarsStoreContext carStoreContext)
        {
            this.carStoreContext = carStoreContext;
        }
        public IEnumerable<Category> GetCategories => carStoreContext.Category;
    }
}
