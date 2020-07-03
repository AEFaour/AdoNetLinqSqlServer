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
        public static Model1Container dtc;
        private static ObservableCollection<Livre> livres;

        private static ObservableCollection<Auteur> auteurs;

        private static ObservableCollection<Categorie> categories;

        public AjoutLivre AjoutLivre { get; set; }
        public Action1 Action1 { get; set; }
        public Action2 Action2 { get; set; }
        public AjoutCategorie AjoutCategorie { get; set; }

        private Livre livre;
        private Auteur auteur;
        private Categorie categorie;

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



        public Livre Livre
        {
            get => livre;
            set => livre = value;
        }
        public Auteur Auteur
        {
            get => auteur;
            set => auteur = value;
        }
        public Categorie Categorie
        {
            get => categorie;
            set => categorie = value;
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
            AjoutCategorie = new AjoutCategorie(this);
            Action1 = new Action1(this);
            Action2 = new Action2(this);
            Livre = new Livre();
            Auteur = new Auteur();
            Categorie = new Categorie();

        }



        public static int AjouterUnLivre(Livre livre)
        {
            dtc.Livres.Add(livre);
            livres.Add(livre);
            return dtc.SaveChanges();
        }

        internal static void AjouterUneCategorie(Categorie categorie)
        {
            // dtc.Categories.Add(categorie);
            int i = dtc.AjoutCategorie(categorie.libelle);
            dtc.SaveChanges();
            categories.Add(categorie);
        }
        public void Dispose()
        {
            dtc.Dispose();
        }
    }
}
