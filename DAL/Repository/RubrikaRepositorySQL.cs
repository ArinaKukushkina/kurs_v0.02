using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    class RubrikaRepositorySQL : IRepository<Rubrika>
    {
        private Context db;

        public RubrikaRepositorySQL(Context dbcontext)
        {
            this.db = dbcontext;
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }

        public List<Rubrika> GetList()
        {
            return db.Rubrika.ToList();
        }

        public Rubrika GetItem(int id)
        {
            return db.Rubrika.Find(id);
        }

        public void Create(Rubrika Phone)
        {
            db.Rubrika.Add(Phone);
            Save();
        }

        public void Update(Rubrika Phone)
        {
            db.Entry(Phone).State = EntityState.Modified;
            Save();
        }

        public void Delete(int id)
        {
            Rubrika Phone = db.Rubrika.Find(id);
            if (Phone != null)
                db.Rubrika.Remove(Phone);
            Save();
        }
    }
}
