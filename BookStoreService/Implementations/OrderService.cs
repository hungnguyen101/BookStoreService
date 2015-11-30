using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreService.Interfaces;
using BookstoreService.EF;

namespace BookstoreService.Implementations
{
    public class OrderService : IOrder
    {
        private BookstoreDbContext db = null;

        public OrderService()
        {
            db = new BookstoreDbContext();
        }

        public List<Order> findOrderByAccount(long id)
        {
            return db.Orders.Where(o => o.Account == id).ToList();
        }

        public List<Order> findAll()
        {
            return db.Orders.ToList();
        }

        public Order findById(long id)
        {
            return db.Orders.Find(id);
        }

        public bool insert(Order entity, DetailOrder[] items)
        {
            try
            {
                entity.CreatedAt = DateTime.Now;
                entity.Status = false;
                db.Orders.Add(entity);
                db.SaveChanges();
                ProductService serv = new ProductService();
                Product temp = null;
                foreach (DetailOrder item in items)
                {
                    item.OrderId = entity.id;
                    temp = serv.findById(item.ProductId);
                    temp.Quantity = temp.Quantity.Value - item.Quantity.Value;
                    serv.update(temp);
                }
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

        public bool delete(long id)
        {
            try
            {
                Order o = db.Orders.Find(id);
                DetailOrder[] items = db.DetailOrders.Where(d => d.OrderId == id).ToArray();
                ProductService serv = new ProductService();
                foreach (DetailOrder item in items)
                {
                    Product p = serv.findById(item.ProductId);
                    p.Quantity = p.Quantity + item.Quantity;
                    serv.update(p);
                }
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

        public List<DetailOrder> findDetailByOrder(long id)
        {
            return db.DetailOrders.Where(d => d.OrderId == id).ToList();
        }
    }
}
