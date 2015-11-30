using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreService.Interfaces;
using BookStoreService.EF;

namespace BookStoreService.Implementation
{
    public class ProductService : IProduct
    {

        BookStoreDbContext db = new BookStoreDbContext();

        public List<Product> findProuctsByCategory(int id)
        {
            return db.Products.Where(a => a.Category == id && a.Status.Value == true).ToList();
        }

        public List<Product> findAll()
        {
            return db.Products.ToList();
        }

        public Product findById(long id)
        {
            return db.Products.SingleOrDefault(a => a.id == id);
        }

        public long insert(Product entity)
        {
            try
            {
                entity.Status = true;
                db.Products.Add(entity);
                db.SaveChanges();
                return entity.id;
            }
            catch
            {
                return -1;
            }
        }

        public bool update(Product entity)
        {
            try
            {
                Product p = db.Products.SingleOrDefault(a => a.id == entity.id);
                p.Category = entity.Category;
                p.Description = entity.Description;
                p.Name = entity.Name;
                p.Thumbnail = entity.Thumbnail;
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
                db.Products.Remove(db.Products.SingleOrDefault(a => a.id == id));
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public List<Product> findProductByKeyword(string keyword)
        {
            return db.Products.Where(p => p.Name.Contains(keyword) && p.Status.Value == true).ToList();
        }

        public List<Product> findProductByPrice(decimal start, decimal end)
        {
            return db.Products.Where(p => p.Price >= start && p.Price <= end && p.Status.Value == true).ToList();
        }
    }
}
