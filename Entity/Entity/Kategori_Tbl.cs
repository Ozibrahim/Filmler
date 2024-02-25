using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class Kategori_Tbl
    {
        public Kategori_Tbl()
        {
            Film_Tbl = new HashSet<Film_Tbl>();
        }

        public int KategoriId { get; set; }
        public string KategoriAd { get; set; } = null!;
        public bool Silindi { get; set; }

        public virtual ICollection<Film_Tbl> Film_Tbl { get; set; }
    }
}
