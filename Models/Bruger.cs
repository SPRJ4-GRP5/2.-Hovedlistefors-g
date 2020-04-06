using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hovedliste.Models
{
    public class Bruger
    {
        public int Email { get; set; } //Primary Key
        public string Password { get; set; }
        public string ProfilePictureName { get; set; }

    }
}
