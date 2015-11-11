using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreService.EF;
using BookStoreService.Interfaces;

namespace BookStoreService.Implementation
{
    public class PromotionService : IPromotion
    {
        private BookStoreDbContext db = null;

        public PromotionService()
        {
            db = new BookStoreDbContext();
        }
        public List<Promotion> findAll()
        {
            return db.Promotions.ToList();
        }

        public Promotion findById(long id)
        {
            return db.Promotions.Find(id);
        }

        public long insert(Promotion entity)
        {
            try
            {
                entity.CreatedAt = DateTime.Now;
                db.Promotions.Add(entity);
                db.SaveChanges();
                return entity.id;
            }
            catch
            {
                return -1;
            }
        }

        public bool update(Promotion entity)
        {
            try
            {
                Promotion p = db.Promotions.Find(entity.id);
                p.Content = entity.Content;
                p.Deadline = entity.Deadline;
                p.ModifieAt = DateTime.Now;
                p.Status = entity.Status;
                p.Title = entity.Title;
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
                Promotion p = db.Promotions.Find(id);
                db.Promotions.Remove(p);
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
