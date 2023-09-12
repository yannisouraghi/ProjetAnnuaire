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
    /// Logique d'interaction pour ModifierPage.xaml
    /// </summary>
    public partial class ModifierPage : Page
    {
        public ModifierPage()
        {
            InitializeComponent();
        }
        private void Rechercher_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Modifié");
        }
        private void AppliquerModifications_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Modifications appliquées");
        }
    }
}
