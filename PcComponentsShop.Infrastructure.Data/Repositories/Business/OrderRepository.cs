using PcComponentsShop.Domain.Interfaces.Basic_Interfaces;
using PcComponentsShop.Infrastructure.Business.Basic_Models;
using PcComponentsShop.Infrastructure.Data.Contexts;
using System.Collections.Generic;
using System.Data.Entity;

namespace PcComponentsShop.Infrastructure.Data.Repositories.Business
{
    public class OrderRepository : IRepository<Order>
    {
        private PcComponentsShopContext db;

        public OrderRepository(PcComponentsShopContext db)
        {
            this.db = db;
        }

        public void Create(Order item)
        {
            db.Orders.Add(item);
        }

        public void Delete(int id)
        {
            Order order = db.Orders.Find(id);
            if (order != null)
                db.Orders.Remove(order);
        }

        public IEnumerable<Order> GetAll()
        {
            return db.Orders;
        }

        public Order GetElement(int id)
        {
            return db.Orders.Find(id);
        }

        public void Update(Order item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
