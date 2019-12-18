using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    class ChitatelRepositorySQL : DAL.Interfaces.IRepository<Chitatel>
    {
        private Context db;

        public ChitatelRepositorySQL(Context dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Chitatel> GetList()
        {
            return db.Chitatel.ToList();
        }

        public Chitatel GetItem(int id)
        {
            return db.Chitatel.Find(id);
        }

        public void Create(Chitatel item)
        {
            db.Chitatel.Add(item);
            Save();
        }

        public void Update(Chitatel item)
        {
            /*db.Entry(item).State = EntityState.Modified;
            Save();*/
            var entry = db.Entry(item);
            if (entry.State == EntityState.Detached || entry.State == EntityState.Modified)
            {
                entry.State = EntityState.Modified; //do it here

                db.Set<Chitatel>().Attach(item); //attach

                Save(); //save it
            }
        }

        public void Delete(int id)
        {
            Chitatel item = db.Chitatel.Find(id);
            if (item != null)
                db.Chitatel.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
        public List<Chitatel> GetList(Chitatel_status st)
        {
            return db.Chitatel.Where(i => i.Status_id == st.Id).ToList();
        }
    }
}
