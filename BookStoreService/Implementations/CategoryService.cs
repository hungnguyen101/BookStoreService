using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreService.EF;
using BookstoreService.Interfaces;

namespace BookstoreService.Implementations
{
    public class CategoryService : ICategory
    {
        private BookstoreDbContext db = null;

        public CategoryService()
        {
            db = new BookstoreDbContext();
        }

        public List<Category> findAll()
        {
            return db.Categories.ToList();
        }

        public Category findById(object id)
        {
            return db.Categories.Find(Convert.ToInt32(id));
        }

        public long insert(Category entity)
        {
            try
            {
                db.Categories.Add(entity);
                db.SaveChanges();
                return entity.id;
            }
            catch
            {
                return -1;
            }
        }

        public bool update(Category entity)
        {
            try
            {
                Category cat = db.Categories.Find(entity.id);
                cat.ModifiedAt = DateTime.Now;
                cat.ModifiedBy = entity.ModifiedBy;
                cat.Name = entity.Name;
                cat.ParentID = entity.ParentID;
                cat.Status = entity.Status;
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
                Category cat = db.Categories.Find(Convert.ToInt32(id));
                db.Categories.Remove(cat);
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
