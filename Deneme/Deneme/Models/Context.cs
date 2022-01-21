using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deneme.Models
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = .;Database=ProjeKayıt;Integrated Security=True");
        }
        public DbSet<Ogrenci> ogrencis { get; set; }
        public DbSet<Bolum> bolums { get; set; }
    }
}
