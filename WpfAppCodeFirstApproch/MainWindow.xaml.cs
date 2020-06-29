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
using WpfAppCodeFirstApproch.Model;

namespace WpfAppCodeFirstApproch
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TastAccesDB_Click(object sender, RoutedEventArgs e)
        {
            Model.EFVideotheque dtc = new Model.EFVideotheque();
            using (dtc)
            {

                dtc.Categories.Add(
                    new Model.Categorie() { Id = 11, Libelle = "Comedie" }
                    );

                int i = dtc.SaveChanges();
            }

        }

        private void TastAccesDB_Cours_Click(object sender, RoutedEventArgs e)
        {
            EFEtudiant dtc = new EFEtudiant();
            using (dtc)
            {
                dtc.Cours.Add(new Cours() { Libelle = "Math" });
                dtc.Cours.Add(new Cours() { Libelle = "Chimie" });
                int i = dtc.SaveChanges();
            }
        }
    }
}
