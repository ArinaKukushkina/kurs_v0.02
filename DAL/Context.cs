using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SqlClient;

namespace DAL
{
    public partial class Context : DbContext
    {
        public Context() : base("11111")
        {
        }
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<Chitatel> Chitatel { get; set; }
        public virtual DbSet<Out> Out { get; set; }
        public virtual DbSet<Chitatel_status> Chitatel_status { get; set; }
        public virtual DbSet<Book_status> Book_status { get; set; }
        public virtual DbSet<Izdatelstvo> Izdatelstvo { get; set; }
        public virtual DbSet<Rubrika> Rubrika { get; set; }

        public virtual DbSet<Outtype> Outtype { get; set; }
    }
}
