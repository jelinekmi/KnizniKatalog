using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace KnizniKatalog
{
    public class KatalogBase
    {
        public int Id { get; set; }
        public int KnihaId { get; set; }
        public int UzivatelId { get; set; }
        public DateTime DatumPridani { get; set; }
        public string Poznamka { get; set; }
    }
}