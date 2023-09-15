using APIAnnuaire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;
using ProjetAnnuaire;

namespace ProjetAnnuaire
{
    public partial class RechercherPage : Page
    {
        public RechercherPage()
        {
            DataContext = Application.Current.MainWindow;
            InitializeComponent();
            InitializeServicesComboBoxAsync();
            InitializeSiteComboBoxAsync();
        }
        private async void Search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var httpClient = new HttpClient();
                var baseUri = "https://localhost:7053";
                var uri = $"{baseUri}/api/Employee/Search";
                // Construisez l'URI avec les paramètres de recherche
                var queryParams = new List<string>();
                
                if (!string.IsNullOrEmpty(txtSearchByName.Text))
                    queryParams.Add($"name={Uri.EscapeDataString(txtSearchByName.Text)}");

                var selectedSitesViewModel = (ProjetAnnuaire.Sites)City.SelectedItem;

                if (selectedSitesViewModel != null)
                {
                    var selectedSite = selectedSitesViewModel.City;
                    queryParams.Add($"site={Uri.EscapeDataString(selectedSite)}");
                }

                var selectedServiceViewModel = (ProjetAnnuaire.Services)Services.SelectedItem;

                if (selectedServiceViewModel != null)
                {
                    var selectedService = selectedServiceViewModel.Service;
                    queryParams.Add($"service={Uri.EscapeDataString(selectedService)}");
                }

                if (queryParams.Any())
                    uri += "?" + string.Join("&", queryParams);

                var response = await httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    // Traitez la réponse JSON ici
                    var jsonResult = await response.Content.ReadAsStringAsync();
                    var employees = JsonConvert.DeserializeObject<List<Employees>>(jsonResult);

                    // Lier les résultats au DataGrid
                    EmployeesData.ItemsSource = employees;
                }
                else
                {
                    MessageBox.Show($"Erreur lors de la requête API : {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }


        private async Task InitializeServicesComboBoxAsync()
        {
            try
            {
                var httpClient = new HttpClient();
                var baseUri = "https://localhost:7053";
                var uri = $"{baseUri}/api/Service/Services"; // Assurez-vous que l'URL est correcte

                var response = await httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResult = await response.Content.ReadAsStringAsync();
                    var services = JsonConvert.DeserializeObject<List<Services>>(jsonResult);
                    Services.ItemsSource = services;
                }
                else
                {
                    MessageBox.Show($"Erreur lors de la requête API : {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        private async Task InitializeSiteComboBoxAsync()
        {
            try
            {
                var httpClient = new HttpClient();
                var baseUri = "https://localhost:7053";
                var uri = $"{baseUri}/api/Site"; // Assurez-vous que l'URL est correcte

                var response = await httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResult = await response.Content.ReadAsStringAsync();
                    var site = JsonConvert.DeserializeObject<List<Sites>>(jsonResult);
                    City.ItemsSource = site;
                }
                else
                {
                    MessageBox.Show($"Erreur lors de la requête API : {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        private void EffacerButton_Click(object sender, RoutedEventArgs e)
        {
            // Réinitialiser les ComboBox et le TextBlock
            Services.SelectedIndex = -1;
            City.SelectedIndex = -1;
            txtSearchByName.Text = string.Empty;
        }

        private void DataGridDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Récupérez l'employé sélectionné dans le DataGrid
            var selectedEmployee = (Employees)EmployeesData.SelectedItem;

            if (selectedEmployee != null)
            {
                // Créez une instance du ViewModel avec les données de l'employé
                var ficheEmployeeViewModel = new FicheEmployeeViewModel
                {
                    LastName = selectedEmployee.LastName,
                    FirstName = selectedEmployee.FirstName,
                    JobTitle = selectedEmployee.JobTitle,
                    JobDescription = selectedEmployee.JobDescription,
                    PhoneNumber = selectedEmployee.PhoneNumber,
                    MobilePhone = selectedEmployee.MobilePhone,
                    Email = selectedEmployee.Email,
                    Service = selectedEmployee.Service,
                    City = selectedEmployee.City
                };

                // Obtenez une référence au Frame nommé "contentFrame" de la page MainWindow
                if (this.DataContext is MainWindow mainWindow)
                {
                    mainWindow.NavigateToFicheEmployee(ficheEmployeeViewModel);
                }
            }
        }



    }
}
