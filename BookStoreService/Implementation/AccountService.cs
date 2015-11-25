using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreService.EF;
using BookStoreService.Interfaces;

namespace BookStoreService.Implementation
{
    public class AccountService : IAccount
    {
        private BookStoreDbContext db = null;

        public AccountService()
        {
            db = new BookStoreDbContext();
        }

        public Account Authenticate(string username, string password)
        {
            return db.Accounts.SingleOrDefault(a => a.Username.Equals(username) && a.Password.Equals(password));
        }

        public List<Account> findAll()
        {
            return db.Accounts.ToList();
        }

        public Account findById(long id)
        {
            return db.Accounts.Find(id);
        }

        public long insert(Account entity)
        {
            try
            {
                Account acc = db.Accounts.SingleOrDefault(a => a.Username.Equals(entity.Username) || a.Email.Equals(entity.Email));
                if (acc != null) return -1;
                entity.CreatedAt = DateTime.Now;
                db.Accounts.Add(entity);
                db.SaveChanges();
                return entity.id;
            }
            catch
            {
                return -2;
            }
        }

        public bool update(Account entity)
        {
            try
            {
                Account acc = db.Accounts.Find(entity.id);
                acc.Address = entity.Address;
                acc.Avatar = entity.Avatar;
                acc.DayOfBirth = entity.DayOfBirth;
                acc.Facebook = entity.Facebook;
                acc.Fullname = entity.Fullname;
                acc.GroupId = entity.GroupId;
                acc.ModifiedBy = entity.ModifiedBy;
                acc.Password = entity.Password;
                acc.Phone = entity.Phone;
                acc.Roles = entity.Roles;
                acc.Skype = entity.Skype;
                acc.Status = entity.Status;
                acc.Yahoo = entity.Yahoo;
                acc.ModifiedAt = DateTime.Now;
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
                Account acc = db.Accounts.Find(id);
                db.Accounts.Remove(acc);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public List<Account> findAccountsByGroup(string groupID)
        {
            return db.Accounts.Where(a => a.GroupId.Equals(groupID)).ToList();
        }


        public Account findAccountByUsername(string customer)
        {
            return db.Accounts.SingleOrDefault(a => a.Username.Equals(customer) || a.Email.Equals(customer));
        }
    }
}
