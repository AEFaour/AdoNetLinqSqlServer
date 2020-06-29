using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppCodeFirstApproch.Model
{
    class Cours
    {
        [Key]

        public int Id { get; set; }
        public string Libelle { get; set; }


        public virtual ICollection<Etudiant> Etudiants { get; set; }
    }
}
