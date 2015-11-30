using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreService.EF;
using BookstoreService.Interfaces;

namespace BookstoreService.Implementations
{
    
    public class AccountService : IAccount
    {
        private BookstoreDbContext db = null;

        public AccountService()
        {
            db = new BookstoreDbContext();
        }

        public Account Authenticate(string username, string password)
        {
            return db.Accounts.SingleOrDefault(a => a.Username.Equals(username) && a.Password.Equals(password));
        }

        public List<Account> findAccountsByGroup(string groupID)
        {
            return db.Accounts.Where(a => a.GroupId.Equals(groupID)).ToList();
        }

        public Account findAccountByUsername(string username)
        {
            return db.Accounts.SingleOrDefault(a => a.Username.Equals(username));
        }

        public List<Account> findAll()
        {
            return db.Accounts.ToList();
        }

        public Account findById(object id)
        {
            return db.Accounts.Find(Convert.ToInt32(id));
        }

        public long insert(Account entity)
        {
            try
            {
                entity.CreatedAt = DateTime.Now;
                entity.Status = true;
                db.Accounts.Add(entity);
                db.SaveChanges();
                return entity.id;
            }
            catch
            {
                return -1;
            }
        }

        public bool update(Account entity)
        {
            try
            {
                Account a = db.Accounts.Find(entity.id);
                a.Address = entity.Address;
                a.Avatar = entity.Avatar;
                a.DayOfBirth = entity.DayOfBirth;
                a.Email = entity.Email;
                a.Facebook = entity.Facebook;
                a.Fullname = entity.Fullname;
                a.GroupId = entity.GroupId;
                a.ModifiedAt = DateTime.Now;
                a.ModifiedBy = entity.ModifiedBy;
                a.Password = entity.Password;
                a.Phone = entity.Phone;
                a.Roles = entity.Roles;
                a.Skype = entity.Skype;
                a.Status = entity.Status;
                a.Username = entity.Username;
                a.Yahoo = entity.Yahoo;
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
                Account a = db.Accounts.Find(Convert.ToInt32(id));
                db.Accounts.Remove(a);
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
