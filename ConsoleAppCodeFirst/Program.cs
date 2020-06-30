using ConsoleAppCodeFirst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            AjoutFilm();

            Console.ReadKey();
        }

        private static void AjoutFilm()
        {
            using (EFVideotheque dtc = new EFVideotheque())
            {
                dtc.Films.Add(new Film() { Annee = 2010, Resume = "Un si beau film", Titre = "Sur la route de Maison" });
                int i = dtc.SaveChanges();

            }
        }
    }
}
