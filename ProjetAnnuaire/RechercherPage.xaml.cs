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
    /// Logique d'interaction pour RechercherPage.xaml
    /// </summary>
    public partial class RechercherPage : Page
    {
        public RechercherPage()
        {
            InitializeComponent();
        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            var SearchSite = txtSearchBySite.Text;
            var SearchName = txtSearchByName.Text;
            var SearchService = txtSearchByService.Text;

            MessageBox.Show("Recherche par site : " + SearchSite + "\nRecherche par nom : " + SearchName + "\nRecherche par service : " + SearchService);

            //if (SearchSite != "")
            //{
            //    var result = Employees.Where(x => x.Site == SearchSite);
            //    Employees.Clear();
            //    foreach (Employee employee in result)
            //    {
            //        Employees.Add(employee);
            //    }
            //}
            //if (SearchName != "")
            //{
            //    var result = Employees.Where(x => x.LastName == SearchName);
            //    Employees.Clear();
            //    foreach (Employee employee in result)
            //    {
            //        Employees.Add(employee);
            //    }
            //}
            //if (SearchService != "")
            //{
            //    var result = Employees.Where(x => x.Service == SearchService);
            //    Employees.Clear();
            //    foreach (Employee employee in result)
            //    {
            //        Employees.Add(employee);
            //    }
            //}

        }
    }
}
