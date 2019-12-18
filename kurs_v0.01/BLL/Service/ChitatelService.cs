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

        /* public bool check_stud(int i)
         {

             if (db.student.Where(i => i.Nomer_zach == nom_zach).Count() > 0) return false;
             else return false;
         }*/


    }

}
