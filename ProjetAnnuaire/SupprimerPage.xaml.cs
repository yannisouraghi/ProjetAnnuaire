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
    /// Logique d'interaction pour SupprimerPage.xaml
    /// </summary>
    public partial class SupprimerPage : Page
    {
        public SupprimerPage()
        {
            InitializeComponent();
        }
        private void SearchToDelete_Click()
        {
            MessageBox.Show("Supprimé");
        }
        private void EmployeeDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EmployeeDataGrid.SelectedItems.Count > 0)
            {
                AppliquerModificationsButton.IsEnabled = true;
            }
            else
            {
                AppliquerModificationsButton.IsEnabled = false;
            }
        }
        private void SearchToDelete_Click(object sender, RoutedEventArgs e)
        {
            // Code pour rechercher les employés à supprimer
            // Remplir le DataGrid avec les résultats
        }

        private void DeleteSelected_Click(object sender, RoutedEventArgs e)
        {
            // Récupérer les éléments sélectionnés dans le DataGrid

            // Code pour supprimer les employés sélectionnés
            // Assurez-vous de mettre à jour la source de données et de rafraîchir le DataGrid
        }
    }
}
