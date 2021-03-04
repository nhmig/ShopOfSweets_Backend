using Microsoft.EntityFrameworkCore;
using ShopOfSweet_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOfSweet_WebApi.Data
{
    public class SweetsDbContext : DbContext
    {
        public SweetsDbContext(DbContextOptions<SweetsDbContext> opt) : base(opt)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Deals> Deals { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Shop> Shops { get; set; }
    }
}
