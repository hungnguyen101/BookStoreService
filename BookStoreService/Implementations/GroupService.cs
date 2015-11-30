using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreService.Interfaces;
using BookstoreService.EF;

namespace BookstoreService.Implementations
{
    public class GroupService : IGroup
    {
        private BookstoreDbContext db = null;

        public GroupService()
        {
            db = new BookstoreDbContext();
        }
        public List<Group> findAll()
        {
            return db.Groups.ToList();
        }

        public Group findById(object id)
        {
            return db.Groups.Find(id.ToString());
        }

        public long insert(Group entity)
        {
            throw new NotImplementedException();
        }

        public bool update(Group entity)
        {
            throw new NotImplementedException();
        }

        public bool delete(object id)
        {
            throw new NotImplementedException();
        }
    }
}
