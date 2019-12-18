using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    class OuttypeRepositorySQL : IRepository<Outtype>
    {
        private Context db;

        public OuttypeRepositorySQL(Context dbcontext)
        {
            this.db = dbcontext;
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }

        public List<Outtype> GetList()
        {
            return db.Outtype.ToList();
        }

        public Outtype GetItem(int id)
        {
            return db.Outtype.Find(id);
        }

        public void Create(Outtype Phone)
        {
            db.Outtype.Add(Phone);
            Save();
        }

        public void Update(Outtype Phone)
        {
            db.Entry(Phone).State = EntityState.Modified;
            Save();
        }

        public void Delete(int id)
        {
            Outtype Phone = db.Outtype.Find(id);
            if (Phone != null)
                db.Outtype.Remove(Phone);
            Save();
        }
    }
}
