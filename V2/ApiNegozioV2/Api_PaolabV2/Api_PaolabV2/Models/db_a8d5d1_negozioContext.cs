using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Api_PaolabV2.Models
{
    public partial class db_a8d5d1_negozioContext : DbContext
    {
        public db_a8d5d1_negozioContext()
        {
        }

        public db_a8d5d1_negozioContext(DbContextOptions<db_a8d5d1_negozioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Fornitori> Fornitori { get; set; } = null!;
        public virtual DbSet<MisureTaglie> MisureTaglie { get; set; } = null!;
        public virtual DbSet<PrezziProdotti> PrezziProdotti { get; set; } = null!;
        public virtual DbSet<Prodotti> Prodotti { get; set; } = null!;
        public virtual DbSet<Taglie> Taglie { get; set; } = null!;
        public virtual DbSet<TaglieProdotti> TaglieProdotti { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=sql8003.site4now.net; Database=db_a8d5d1_negozio; User Id=db_a8d5d1_negozio_admin; Password=Filippo05;");
            }*/
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Latin1_General_CI_AS");

            modelBuilder.Entity<Fornitori>(entity =>
            {
                entity.HasKey(e => e.IdFornitore);

                entity.ToTable("Fornitori");

                entity.Property(e => e.Descrizione).HasMaxLength(100);

                entity.Property(e => e.Nome).HasMaxLength(50);
            });

            modelBuilder.Entity<MisureTaglie>(entity =>
            {
                entity.HasKey(e => e.IdMisura);

                entity.ToTable("MisureTaglie");

                entity.Property(e => e.Descrizione).HasMaxLength(100);

                entity.HasOne(d => d.IdTagliaNavigation)
                    .WithMany(p => p.MisureTaglie)
                    .HasForeignKey(d => d.IdTaglia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaglieProdotti_MisureTaglie");
            });

            modelBuilder.Entity<PrezziProdotti>(entity =>
            {
                entity.ToTable("PrezziProdotti");

                entity.Property(e => e.Descrizione)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Prezzo).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdProdottoNavigation)
                    .WithMany(p => p.PrezziProdotti)
                    .HasForeignKey(d => d.IdProdotto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Prodotti_PrezziProdotti");
            });

            modelBuilder.Entity<Prodotti>(entity =>
            {
                entity.HasKey(e => e.IdProdotto);

                entity.ToTable("Prodotti");

                entity.Property(e => e.Categoria).HasMaxLength(50);

                entity.Property(e => e.Descrizione).HasMaxLength(50);

                entity.Property(e => e.Disponibile)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ImgUrl)
                    .HasMaxLength(200)
                    .HasDefaultValueSql("(N'https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.kamu5.com%2F&psig=AOvVaw3niyMkwmixoLAWX--Quh0u&ust=1667395395373000&source=images&cd=vfe&ved=0CA0QjRxqFwoTCKj6p4SKjfsCFQAAAAAdAAAAABAm')");

                entity.Property(e => e.Nome).HasMaxLength(50);

                entity.HasOne(d => d.IdFornitoreNavigation)
                    .WithMany(p => p.Prodotti)
                    .HasForeignKey(d => d.IdFornitore)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Prodotti_Fornitori");
            });

            modelBuilder.Entity<Taglie>(entity =>
            {
                entity.HasKey(e => e.IdTaglia);

                entity.ToTable("Taglie");

                entity.Property(e => e.Nome).HasMaxLength(50);
            });

            modelBuilder.Entity<TaglieProdotti>(entity =>
            {
                entity.ToTable("TaglieProdotti");

                entity.HasOne(d => d.IdProdottoNavigation)
                    .WithMany(p => p.TaglieProdotti)
                    .HasForeignKey(d => d.IdProdotto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Prodotti_TaglieProdotti");

                entity.HasOne(d => d.IdTagliaNavigation)
                    .WithMany(p => p.TaglieProdotti)
                    .HasForeignKey(d => d.IdTaglia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Taglie_TaglieProdotti");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
