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
using WpfAppAutresApprochesEF.Model5LinqToSQL;

namespace WpfAppAutresApprochesEF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static DataClasses1DataContext dtx = new DataClasses1DataContext();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DBML_Afficher_FilmGenre_Click(object sender, RoutedEventArgs e)
        {
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
    }
}
