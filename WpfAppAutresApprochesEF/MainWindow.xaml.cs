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
using WpfAppAutresApprochesEF.Model;
using WpfAppAutresApprochesEF.Model5EF;
using WpfAppAutresApprochesEF.Model5LinqToSQL;
using WpfAppAutresApprochesEF.ViewModel;

namespace WpfAppAutresApprochesEF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static DataClasses1DataContext dtx = new DataClasses1DataContext();
        private GestionBiblio gestionBiblio = new GestionBiblio();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = gestionBiblio;
        }
        private static bool alterner = true;
        private void DBML_Afficher_FilmGenre_Click(object sender, RoutedEventArgs e)
        {
            if (alterner)
            {
                var _result1 = from f in dtx.Films
                               join fg in dtx.GenreFilms on
                               f.Id equals fg.Film_Id
                               join g in dtx.Genres on
                               fg.Genre_Id equals g.Id
                               select new { f.Id, f.Titre, f.Annee, g.Libelle };
                var _result2 = dtx.Films.Join(dtx.GenreFilms,
                    f => f.Id,
                    gf => gf.Film_Id,
                    (f, gf) => new { f.Id, f.Titre, f.Annee, gf.Genre_Id }
                    ).Join(dtx.Genres,
                    fgf => fgf.Genre_Id,
                    g => g.Id,
                    (fgf, g) => new { fgf.Id, fgf.Titre, fgf.Annee, g.Libelle });
                dtgDBML.ItemsSource = _result2.ToList();
            }
            else
            {
                //using (BBVideotheque2Entities dtc = new BBVideotheque2Entities())
                //{
                //    var _result = from f in dtc.Films
                //                  from g in f.Genres
                //                  select new { f.Id, f.Titre, f.Annee, g.Libelle };
                //    dtgDBML.ItemsSource = _result.ToList();
                //}
            }
            alterner = !alterner;
            //using (DataClasses1DataContext dtx = new DataClasses1DataContext())
            //{

            //}

            // Les films et leur caategorie
            //var _result1 = from f in dtx.Films
            //               join fg in dtx.GenreFilms on
            //               f.Id equals fg.Film_Id
            //               select new { f.Id, f.Titre, f.Annee, fg.Genre_Id };

            //var _result2 = from f in _result1.ToList()
            //               join g in dtx.Genres on
            //               f.Genre_Id equals g.Id
            //               select new { f.Id, f.Titre, f.Annee, g.Libelle };


        }


        private void AjoutLivre_Click(object sender, RoutedEventArgs e)
        {
            //Glue Code // + couplage (adherence) entre l'IHM et le code behind
            // Pour réduire ce couplage --> on utilise les commands
            Livre l = new Livre();
            l.Titre = txtTitre.Text;
            l.ISBN = int.Parse(txtISBN.Text);
            l.AnneeParuation = txtAnnee.Text;
            // attacher un auteur 

            Auteur a = (Auteur)cbbAuteur.SelectedItem;

            l.Auteurs.Add(a);
            //Atacher une categorie
            Categorie c = (Categorie)cbbCategorie.SelectedItem;
            l.Categorie = c;
            GestionBiblio.AjouterUnLivre(l);
        }
    }
}
