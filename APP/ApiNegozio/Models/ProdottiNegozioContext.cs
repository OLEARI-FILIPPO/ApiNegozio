using Microsoft.EntityFrameworkCore;

namespace ApiNegozio.Models
{
    public partial class ProdottiNegozioContext : DbContext
    {
        public ProdottiNegozioContext()
        {
        }

        public ProdottiNegozioContext(DbContextOptions<ProdottiNegozioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Fornitore> Fornitori { get; set; } = null!;
        public virtual DbSet<Prodotto> Prodotti { get; set; } = null!;
        public virtual DbSet<TaglieFornitori> TaglieFornitori { get; set; } = null!;
        public virtual DbSet<Taglia> Taglia { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fornitore>(entity =>
            {
                entity.HasKey(e => e.IdFrntr)
                    .HasName("PK__Fornitor__D40587492BF31CB4");

                entity.ToTable("Fornitore");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Prodotto>(entity =>
            {
                entity.HasKey(e => e.IdPrdt)
                    .HasName("PK__Prodotto__E40DCE64BB4163F5");

                entity.ToTable("Prodotto");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descrizione)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ImgUrl)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Prezzo).HasColumnType("decimal(5, 2)");
            });

            modelBuilder.Entity<TaglieFornitori>(entity =>
            {
                entity.HasKey(e => e.IdTglFr)
                    .HasName("PK__TaglieFo__BCC26CBE221E0865");

                entity.ToTable("TaglieFornitori");

                //entity.HasOne(d => d.IdFrntrNavigation)
                //    .WithMany(p => p.TaglieFornitori)
                //    .HasForeignKey(d => d.IdFrntr)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_TaglieFornitori_Fornitore");

                //entity.HasOne(d => d.IdPrdtNavigation)
                //    .WithMany(p => p.TaglieFornitori)
                //    .HasForeignKey(d => d.IdPrdt)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_TaglieFornitori_Prodotto");

                //entity.HasOne(d => d.IdTagliaNavigation)
                //    .WithMany(p => p.TaglieFornitori)
                //    .HasForeignKey(d => d.IdTaglia)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_TaglieFornitori_Taglia");
            });

            modelBuilder.Entity<Taglia>(entity =>
            {
                entity.HasKey(e => e.IdTaglia)
                    .HasName("PK__Taglia__7FFB1DAD06F2ABAE");

                entity.Property(e => e.TagliaVestito)
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
