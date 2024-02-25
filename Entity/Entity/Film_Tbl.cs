using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class Film_Tbl
    {
        public Film_Tbl()
        {
            Oyuncu_Tbl = new HashSet<Oyuncu_Tbl>();
        }

        public int FilmId { get; set; }
        public int KategoriId { get; set; }
        public int YonetmenId { get; set; }
        public string FilmAd { get; set; } = null!;
        public string FilmKonu { get; set; } = null!;
        public decimal? FilmPuan { get; set; }
        public string? FilmAfis { get; set; }
        public DateTime? FilmYapimYili { get; set; }
        public bool Silindi { get; set; }
        public Guid? Olusturan { get; set; }
        public DateTime? OlusturmaTarihi { get; set; }

        public virtual Kategori_Tbl Kategori { get; set; } = null!;
        public virtual Kullanici_Tbl? OlusturanNavigation { get; set; }
        public virtual Yonetmen_Tbl Yonetmen { get; set; } = null!;
        public virtual ICollection<Oyuncu_Tbl> Oyuncu_Tbl { get; set; }
    }
}
