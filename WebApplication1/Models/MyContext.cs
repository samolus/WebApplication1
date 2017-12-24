using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Mycontext : DbContext
    {
        public Mycontext() : base("MyConnectionString") { }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Login> Login { get; set; }

        internal object GetTable<T>()
        {
            throw new NotImplementedException();
        }
    }
}
