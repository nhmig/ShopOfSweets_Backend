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
            var child1 = _context.Transactions.Where(t => t.Id == deal.TransactionId).ToList().FirstOrDefault();
            var child = _context.Transactions.Where(t => t.Id == deal.TransactionId).FirstOrDefault();
            if (child == null)
            {
                throw new ArgumentNullException(nameof(deal));
            }
            deal.Transaction = child;
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
            IQueryable<Deals> deals = _context.Deals.Where(p => p.DateTime >= fromDt && p.DateTime <= toDt);
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
