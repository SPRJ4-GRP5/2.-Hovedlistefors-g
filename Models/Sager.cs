using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hovedliste.Models
{
    public class Sager
    {
        public int Id { get; set; }
        public int Billede { get; set; }
        public string Emne { get; set; }
        public string Tekst { get; set; }
        public string Fag { get; set; }
        public int Semester { get; set; }
    }
}
