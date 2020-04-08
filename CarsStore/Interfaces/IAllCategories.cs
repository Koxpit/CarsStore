using CarsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsStore.Interfaces
{
    public interface IAllCategories
    {
        IEnumerable<Category> GetCategories { get; }
    }
}
