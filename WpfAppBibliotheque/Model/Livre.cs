using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppBibliotheque.Model
{
    class Livre
    {
        [Key]

        public int Id { get; set; }
        public String Titre { get; set; }
        public string Description { get; set; }
        public int Annee { get; set; }
        public virtual ICollection<Auteur> Auteurs { get; set; }
    }
}
