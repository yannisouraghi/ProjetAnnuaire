using APIAnnuaire.Models;
using Newtonsoft.Json;
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
            InitializeServicesComboBoxAsync();
            InitializeSiteComboBoxAsync();
        }

        private async void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Récupérez les données entrées par l'utilisateur depuis les TextBox
                string firstName = FirstNameTextBox.Text;
                string lastName = LastNameTextBox.Text;
                string department = DepartmentTextBox.Text;
                string email = EmailTextBox.Text;
                string phoneNumber = PhoneTextBox.Text;
                string mobilePhone = MobileTextBox.Text;
                string jobTitle = JobTitleTextBox.Text;
                string jobDescription = JobDescriptionTextBox.Text;

                ProjetAnnuaire.Sites selectedSite = (ProjetAnnuaire.Sites)Site.SelectedItem;
                string site = selectedSite?.City;

                ProjetAnnuaire.Services selectedService = (ProjetAnnuaire.Services)Service.SelectedItem;
                string service = selectedService?.Service;



                // Créez une URL avec les données à envoyer à l'API
                string apiUrl = $"https://localhost:7053/api/Employee/FirstName/{firstName}/LastName/{lastName}/Department/{department}/Email/{email}/PhoneNumber/{phoneNumber}/MobilePhone/{mobilePhone}/JobTitle/{jobTitle}/JobDescription/{jobDescription}/Site/{site}/Service/{service}";

                // Initialisez un client HTTP
                using (HttpClient client = new HttpClient())
                {
                    // Envoyez une requête POST à l'API pour ajouter l'employé
                    HttpResponseMessage response = await client.PostAsync(apiUrl, new StringContent(string.Empty, Encoding.UTF8, "application/json"));

                    // Vérifiez la réponse de l'API
                    if (response.IsSuccessStatusCode)
                    {
                        // L'employé a été ajouté avec succès
                        MessageBox.Show("Employé ajouté avec succès !");
                    }
                    else
                    {
                        // Il y a eu une erreur lors de l'ajout de l'employé
                        MessageBox.Show("Une erreur s'est produite lors de l'ajout de l'employé.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur s'est produite : {ex.Message}");
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
                    Service.ItemsSource = services;
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
                    Site.ItemsSource = site;
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

