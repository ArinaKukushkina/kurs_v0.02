using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model
{
    public class Rubrika
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Head_id { get; set; }
        public Rubrika() { }
        public Rubrika(int i, string n, int hi)
        {
            Id = i;
            Name = n;
            Head_id = hi
;        }
    }
}
