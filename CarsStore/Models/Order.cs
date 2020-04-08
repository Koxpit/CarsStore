using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarsStore.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }

        [Display(Name = "Имя")]
        [StringLength(10)]
        [MinLength(5)]
        [Required(ErrorMessage = "Длина имени должна быть больше от 5 символов")]
        public string Name { get; set; }

        [Display(Name = "Фамилия")]
        [StringLength(15)]
        [MinLength(5)]
        [Required(ErrorMessage = "Длина фамилии должна быть от 5 символов")]
        public string Surname { get; set; }

        [Display(Name = "Адрес")]
        [StringLength(30)]
        [MinLength(10)]
        [Required(ErrorMessage = "Длина адреса должна быть от 10 символов")]
        public string Address { get; set; }

        [Display(Name = "Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(11)]
        [MinLength(11)]
        [Required(ErrorMessage = "Длина номера должна быть не менее и не более 11 символов")]
        public string Phone { get; set; }

        [Display(Name = "Почта")]
        [DataType(DataType.EmailAddress)]
        [StringLength(30)]
        [MinLength(10)]
        [Required(ErrorMessage = "Длина почты должна быть от 10 символов")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
