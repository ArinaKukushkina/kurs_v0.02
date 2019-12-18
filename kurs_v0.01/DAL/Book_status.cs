using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class Book_status
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
