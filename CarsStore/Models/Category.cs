using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsStore.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public List<Car> Car { get; set; }
    }
}
