using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsStore.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int CarId { get; set; }
        public int Price { get; set; }
        public virtual Car Car { get; set; }
        public virtual Order Order { get; set; }
    }
}
