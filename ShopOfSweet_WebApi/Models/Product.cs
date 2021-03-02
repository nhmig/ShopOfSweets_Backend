using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOfSweet_WebApi.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string manufacturer { get; set; }
        [MaxLength(255)]
        public string SerialNumber { get; set; }
        public List<Deals> Deals { get; set; }
    }
    //Add-Migration InitialCreate
    //Update-Database
}
