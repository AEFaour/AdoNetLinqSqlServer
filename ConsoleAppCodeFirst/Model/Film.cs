using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCodeFirst.Model
{
    class Film
    {
        [Key]
        public int Id { get; set; }
        public string Titre { get; set; }
        public int Duree { get; set; }
        public string Resume { get; set; }
        public int Annee { get; set; }

        // A un film, on peut associer plusieurs genres : Aventure, Action, Humour

        //public virtual ICollection<Genre> Genres { get; set; }
        // Modifcation de la structure de la base;
        // - Add migration, Enable-Migration, updateMigration
        // On completera dans le cadre d'une migration
    }
}
