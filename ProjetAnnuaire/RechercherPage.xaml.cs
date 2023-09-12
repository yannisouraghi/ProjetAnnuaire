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

namespace ProjetAnnuaire
{
    /// <summary>
    /// Logique d'interaction pour RechercherPage.xaml
    /// </summary>
    public partial class RechercherPage : Page
    {
        public RechercherPage()
        {
            InitializeComponent();
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
                if (!string.IsNullOrEmpty(txtSearchBySite.Text))
                    queryParams.Add($"site={Uri.EscapeDataString(txtSearchBySite.Text)}");
                if (!string.IsNullOrEmpty(txtSearchByName.Text))
                    queryParams.Add($"name={Uri.EscapeDataString(txtSearchByName.Text)}");
                if (!string.IsNullOrEmpty(txtSearchByService.Text))
                    queryParams.Add($"service={Uri.EscapeDataString(txtSearchByService.Text)}");

                if (queryParams.Any())
                    uri += "?" + string.Join("&", queryParams);

                var response = await httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    // Traitez la réponse JSON ici
                    var jsonResult = await response.Content.ReadAsStringAsync();
                    var employees = JsonConvert.DeserializeObject<List<Employee>>(jsonResult);

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

        

    }
}
