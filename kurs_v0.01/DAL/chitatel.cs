using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class Chitatel
    {
        [Key]
        public int Id { get; set; }
        public int Nomer_chit { get; set; }
        [StringLength(100)]
        public string FIO { get; set; }
        public int Status_id { get; set; }
        public string Telephone { get; set; }
        public string Adress { get; set; }

    }
}
