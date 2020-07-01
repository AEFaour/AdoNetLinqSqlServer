using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppBibliotheque.Model
{
    class Auteur
    {
        [Key]

        public int Id { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
    }
}
