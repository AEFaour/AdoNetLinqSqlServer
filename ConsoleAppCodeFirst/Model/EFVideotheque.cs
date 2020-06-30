using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCodeFirst.Model
{
    class EFVideotheque : DbContext
    {
        public EFVideotheque() : base("CnxVideotheque")
        {

        }
        public DbSet<Film> Films { get; set; }
        public DbSet<Genre> Genres { get; set; }
        // On met à jour le fichier App.config avec la chaine
    }
}
