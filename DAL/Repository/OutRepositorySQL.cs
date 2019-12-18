using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    class OutRepositorySQL : DAL.Interfaces.IRepository<Out>
    {
        private Context db;

        public OutRepositorySQL(Context dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Out> GetList()
        {
            return db.Out.ToList();
        }
        public List<Out> GetList(Chitatel ch)
        {
            return db.Out.Where(i=>i.Id_chit==ch.Id).ToList();
        }

        public List<Out> Find(int st, int book)
        {
            return db.Out.ToList().Where(j => j.Id_book == book && j.Id_chit == st).ToList();
        }

        public Out GetItem(int id)
        {
            return db.Out.Find(id);
        }

        public void Create(Out Order)
        {
            db.Out.Add(Order);
            Save();
        }

        public void Update(Out order)
        {
            db.Entry(order).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Out Order = db.Out.Find(id);
            if (Order != null)
                db.Out.Remove(Order);
        }
        public bool Save()
        {
            return db.SaveChanges() > 0;
        }

    }
}
