using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    class Chitatel_statusRepositorySQL : IRepository<Chitatel_status>
    {
        private Context db;

        public Chitatel_statusRepositorySQL(Context dbcontext)
        {
            this.db = dbcontext;
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }

        public List<Chitatel_status> GetList()
        {
            return db.Chitatel_status.ToList();
        }

        public Chitatel_status GetItem(int id)
        {
            return db.Chitatel_status.Find(id);
        }

        public void Create(Chitatel_status Phone)
        {
            db.Chitatel_status.Add(Phone);
            Save();
        }

        public void Update(Chitatel_status Phone)
        {
            db.Entry(Phone).State = EntityState.Modified;
            Save();
        }

        public void Delete(int id)
        {
            Chitatel_status Phone = db.Chitatel_status.Find(id);
            if (Phone != null)
                db.Chitatel_status.Remove(Phone);
            Save();
        }
    }
}
