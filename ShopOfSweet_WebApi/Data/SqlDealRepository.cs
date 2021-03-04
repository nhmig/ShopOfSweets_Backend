using Microsoft.EntityFrameworkCore;
using ShopOfSweet_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOfSweet_WebApi.Data
{
    public class SqlDealRepository : IDealRepository
    {
        private readonly SweetsDbContext _context;
        public SqlDealRepository(SweetsDbContext context)
        {
            _context = context;
        }

        public void CreateDeal(Deals deal)
        {
            //if (deal == null)
            //    throw new ArgumentNullException(nameof(deal));
            //_context.Deals.Add(deal);
            
            if (deal == null)
            {
                throw new ArgumentNullException(nameof(deal));
            }
            deal.Transaction = _context.Transactions.FirstOrDefault(t => t.Id == deal.TransactionId);
            deal.Product = _context.Products.FirstOrDefault(t => t.Id == deal.ProductId);
            deal.Shop = _context.Shops.FirstOrDefault(t => t.Id == deal.ShopId);

            if (deal.Transaction is null || deal.Product is null || deal.Shop is null)
            {
                throw new ArgumentNullException(nameof(deal));
            }

            _context.Deals.Add(deal);
        }

        public void DeleteDeal(Deals deal)
        {
            if (deal == null)
            {
                throw new ArgumentNullException(nameof(deal));
            }
            _context.Deals.Remove(deal);
        }

        public IEnumerable<Deals> GetAllDeals()
        {
            return _context.Deals
                .Include(t => t.Transaction)
                .Include(p => p.Product)
                .Include(s => s.Shop)
                .ToList();
        }

        public IEnumerable<Deals> GetDealByFilter(DateTime fromDt, DateTime toDt, int transactoin = 0, int product = 0)
        {
            IQueryable<Deals> deals = _context.Deals
                .Where(p => p.DateTime >= fromDt && p.DateTime <= toDt)
                .Include(t => t.Transaction)
                .Include(p => p.Product)
                .Include(s => s.Shop);
            //return _context.Deals.Where(p => p.DateTime >= fromDt && p.DateTime <= toDt);
            if (transactoin != 0)
                deals = deals.Where(p => p.TransactionId == transactoin);
            if (product != 0)
                deals = deals.Where(p => p.ProductId == product);

            return deals.ToList<Deals>();
        }

        public Deals GetDealById(int id)
        {
            return _context.Deals
                .Include(t => t.Transaction)
                .Include(p => p.Product)
                .Include(s => s.Shop)
                .FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
