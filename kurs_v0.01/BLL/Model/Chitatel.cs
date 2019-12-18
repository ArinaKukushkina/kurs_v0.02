using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model
{
    public class Chitatel
    {
        public int Id { get; set; }
        public int Nomer_chit { get; set; }
        public string FIO { get; set; }
        public string Adress { get; set; }
        public string Telephone { get; set; }
        public int Status_id { get; set; }
        public string Status_name { get; set; }
        public List<BLL.Model.Out> OutList { get; set; }
        public List<BLL.Model.Book> BookList {get;set;}
        public Chitatel() { }
        public Chitatel(DAL.Chitatel i,DAL.Chitatel_status s, List<BLL.Model.Out> o, List<BLL.Model.Book> b)
        {
            FIO = i.FIO;
            Nomer_chit = i.Nomer_chit;
            Id = i.Id;
            Telephone = i.Telephone;
            Adress = i.Adress;
            Status_id = i.Status_id;
            Status_name = s.Name;
            OutList = o;
            BookList = b;
        }
    }
}
