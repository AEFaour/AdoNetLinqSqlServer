using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppAutresApprochesEF.Commandes;
using WpfAppAutresApprochesEF.Model;

namespace WpfAppAutresApprochesEF.ViewModel
{
    public class GestionBiblio : IDisposable
    {
        private static Model1Container dtc;
        private static ObservableCollection<Livre> livres;

        private static ObservableCollection<Auteur> auteurs;

        private static ObservableCollection<Categorie> categories;

        public AjoutLivre AjoutLivre { get; set; }
        public Action1 Action1 { get; set; }
        public Action2 Action2 { get; set; }

        public ObservableCollection<Livre> Livres
        {
            get { return livres; }
            set { livres = value; }
        }
        public ObservableCollection<Auteur> Auteurs
        {
            get { return auteurs; }
            set { auteurs = value; }
        }
        public ObservableCollection<Categorie> Categories
        {
            get => categories; // Syntaxe c# auto
            set => categories = value;
        }



        public GestionBiblio()
        {
            if (dtc == null)
            {
                dtc = new Model1Container();
            }
            if (livres == null)
            {
                livres = new ObservableCollection<Livre>(dtc.Livres);
            }
            if (auteurs == null)
            {
                auteurs = new ObservableCollection<Auteur>(dtc.Auteurs);
            }
            if (categories == null)
            {
                categories = new ObservableCollection<Categorie>(dtc.Categories);
            }
            AjoutLivre = new AjoutLivre(this);
            Action1 = new Action1(this);
            Action2 = new Action2(this);
        }



        public static int AjouterUnLivre(Livre livre)
        {
            dtc.Livres.Add(livre);
            livres.Add(livre);
            return dtc.SaveChanges();
        }

        public void Dispose()
        {
            dtc.Dispose();
        }
    }
}
