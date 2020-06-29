using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfListeFichierRepertoire
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

        private void ChangerFichier_Click(object sender, RoutedEventArgs e)
        {
            //Folderbrowser pour parcourrir les repertoires 
            //A importer depuis la bibliothèque Forms
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            //Un descriptif pour la boîte de dialogue
            fbd.Description = "Selectionner un repertoire";
            //Un repertoire de départ (de base)

            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            DialogResult result = fbd.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                string _rep = fbd.SelectedPath;
                // construire la liste des fichiers
                var _lstFic = Directory.GetFiles(_rep, "*.*", SearchOption.TopDirectoryOnly);
                cbbFics.ItemsSource = _lstFic;

                // On dispose d'une liste :

                //var _res = from elt in _lstFic
                //           where elt.Contains("doc")
                //           select elt;
            }
        }

        private void QuelReseau_Click(object sender, RoutedEventArgs e)
        {
            // Récupérer les interfaces réseau
            var interfacesReseau = NetworkInterface.GetAllNetworkInterfaces();
            // Construire une liste
            var _list = from i in interfacesReseau
                        select i.Name + " " + i.NetworkInterfaceType + " " + i.Description;
            lstReseau.ItemsSource = _list;
        }
    }
}
