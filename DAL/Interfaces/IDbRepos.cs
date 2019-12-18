using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces                    //общий репозиторий
{
    public interface IDbRepos
    {
        IRepository<Book> Book { get; }
        IRepository<Book_status> Book_status { get; }
        IRepository<Out> Out { get; }
        IRepository<Outtype> Outtype { get; }
        IRepository<Chitatel> Chitatel { get; }
        IRepository<Chitatel_status> Chitatel_status { get; }
        IRepository<Izdatelstvo> Izdatelstvo { get; }
        IRepository<Rubrika> Rubrika { get; }
        int Save();
    }
}
