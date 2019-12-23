using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model
{
    public class Chitatel
    {
        public int Id { get; set; }
        [DisplayName("Номер читательского")]
        public int Nomer_chit { get; set; }
        [DisplayName("ФИо")]
        public string FIO { get; set; }
        [DisplayName("Адрес")]
        public string Adress { get; set; }
        [DisplayName("Телефон")]
        public string Telephone { get; set; }
        public int Status_id { get; set; }
        [DisplayName("Статус")]
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
            if(s!=null)
            Status_name = s.Name;
            OutList = o;
            BookList = b;
        }
    }
}
