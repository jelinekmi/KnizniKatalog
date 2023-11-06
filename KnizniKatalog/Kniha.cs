using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace KnizniKatalog
{
    public class Kniha
    {
        public int Id { get; set; }
        public string Nazev { get; set; }
        public string Autor { get; set; }
        public int RokVydani { get; set; }
        public string Popis { get; set; }
    }
}
