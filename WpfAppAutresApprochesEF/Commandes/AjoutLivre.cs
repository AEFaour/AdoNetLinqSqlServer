using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfAppAutresApprochesEF.Model;
using WpfAppAutresApprochesEF.ViewModel;

namespace WpfAppAutresApprochesEF.Commandes
{
    public class AjoutLivre : ICommand
    {
        private GestionBiblio gestionBiblio;

        public AjoutLivre()
        {

        }

        public AjoutLivre(GestionBiblio gestionBiblio)
        {
            this.gestionBiblio = gestionBiblio;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Auteur a = gestionBiblio.Auteur;
            Categorie categorie = gestionBiblio.Categorie;
            Livre livre = (Livre)parameter;
            livre.Auteurs.Add(a);
            livre.Categorie = categorie;
            GestionBiblio.AjouterUnLivre(livre);


        }
    }
}
