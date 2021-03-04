using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOfSweet_WebApi.DTOs
{
    public class DealCreateDto
    {
        //[Key]
        //public int Id { get; set; }
        public int TransactionId { get; set; }
        //public Transaction Transaction { get; set; }
        public string Description { get; set; }
        public int ProductId { get; set; }
        //public Product Product { get; set; }
        [Required]
        public int Quantity { get; set; }


        public int ShopId { get; set; }
        //public Shop Shop { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public double Price { get; set; }
        //public double Discount { get; set; }
    }
}
