using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Interfaces;

namespace BLL.Service
{
    public class ChitatelService
    {
        IDbRepos db;
        public ChitatelService(IDbRepos repos)
        {
            db = repos;
        }
        public ChitatelService()
        {

        }

        public void Refresh_stat(List<Model.Chitatel> list)
        {
            for(int i=0;i<list.Count;i++)
            {
                    int st_id = 2;
                    foreach(Model.Book tmp in list[i].BookList)
                    {
                        int d = (DateTime.Now - list[i].OutList.FindLast(j => j.Id_book == tmp.Id).Date).Days;
                        if (d>=1)
                        {
                            st_id = 1;
                        }
                        
                    }
                    DAL.Chitatel tmp1 = db.Chitatel.GetItem(list[i].Id);
                    tmp1.Status_id = st_id;
                    db.Chitatel.Update(tmp1);
            }
        }
        public List<Model.Chitatel> filter(List<Model.Chitatel> list, int f)
        {
            if (f != 0)
                return list.FindAll(i => i.Status_id == f);
            else
                return list;
        }

    }

}
