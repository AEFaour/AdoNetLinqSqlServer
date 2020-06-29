using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppCodeFirstApproch.Model
{
    // Cette class sera notre "Conteneur de Données" -- DataContext
    class EFVideotheque : DbContext
    {
        // Définir les DbSet --> les classes qui seront mappées

        public DbSet<Film> Films { get; set; }
        public DbSet<Categorie> Categories { get; set; }

        // utiliser une chaine de connexion par appel du constructeur

        // La Chaine de connexion sous permet d'avoir le chemin vers la base de donnée

        public EFVideotheque() : base("ChaineCnx")
        {

        }
    }


}
