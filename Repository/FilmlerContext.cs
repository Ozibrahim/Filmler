using Entity.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;

namespace Repository
{
    public partial class FilmlerContext : DbContext
    {
        public FilmlerContext()
        {
        }

        public FilmlerContext(DbContextOptions<FilmlerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Film_Tbl> Film_Tbl { get; set; } = null!;
        public virtual DbSet<Kategori_Tbl> Kategori_Tbl { get; set; } = null!;
        public virtual DbSet<Kullanici_Tbl> Kullanici_Tbl { get; set; } = null!;
        public virtual DbSet<Oyuncu_Tbl> Oyuncu_Tbl { get; set; } = null!;
        public virtual DbSet<Yonetmen_Tbl> Yonetmen_Tbl { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-I8RD6T2;Database=Filmler;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film_Tbl>(entity =>
            {
                entity.HasKey(e => e.FilmId);

                entity.Property(e => e.FilmAd)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FilmAfis)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FilmKonu).IsUnicode(false);

                entity.Property(e => e.FilmPuan).HasColumnType("decimal(3, 1)");

                entity.Property(e => e.FilmYapimYili).HasColumnType("datetime");

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("datetime");

                entity.HasOne(d => d.Kategori)
                    .WithMany(p => p.Film_Tbl)
                    .HasForeignKey(d => d.KategoriId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Film_Tbl_Kategori_Tbl");

                entity.HasOne(d => d.OlusturanNavigation)
                    .WithMany(p => p.Film_Tbl)
                    .HasForeignKey(d => d.Olusturan)
                    .HasConstraintName("FK_Film_Tbl_Kullanici_Tbl");

                entity.HasOne(d => d.Yonetmen)
                    .WithMany(p => p.Film_Tbl)
                    .HasForeignKey(d => d.YonetmenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Film_Tbl_Yonetmen_Tbl");
            });

            modelBuilder.Entity<Kategori_Tbl>(entity =>
            {
                entity.HasKey(e => e.KategoriId);

                entity.Property(e => e.KategoriAd)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Kullanici_Tbl>(entity =>
            {
                entity.HasKey(e => e.KullaniciId);

                entity.Property(e => e.KullaniciId).ValueGeneratedNever();

                entity.Property(e => e.KullaniciAdi)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sifre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Oyuncu_Tbl>(entity =>
            {
                entity.HasKey(e => e.OyuncuId);

                entity.Property(e => e.OyuncuAd)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OyuncuSoyad)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.Oyuncu_Tbl)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Oyuncu_Tbl_Film_Tbl");
            });

            modelBuilder.Entity<Yonetmen_Tbl>(entity =>
            {
                entity.HasKey(e => e.YonetmenId);

                entity.Property(e => e.YonetmenAd)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.YonetmenSoyad)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
