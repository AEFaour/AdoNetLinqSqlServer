﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppCodeFirstApproch.Model
{
    class Categorie
    {
        [Key]

        public int Id { get; set; }
        public string Libelle { get; set; }


        // un film peut être un film d'action -- un film d'avanture ...
        // Dans une categorie, on peut avoir plusieurs films

        public virtual ICollection<Film> Films { get; set; }
    }
}
