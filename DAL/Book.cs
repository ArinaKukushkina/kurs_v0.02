using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;


namespace DAL
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Autor { get; set; }

        public int Status_id { get; set; }
        public int Rubrika_id { get; set; }
        public int God { get; set; }
        public string Annot { get; set; }
        
        public int Izdatelstvo_id { get; set; }
    }
}
