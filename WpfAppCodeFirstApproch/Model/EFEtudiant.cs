using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppCodeFirstApproch.Model
{
    class EFEtudiant : DbContext
    {
        public DbSet<Etudiant> Etudiant { get; set; }
        public DbSet<Cours> Cours { get; set; }

        public EFEtudiant() : base("ConnexionDBCours")
        {
        }
    }
}
