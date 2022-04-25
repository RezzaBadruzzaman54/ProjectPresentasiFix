using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPresentasi.Domain
{
    public class Sword
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductionYear { get; set; }
        public double Weight { get; set; }
        public Samurai Samurai { get; set; } // one to many dengan samurai
        public int SamuraiId { get; set; } // forign key
        public List<Element> Elements { get; set; } = new List<Element>(); // many to many dengan pedang
    }
}
