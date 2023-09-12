using APIAnnuaire.Models;
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

namespace ProjetAnnuaire
{
    /// <summary>
    /// Logique d'interaction pour AjouterPage.xaml
    /// </summary>
    public partial class AjouterPage : Page
    {

        public AjouterPage()
        {
            InitializeComponent();
        }
        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
               MessageBox.Show("Ajouté");
        }
    }
}
