using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCodeFirst.Models;
using Microsoft.EntityFrameworkCore;
namespace WebAppCodeFirst.Models
{
    public class DBKuliahDataContext : DbContext
    {
        public virtual DbSet<MataKuliah> MataKuliahs { get; set; }

        public DBKuliahDataContext(DbContextOptions<DBKuliahDataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MataKuliah>().HasKey(e => new { e.Id });
        }
    }
}
