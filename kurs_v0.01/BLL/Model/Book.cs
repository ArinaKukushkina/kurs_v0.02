using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Autor { get; set; }
        public int Status_id { get; set; }
        public string Status_name { get; set; }
        public int Rubrika_id { get; set; }
        public string Rubrika_name { get; set; }
        public int God { get; set; }
        public int Izdatelstvo_id { get; set; }
        public string Izdatelstvo_name { get; set; }
        public string Annot { get; set; }
        public Book() { }
        public Book(DAL.Book i, DAL.Izdatelstvo iz, DAL.Book_status st, DAL.Rubrika r)
        {
            Name = i.Name;
            Autor = i.Autor;
            Id = i.Id;
            God = i.God;
            Annot = i.Annot;
            Rubrika_id = i.Rubrika_id;
            Rubrika_name = r.Name;
            Status_id = i.Status_id;
            Status_name = st.Name;
            Izdatelstvo_id = i.Izdatelstvo_id;
            Izdatelstvo_name = iz.Name;
        }
    }


}
