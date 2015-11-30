using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreService.EF;
using BookStoreService.Interfaces;

namespace BookStoreService.Implementation
{
    public class OrderService : IOrder
    {
        private BookStoreDbContext db = null;

        public OrderService()
        {
            db = new BookStoreDbContext();
        }

        public List<Order> findOrderByAccount(long id)
        {
            return db.Orders.Where(o => o.Account.Value == id).ToList();
        }

        public List<Order> findAll()
        {
            return db.Orders.ToList();
        }

        public Order findById(long id)
        {
            return db.Orders.Find(id);
        }

        public bool delete(long id)
        {
            try
            {
                Order o = db.Orders.Find(id);
                DetailOrder[] items = db.DetailOrders.Where(d => d.OrderId == id).ToArray();
                db.DetailOrders.RemoveRange(items);
                db.Orders.Remove(o);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool insert(Order entity, DetailOrder[] items)
        {
            try
            {
                entity.CreatedAt = DateTime.Now;
                entity.Status = false;
                db.Orders.Add(entity);
                db.SaveChanges();
                foreach (DetailOrder item in items)
                    item.OrderId = entity.id;
                db.DetailOrders.AddRange(items);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool update(Order entity)
        {
            try
            {
                Order o = db.Orders.Find(entity.id);
                o.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public List<DetailOrder> findDetailByOrder(long id)
        {
            return db.DetailOrders.Where(d => d.OrderId == id).ToList();
        }
    }
}
