using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class Yonetmen_Tbl
    {
        public Yonetmen_Tbl()
        {
            Film_Tbl = new HashSet<Film_Tbl>();
        }

        public int YonetmenId { get; set; }
        public string YonetmenAd { get; set; } = null!;
        public string YonetmenSoyad { get; set; } = null!;
        public bool YonetmenCinsiyet { get; set; }
        public bool Silindi { get; set; }

        public virtual ICollection<Film_Tbl> Film_Tbl { get; set; }
    }
}
