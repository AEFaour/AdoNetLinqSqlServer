using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using WpfAppRequetesLinq.Model;

namespace WpfAppRequetesLinq
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IDisposable
    {
        private static BBVideotheque2Entities dtc = new BBVideotheque2Entities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ImporterFilm_Click(object sender, RoutedEventArgs e)
        {

            // Ouvrir une boite de dialogue pour selectionner le bon fichier
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Selection le fichier text pour importer les pays";
            if (ofd.ShowDialog() == true)
            {
                StreamReader stream = new StreamReader(ofd.FileName); // Pointer un lecteur sur le fichier
                // récupérer le contenu du fichier
                string _contenu = stream.ReadToEnd();
                // Reconstruire chaque ligne du fichier --> en mettant le contenue sur forme de tableau
                string[] _lignes = _contenu.Split('\n');
                using (BBVideotheque2Entities dtc = new BBVideotheque2Entities())
                {
                    for (int i = 0; i < _lignes.Length; i++)
                    {
                        // Splitter chaque ligne en colonnes
                        string[] _col = _lignes[i].Split('#'); // # est le delimiteur de champs
                        if (_col.Length >= 4)
                        {
                            //Insérer dans la base 

                            Films f = new Films();
                            f.Titre = _col[0].Substring(1);
                            f.Resume = _col[1];
                            f.Annee = int.Parse(_col[2]);
                            f.Duree = (new Random()).Next(6, 13) * 10;

                            dtc.Films.Add(f);

                        }
                    }
                    int j = dtc.SaveChanges();
                    MessageBox.Show(j + " Enregistement Ajoutés");
                    dtgResultat.ItemsSource = dtc.Films.ToList();
                }

            }
        }

        private void TestObjetAnonyme()
        {
            Films f = new Films();

            var voiture = new { Couleur = "Rouge", kilometrage = 1200 };

            //voiture.Couleur = "Noire";

            string adresse = "120; Rue Victor Hugo; 92400";
            string[] _tabAdresse = adresse.Split(';');

            var ObjetAdresse = new { numero = _tabAdresse[0], rue = _tabAdresse[1], cp = _tabAdresse[2] };
        }

        private void Projection_Click(object sender, RoutedEventArgs e)
        {

            // new projection c'est une selection faite sur certains attributs;
            // A titre exceptionnel pour ce tp, on va utiliser ici
            // le database context

            var _result = from elt in dtc.Films
                          select elt;
            // _result contient alors tous les attributs
            // Pour récupérer uniquement le Titre et l'Anne, on va faire une PROJECTION

            var _result1 = from elt in dtc.Films select new { elt.Titre, elt.Annee };
            //Titre + Duree + Resume
            var _result2 = from elt in dtc.Films select new { elt.Titre, elt.Duree, elt.Resume };
            dtgResultat.ItemsSource = _result2.ToList();
            txtLinq.Text = "from elt in dtc.Films select new { elt.Titre, elt.Annee };";
        }


        private void ProjectionLambda_Click(object sender, RoutedEventArgs e)
        {

            var _result = dtc.Films.Select(x => new { x.Titre, x.Annee, x.Resume });

            dtgResultat.ItemsSource = _result.ToList();
            txtLinq.Text = "dtc.Films.Select(x => new { x.Titre, x.Annee, x.Resume});";
        }

        public void Dispose()
        {
            dtc.Dispose();
        }

        private static bool ok = true;
        private void WhereLinq_Click(object sender, RoutedEventArgs e)
        {
            // Les films dont le titre contient DINO

            if (ok)// Partie LINQ
            {
                var _result = from elt in dtc.Films
                              where elt.Titre.ToLower().Contains("dino")
                              select elt;

                dtgResultat.ItemsSource = _result.ToList();
                txtLinq.Text = "from elt in dtc.Films where elt.Titre.ToLower().Contains(\"dino\") select elt; ";
                ok = !ok;
            }
            else
            {
                //Exemple 1
                var _resultat = dtc.Films.Where(x => x.Titre.ToLower().Contains("dino"));
                txtLinq.Text = "dtc.Films.Where(x=>x.Titre.ToLower().Contains(\"dino\"));";
                //Exemple 2 
                _resultat = dtc.Films.Where(y => y.Resume.StartsWith("A"));
                txtLinq.Text = "dtc.Films.Where(y => y.Resume.StartsWith(\"A\"));";
                dtgResultat.ItemsSource = _resultat.ToList();
                ok = !ok;

            }

        }

        private void Join_Click(object sender, RoutedEventArgs e)
        {

            //
        }

        private void ManyToMany_Click(object sender, RoutedEventArgs e)
        {
            // pour le cas Many to Many : Films -> Genre
            var _resultat = from f in dtc.Films
                            from g in f.Genres
                            select new { f.Id, f.Titre, idGenre = g.Id, g.Libelle };
            txtLinq.Text = "from f in dtc.Films from g in f.Genres select new { f.Id, f.Titre, idGenre = g.Id, g.Libelle }; ";
            dtgResultat.ItemsSource = _resultat.ToList();

            // Many to Many : Genres -> Film (retrouver les filkms à partir de la classe genre)

            var _resultat1 = from g in dtc.Genres
                             from f in g.Films
                             select new { IDGenre = g.Id, g.Libelle, f.Id, f.Titre };
            txtLinq.Text = "from g in dtc.Genres from f in g.Films select new { IDGenre = g.Id, g.Libelle, f.Id, f.Titre  }; ";
            if (ok)
            {
                txtLinq.Text = "from g in dtc.Genres from f in g.Films select new { IDGenre = g.Id, g.Libelle, f.Id, f.Titre  }; ";
                dtgResultat.ItemsSource = _resultat1.ToList();
            }
            else
            {
                txtLinq.Text = "from f in dtc.Films from g in f.Genres select new { f.Id, f.Titre, idGenre = g.Id, g.Libelle }; ";
                dtgResultat.ItemsSource = _resultat.ToList();
            }
            ok = !ok;



        }
    }
}
