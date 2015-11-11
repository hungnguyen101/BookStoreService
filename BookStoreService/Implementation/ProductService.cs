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
        private BookStoreDbContext db = null;
        public ProductService()
        {
            db = new BookStoreDbContext();
        }

        public List<Product> findAll()
        {
            return db.Products.ToList();
        }

        public Product findById(long id)
        {
            return db.Products.Find(id);
        }

        public long insert(Product entity)
        {
            try
            {
                Product p = (Product)entity;
                db.Products.Add(p);
                db.SaveChanges();
                return p.id;
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
                p.DescriptionXML = entity.DescriptionXML;
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

            }
            return false;
        }

        public bool delete(long id)
        {
            try
            {
                Product p = db.Products.Find(id);
                db.Products.Remove(p);
                db.SaveChanges();
                return true;
            }
            catch
            {

            }
            return false;
        }

        public List<Product> findProuctsByCategory(int id)
        {
            return db.Products.Where(p => p.Category == id).ToList();
        }
    }
}
