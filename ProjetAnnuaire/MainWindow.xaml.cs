using APIAnnuaire.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
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
using System.IO;
using System.Text.Json.Serialization;


namespace ProjetAnnuaire
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HttpClient _httpClient;

        public ObservableCollection<Employees> Employees { get; set; }

        public Visibility AdminExpanderVisibility
        {
            get { return (Visibility)GetValue(AdminExpanderVisibilityProperty); }
            set { SetValue(AdminExpanderVisibilityProperty, value); }
        }

        public static readonly DependencyProperty AdminExpanderVisibilityProperty =
            DependencyProperty.Register("AdminExpanderVisibility", typeof(Visibility), typeof(MainWindow), new PropertyMetadata(Visibility.Collapsed));



        public MainWindow()
        {
            InitializeComponent();
            this.Width = 900;
            this.Height = 475;
            Employees = new ObservableCollection<Employees>();
            _httpClient = new HttpClient();
            CommandBindings.Add(new CommandBinding(OpenAdminCommand, OpenAdminCommand_Executed, OpenAdminCommand_CanExecute));
            InputBindings.Add(new KeyBinding(OpenAdminCommand, new KeyGesture(Key.A, ModifierKeys.Control)));
            
            //LoadEmployees();
            DataContext = this;
        }
       
        private void Deconnexion_Click(object sender, RoutedEventArgs e)
        {
            AdminExpanderVisibility = Visibility.Collapsed;
        }

        private void RechercherButton_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new Uri("RechercherPage.xaml", UriKind.Relative));
        }
        private void AjouterButton_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new Uri("AjouterPage.xaml", UriKind.Relative));
        }
        private void ModifierButton_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new Uri("ModifierPage.xaml", UriKind.Relative));
        }
        private void SupprimerButton_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new Uri("SupprimerPage.xaml", UriKind.Relative));
        }


        //private async Task<IEnumerable<Employee>> GetAllEmployees()
        //{
        //    HttpResponseMessage response = await _httpClient.GetAsync("https://localhost:7053/api/Employee");

        //    if (response.IsSuccessStatusCode)
        //    {
        //        using (var contentStream = await response.Content.ReadAsStreamAsync())
        //        {
        //            var employees = await System.Text.Json.JsonSerializer.DeserializeAsync<IEnumerable<Employee>>(contentStream);
        //            return employees;
        //        }
        //    }
        //    else
        //    {
        //        return new List<Employee>();
        //    }
        //}
        public static RoutedCommand OpenAdminCommand = new RoutedCommand();

        private void OpenAdminCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenAdminWindow();
        }

        private void OpenAdminCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // Vous pouvez ajouter ici des conditions pour activer ou désactiver la commande si nécessaire.
            e.CanExecute = true;
        }

        private void OpenAdminWindow()
        {
            PasswordDialog passwordWindow = new PasswordDialog();
            bool? result = passwordWindow.ShowDialog();

            if (result == true && passwordWindow.EnteredPassword == "admin")
            {
                // Le mot de passe est correct, affichez le AdminExpander
                AdminExpanderVisibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Mot de passe incorrect");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }




        // Appeler cette méthode pour ouvrir la fenêtre admin





        //private async void LoadEmployees()
        //{
        //    IEnumerable<Employee> employees = await GetAllEmployees();
        //    foreach (Employee employee in employees)
        //    {
        //        MessageBox.Show(employee.FirstName);
        //        Employees.Add(employee);
        //    }
        //}

    }
}
