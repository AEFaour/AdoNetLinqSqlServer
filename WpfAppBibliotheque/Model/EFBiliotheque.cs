using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppBibliotheque.Model
{
    class EFBiliotheque : DbContext

    {
        public DbSet<Livre> Livres { get; set; }
        public DbSet<Auteur> Auteurs { get; set; }

        public EFBiliotheque() : base("BiblioCnx")
        {
        }
    }
}
