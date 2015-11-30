using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreService.EF;
using BookstoreService.Interfaces;

namespace BookstoreService.Implementations
{
    public class ProductService : IProduct
    {
        private BookstoreDbContext db = null;

        public ProductService()
        {
            db = new BookstoreDbContext();
        }
        public List<Product> findProductsByCategory(long catId)
        {
            return db.Products.Where(p => p.Category.Value == catId).ToList();
        }

        public List<Product> findByKeyword(string key)
        {
            return db.Products.Where(p => p.Name.Contains(key)).ToList();
        }

        public List<Product> findByPrice(decimal start, decimal end)
        {
            return db.Products.Where(p => p.Price >= start && p.Price <= end).ToList();
        }

        public List<Product> findAll()
        {
            return db.Products.ToList();
        }

        public Product findById(object id)
        {
            return db.Products.Find(Convert.ToInt32(id));
        }

        public long insert(Product entity)
        {
            try
            {
                entity.CreatedAt = DateTime.Now;
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
                Product p = db.Products.Find(entity.id);
                p.Category = entity.Category;
                p.CreatedBy = entity.CreatedBy;
                p.Description = entity.Description;
                p.ModifiedAt = DateTime.Now;
                p.ModifiedBy = entity.ModifiedBy;
                p.MoreImages = entity.MoreImages;
                p.Name = entity.Name;
                p.Price = entity.Price;
                p.Promotion = entity.Promotion;
                p.PromotionPrice = entity.PromotionPrice;
                p.Quantity = entity.Quantity;
                p.ShowOnHome = entity.ShowOnHome;
                p.Status = entity.Status;
                p.Thumbnail = entity.Thumbnail;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool delete(object id)
        {
            try
            {
                Product p = db.Products.Find(Convert.ToInt32(id));
                db.Products.Remove(p);
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
