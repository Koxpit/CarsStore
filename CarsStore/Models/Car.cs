using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsStore.Models
{
    public class Car
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string ShortDescrip { get; set; }
        public string LongDescrip { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public bool IsFavorite { get; set; }
        public bool Available { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
