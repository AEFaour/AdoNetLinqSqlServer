using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAppBibliotheque.Model;

namespace WpfAppBibliotheque
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IDisposable
    {
        private static EFBiliotheque dtc = new EFBiliotheque();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AjoutLivre_Click(object sender, RoutedEventArgs e)
        {
            //dtc.Livres.Add(new Livre
            //{
            //    Titre = "Le Contrat Social ",
            //    Description = "Philosphie - Lumières",
            //    Annee = 1765,
            //    Auteurs = new List<Auteur> {
            //new Auteur() {Prenom = "Jean-Jacques", Nom = "Rousseau" } }
            //});
            //dtc.Livres.Add(new Livre
            //{
            //    Titre = "Lettres et autres documents ",
            //    Description = "Philosphie 20 siecle",
            //    Annee = 1935,
            //    Auteurs = new List<Auteur> {
            //new Auteur() {Prenom = "Hannah", Nom = "Arendt" },
            //new Auteur() {Prenom = " Martin" , Nom = "Heidegger" } },
            //});

            dtc.Livres.Add(new Livre
            {
                Titre = "De la méthode dans les sciences ",
                Description = "Philosphie Sociale - 20 siecle",
                Annee = 1914,
                Auteurs = new List<Auteur> {
            new Auteur() {Prenom = "Émile", Nom = "Durkheim" },
            new Auteur() {Prenom = "Alfred", Nom = "Giard" },
            new Auteur() {Prenom = "Pierre", Nom = "Delbet" },
            new Auteur() {Prenom = "Henri" , Nom = "Bouasse" } },
            });
            int i = dtc.SaveChanges();
            ResDG.ItemsSource = dtc.Auteurs.ToList();

        }


        public void Dispose()
        {
            dtc.Dispose();
        }

        private static bool ok = true;

        private void InfosLivre_Click(object sender, RoutedEventArgs e)
        {
            var _resultlinq = from l in dtc.Livres
                              join a in dtc.Auteurs
                              on l.Id equals a.Id
                              select new { l.Titre, a.Prenom, a.Nom };


            var _resultLambda = dtc.Livres.Join(dtc.Auteurs,
                l => l.Id,
                a => a.Id,
                (l, a) => new { l.Titre, a.Prenom, a.Nom });

            if (ok)
            {
                ResTxt.Text = "from l in dtc.Livres join a in dtc.Auteurs on l.Id equals a.Idselect new { l.Titre, a.Prenom, a.Nom };";
                ResDG.ItemsSource = _resultlinq.ToList();
            }
            else
            {
                ResTxt.Text = " dtc.Livres.Join(dtc.Auteurs, l => l.Id, a => a.Id, (l, a) => new { l.Titre, a.Prenom, a.Nom }); ";
                ResDG.ItemsSource = _resultLambda.ToList();
            }
            ok = !ok;

        }
    }
}
