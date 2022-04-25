using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPresentasi.Domain
{
    public class Samurai
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Quote> Quotes { get; set; } = new List<Quote>(); // menambahkan relasi
        public List<Battle> Battles { get; set; } = new List<Battle>();//bisa dianggap penanda hubungan many to many
        public Horse Horse { get; set; } // Relasi OneToOne ==> tidak perlu di regist DbSet nya.
        public List<Sword> Swords { get; set; } = new List<Sword>(); // one to many dengan pedang
    }
}
