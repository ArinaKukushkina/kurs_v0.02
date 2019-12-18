using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    class IzdatelstvoRepositorySQL : IRepository<Izdatelstvo>
    {
        private Context db;

        public IzdatelstvoRepositorySQL(Context dbcontext)
        {
            this.db = dbcontext;
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }

        public List<Izdatelstvo> GetList()
        {
            return db.Izdatelstvo.ToList();
        }

        public Izdatelstvo GetItem(int id)
        {
            return db.Izdatelstvo.Find(id);
        }

        public void Create(Izdatelstvo Phone)
        {
            db.Izdatelstvo.Add(Phone);
            Save();
        }

        public void Update(Izdatelstvo Phone)
        {
            db.Entry(Phone).State = EntityState.Modified;
            Save();
        }

        public void Delete(int id)
        {
            Izdatelstvo Phone = db.Izdatelstvo.Find(id);
            if (Phone != null)
                db.Izdatelstvo.Remove(Phone);
            Save();
        }
    }
}
