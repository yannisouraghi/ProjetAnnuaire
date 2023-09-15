using System;
using System.Windows;
using System.Windows.Controls;

namespace ProjetAnnuaire
{
    public partial class FicheEmployee : Page
    {
        // Propriété pour le ViewModel
        public FicheEmployeeViewModel ViewModel { get; set; }

        public FicheEmployee(FicheEmployeeViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            DataContext = ViewModel;
        }

        public void Retour_Click(object sender, RoutedEventArgs e)
        {
            if (Window.GetWindow(this) is MainWindow mainWindow)
            {
                mainWindow.NavigateToRechercherPage();
            }
        }
    }
}
