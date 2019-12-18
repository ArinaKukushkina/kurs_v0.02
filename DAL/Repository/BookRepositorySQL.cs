using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository                               //реализация работы репозитория
{
    class BookRepositorySQL: IRepository<Book>
    {
        private Context db;

        public BookRepositorySQL(Context dbcontext)
        {
            this.db = dbcontext;
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }

        public List<Book> GetList()
        {
            return db.Book.ToList();
        }

        public Book GetItem(int id)
        {
            return db.Book.Find(id);
        }

        public void Create(Book p)
        {
            db.Book.Add(p);
            Save();
        }

        public void Create(Book Phone, int kol_vo)
        {
            for(int i=0;i<kol_vo;i++)
                db.Book.Add(Phone);
            Save();
        }

        public void Update(Book Phone)
        {
            db.Entry(Phone).State = EntityState.Modified;
            Save();
        }

        public void Delete(int id)
        {
            Book Phone = db.Book.Find(id);
            if (Phone != null)
                db.Book.Remove(Phone);
            Save();
        }
        public List<Book> GetList(Book_status st)
        {
            return db.Book.Where(b => b.Status_id == st.Id).ToList();
        }

        public List<Book> GetList(Izdatelstvo iz)
        {
            return db.Book.Where(b => b.Izdatelstvo_id == iz.Id).ToList();
        }
        public List<Book> GetList(Rubrika rub)
        {
            return db.Book.Where(b => b.Rubrika_id == rub.Id).ToList();
        }

    }
}
