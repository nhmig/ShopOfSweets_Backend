using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopOfSweet_WebApi.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Deals> Deals { get; set; }
        // 1 - undef, 2 - buy, 3 - sell, 4 - storage in, 5 - stroage out
    }
}