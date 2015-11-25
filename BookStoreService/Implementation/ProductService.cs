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
            return db.Products.Where(a => a.Category == id).ToList();
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
    }
}
