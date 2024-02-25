using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class Oyuncu_Tbl
    {
        public int OyuncuId { get; set; }
        public int FilmId { get; set; }
        public string OyuncuAd { get; set; } = null!;
        public string OyuncuSoyad { get; set; } = null!;
        public bool OyuncuCinsiyet { get; set; }
        public bool? Silindi { get; set; }

        public virtual Film_Tbl Film { get; set; } = null!;
    }
}
