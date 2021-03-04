using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOfSweet_WebApi.Models
{
    public class Shop
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public string Address { get; set; }
        [JsonIgnore]
        public List<Deals> Deals { get; set; }
    }
}
