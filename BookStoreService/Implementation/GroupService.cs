using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreService.EF;
using BookStoreService.Interfaces;

namespace BookStoreService.Implementation
{
    public class GroupService : IGroup
    {
        private BookStoreDbContext db = null;

        public GroupService()
        {
            db = new BookStoreDbContext();
        }

        public List<Group> findAll()
        {
            return db.Groups.ToList();
        }

        public Group findById(long id)
        {
            return db.Groups.Find(id);
        }

        public long insert(Group entity)
        {
            try
            {
                Group g = db.Groups.Find(entity.id);
                if (g != null) return -1;
                g.CreatedAt = DateTime.Now;
                db.Groups.Add(entity);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                return -1;
            }
        }

        public bool update(Group entity)
        {
            try
            {
                Group g = db.Groups.Find(entity.id);
                g.ModifiedAt = DateTime.Now;
                g.Name = entity.Name;
                g.Roles = entity.Roles;
                g.Status = entity.Status;
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
            return false;
        }

        public bool remove(string group)
        {
            try
            {
                Group g = db.Groups.Find(group);
                db.Groups.Remove(g);
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