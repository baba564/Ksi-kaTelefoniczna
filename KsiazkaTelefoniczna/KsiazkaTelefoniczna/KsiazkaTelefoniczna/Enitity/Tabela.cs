using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace KsiazkaTelefoniczna.Enitity
{
    public partial class Tabela : DbContext
    {
        public Tabela()
            : base("name=Tabela")
        {
        }

        public virtual DbSet<Kontakty> Kontakty { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kontakty>()
                .Property(e => e.Imie)
                .IsUnicode(false);

            modelBuilder.Entity<Kontakty>()
                .Property(e => e.Nazwisko)
                .IsUnicode(false);
        }
    }
}
