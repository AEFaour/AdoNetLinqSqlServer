using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLinqPremierTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tab
            int[] _tab = { 12, 15, 18, 19, 20, 8, 11 };


            // Les éléments du tab qui sont > 15
            // Leur nombre ? 

            var _result = from elt in _tab
                          where elt > 15
                          select elt;

            // Pout le moment le requette n'est pas executée 
            // Pour l'executer il faut parcourir la liste 

            foreach (var item in _result)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey(); // Figer l'affichage
        }
    }
}
