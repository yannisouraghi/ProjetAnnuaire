using APIAnnuaire.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HttpClient _httpClient;

        public ObservableCollection<Employee> Employees { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Employees = new ObservableCollection<Employee>();
            _httpClient = new HttpClient();

            LoadEmployees();
            DataContext = this;
        }

        private async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("https://localhost:7053/api/Employee");

            if (response.IsSuccessStatusCode)
            {
                var contentStream = await response.Content.ReadAsStreamAsync();
                var employees = await System.Text.Json.JsonSerializer.DeserializeAsync<IEnumerable<Employee>>(contentStream);
                return employees;
            }
            else
            {
                return new List<Employee>();
            }
        }


        private async void LoadEmployees()
        {
            IEnumerable<Employee> employees = await GetAllEmployees();
            foreach (Employee employee in employees)
            {
                Employees.Add(employee);
            }
        }


        private void Search_Click(object sender, RoutedEventArgs e)
        {
            LoadEmployees();
        }
    }
}
