using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public partial class Kullanici_Tbl
    {
        public Kullanici_Tbl()
        {
            Film_Tbl = new HashSet<Film_Tbl>();
        }

        public Guid KullaniciId { get; set; }
        public string KullaniciAdi { get; set; } = null!;
        public string Sifre { get; set; } = null!;

        public virtual ICollection<Film_Tbl> Film_Tbl { get; set; }
    }
}
