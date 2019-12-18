using BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class OutService: IOutService
    {
        public bool check_out(int kol)
        {
            if (kol > 10) return false; else return true;
        }
        public List<Model.Out> Find(int st, int book, List<Model.Out> list)
        {
            if (st != -1) list = list.FindAll(delegate (Model.Out bk)
                 {
                     return bk.Id_chit == st;
                 });
            if (book != -1) list = list.FindAll(delegate (Model.Out bk)
            {
                return bk.Id_book == book;
            });
            return list;
        }
        public List<Model.Out> Find(List<Model.Out> list)
        {
            List<Model.Out> list1=new List<Model.Out>(list);
            Model.Out t;
            for(int i=0;i<list.Count;i++)
            //foreach (Model.Out tmp in list)
            {
                Model.Out tmp = list[i];
                if (tmp.Outtype_id==1)
                {
                    t = null;
                    t=list1.Find(delegate (Model.Out bk)
                    {
                        return (bk.Id_book == tmp.Id_book) &&(bk.Outtype_id==2);
                    });
                    if(t!=null)
                    {
                        list1.Remove(t);
                        list1.Remove(tmp);
                    }
                }
            }
            return list1;
        }

    }
}
