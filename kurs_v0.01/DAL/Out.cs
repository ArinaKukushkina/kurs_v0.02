using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class Out
    {
        public int Id { get; set; }
        public int Id_book { get; set; }
        public int Id_chit { get; set; }
        public DateTime Date { get; set; }

        public int Outtype_id { get; set; }
    }
}
