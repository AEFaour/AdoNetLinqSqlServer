using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCodeFirst.Model
{
    class Genre
    {
        [Key]

        public int Id { get; set; }
        public string Libelle { get; set; }
        // Pour un genre , on peut avoir plusieurs films
        public virtual ICollection<Film> Films { get; set; }
    }
}
