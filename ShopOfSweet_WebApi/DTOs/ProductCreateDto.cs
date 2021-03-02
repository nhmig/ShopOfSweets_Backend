using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOfSweet_WebApi.DTOs
{
    public class ProductCreateDto
    {
        //public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        //[MaxLength(255)]
        //public string SerialNumber { get; set; }
    }
}
