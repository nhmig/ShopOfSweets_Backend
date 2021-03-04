using ShopOfSweet_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOfSweet_WebApi.Data
{
    public interface IDealRepository
    {
        bool SaveChanges();

        IEnumerable<Deals> GetAllDeals();
        void CreateDeal(Deals deal);
        Deals GetDealById(int id);
        IEnumerable<Deals> GetDealByFilter(DateTime fromDt, DateTime toDt, int transactoin = 0, int product = 0);
        //void UpdateDeal(Deals deal);
        void DeleteDeal(Deals deal);
    }
}
