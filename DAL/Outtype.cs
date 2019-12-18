using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("Outtype")]
    public class Outtype
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
