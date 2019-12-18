using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model
{
    public class Out
    {
        public int Id { get; set; }
        public int Id_book { get; set; }
        public int Id_chit { get; set; }
        public string Name_book { get; set; }
        public string Name_student { get; set; }
        public int Outtype_id { get; set; }
        public string Outtype_name { get; set; }
        public DateTime Date { get; set; }
        public Out() { }
        public Out(DAL.Out i, DAL.Book book, DAL.Chitatel st,DAL.Outtype ot)
        {
            Id = i.Id;
            Id_book = i.Id_book;
            Id_chit = i.Id_chit;
            Date = i.Date;
            Name_book = book.Name;
            Name_student = st.FIO;
            Outtype_id = i.Outtype_id;
            Outtype_name = ot.Name;
        }
    }
}
