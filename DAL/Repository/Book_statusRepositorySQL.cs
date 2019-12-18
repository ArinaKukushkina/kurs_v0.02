using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class Book_statusRepositorySQL : IRepository<Book_status>
    {
        private Context db;

        public Book_statusRepositorySQL(Context dbcontext)
        {
            this.db = dbcontext;
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }

        public List<Book_status> GetList()
        {
            return db.Book_status.ToList();
        }

        public Book_status GetItem(int id)
        {
            return db.Book_status.Find(id);
        }

        public void Create(Book_status Phone)
        {
            db.Book_status.Add(Phone);
            Save();
        }

        public void Update(Book_status Phone)
        {
            db.Entry(Phone).State = EntityState.Modified;
            Save();
        }

        public void Delete(int id)
        {
            Book_status Phone = db.Book_status.Find(id);
            if (Phone != null)
                db.Book_status.Remove(Phone);
            Save();
        }
    }
}
