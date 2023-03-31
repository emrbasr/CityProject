using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class SqlDbContext:DbContext
    {
        public DbSet<Sehir> Sehirler { get; set; }

        public SqlDbContext()
        {

        }
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=SehirDb;Trusted_Connection=True");
        }
    }
}
