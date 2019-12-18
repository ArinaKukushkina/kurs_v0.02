using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IDbCrud
    {
        List<Model.Book> GetAllBook();
        List<Model.Out> GetAllOut();
        Model.Book GetBook(int BookId);
        void CreateBook(Model.Book p);
        void CreateOut(Model.Out p);
        void CreateChitatel(Model.Chitatel p);
        void UpdateBook(Model.Book p);
        void DeleteBook(int id);
        Model.Out GetOut(int Id);
        void DeleteOut(int id);
        void Create_stat_book(Model.Book_status bs);
        void Create_stat_chit(Model.Chitatel_status chs);
        Model.Chitatel GetChitatel(int id);
        List<Model.Out> Find(int st, int book);
        void Create_izdat(Model.Izdatelstvo iz);
        void Create_rubrika(Model.Rubrika r);
        List<Model.Chitatel> GetAllChit();
        void Create_Outtype(Model.Outtype o);
        List<Model.Chitatel_status> GetAllChitatelStatus();
    }
}
