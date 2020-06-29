using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppCodeFirstApproch.Model
{
    class Film
    {
        [Key]
        // Puisque l'attribut contient Id, normalement c'est implicite
        // /!\ : Parfois ne fonctionne pas --bug
        public int Id { get; set; }
        public string Titre { get; set; }
        public int Duree { get; set; }
        public string Resume { get; set; }
        public int Annee { get; set; }

        // L'association va se traduire par une propriété de navigation

        public virtual ICollection<Categorie> Categories { get; set; }
        // Modifcation de la structure de la base;
        // - Add migration, Enable-Migration, updateMigration
    }
}
