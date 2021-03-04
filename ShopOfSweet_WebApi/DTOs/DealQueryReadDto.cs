using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOfSweet_WebApi.DTOs
{
    public class DealQueryReadDto
    {
        public DateTime fromDt { get; set; }
        public DateTime toDt { get; set; }
        public int transaction { get; set; }
        public int product { get; set; }
    }
}
