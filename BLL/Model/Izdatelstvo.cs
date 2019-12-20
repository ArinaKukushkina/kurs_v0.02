using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model
{
    public class Izdatelstvo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Izdatelstvo() { }
        public Izdatelstvo(int i, string n)
        {
            Id = i;
            Name = n;
        }
    }
}
