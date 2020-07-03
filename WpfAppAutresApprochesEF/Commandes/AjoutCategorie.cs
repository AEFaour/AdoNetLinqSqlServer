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
    public class AjoutCategorie : ICommand
    {
        private GestionBiblio gestionBiblio;

        public AjoutCategorie(GestionBiblio gestionBiblio)
        {
            this.gestionBiblio = gestionBiblio;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {


            if (parameter == null || String.IsNullOrEmpty(((Categorie)parameter).libelle))
            {
                return false;
            }
            else
            {
                string _s = ((Categorie)parameter).libelle;
                return (_s.Trim().Length >= 5);
            }


        }

        public void Execute(object parameter)
        {
            Categorie categorie = (Categorie)parameter;
            GestionBiblio.AjouterUneCategorie(categorie);
        }
    }
}
