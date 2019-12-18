using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class Rubrika
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int Head_id { get; set; }

    }
}
