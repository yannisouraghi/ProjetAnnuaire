using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using ProjetAnnuaire.Model;
using Prism.Commands;
using System.Net.Http;

namespace ProjetAnnuaire.ViewModel
{
    public class AjouterPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string firstName;
        private string lastName;
        private string department;
        private string email;
        private string phoneNumber;
        private string mobilePhone;
        private string jobTitle;
        private string jobDescription;

        private Services selectedService;
        private ObservableCollection<Services> services;

        private Sites selectedSite;
        private ObservableCollection<Sites> sites;

        public DelegateCommand AddEmployeeCommands { get; private set; }

        public AjouterPageViewModel()
        {
            AddEmployeeCommand = new DelegateCommand(AddEmployee, CanAddEmployee);
            services = new ObservableCollection<Services>();
            sites = new ObservableCollection<Sites>();

            // Vous pouvez également charger les listes de services et de sites ici
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                RaisePropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                RaisePropertyChanged("LastName");
            }
        }

        public string Department
        {
            get { return department; }
            set
            {
                department = value;
                RaisePropertyChanged("Department");
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                RaisePropertyChanged("Email");
            }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                phoneNumber = value;
                RaisePropertyChanged("PhoneNumber");
            }
        }

        public string MobilePhone
        {
            get { return mobilePhone; }
            set
            {
                mobilePhone = value;
                RaisePropertyChanged("MobilePhone");
            }
        }

        public string JobTitle
        {
            get { return jobTitle; }
            set
            {
                jobTitle = value;
                RaisePropertyChanged("JobTitle");
            }
        }

        public string JobDescription
        {
            get { return jobDescription; }
            set
            {
                jobDescription = value;
                RaisePropertyChanged("JobDescription");
            }
        }

        public Services SelectedService
        {
            get { return selectedService; }
            set
            {
                selectedService = value;
                RaisePropertyChanged("SelectedService");
            }
        }

        public ObservableCollection<Services> Services
        {
            get { return services; }
            set
            {
                services = value;
                RaisePropertyChanged("Services");
            }
        }

        public Sites SelectedSite
        {
            get { return selectedSite; }
            set
            {
                selectedSite = value;
                RaisePropertyChanged("SelectedSite");
            }
        }

        public ObservableCollection<Sites> Sites
        {
            get { return sites; }
            set
            {
                sites = value;
                RaisePropertyChanged("Sites");
            }
        }

        public DelegateCommand AddEmployeeCommand { get; private set; }

        private bool CanAddEmployee()
        {
            return !string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(LastName)
                && !string.IsNullOrWhiteSpace(Department) && !string.IsNullOrWhiteSpace(Email)
                && !string.IsNullOrWhiteSpace(PhoneNumber) && !string.IsNullOrWhiteSpace(MobilePhone)
                && !string.IsNullOrWhiteSpace(JobTitle) && !string.IsNullOrWhiteSpace(JobDescription)
                && SelectedService != null && SelectedSite != null;
        }


        private void AddEmployee()
        {
            if CanAddEmployee()
            {
                // Créez un nouvel employé avec les données entrées par l'utilisateur
                Employees employee = new Employees
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Department = Department,
                    Email = Email,
                    PhoneNumber = PhoneNumber,
                    MobilePhone = MobilePhone,
                    JobTitle = JobTitle,
                    JobDescription = JobDescription,
                    //ServiceId = SelectedService.Service,
                    //SiteId = SelectedSite.City
                };

                var httpClient = new HttpClient();
                var baseUri = "https://localhost:7053";
                var uri = $"{baseUri}/api/Employee/FirstName/{firstName}/LastName/{lastName}/Department/{Department}/Email/{Email}/PhoneNumber/{PhoneNumber}/MobilePhone/{MobilePhone}/JobTitle/{JobTitle}/JobDescription/{JobDescription}/Site/{Sites}/Service/{Services}";

                    // Envoyez l'employé à l'API
                HttpResponseMessage response = await httpClient.PostAsync(apiUrl, null);
                response.EnsureSuccessStatusCode();
                    
                // Réinitialisez les données entrées par l'utilisateur
                FirstName = string.Empty;
                LastName = string.Empty;
                Department = string.Empty;
                Email = string.Empty;
                PhoneNumber = string.Empty;
                MobilePhone = string.Empty;
                JobTitle = string.Empty;
                JobDescription = string.Empty;
                SelectedService = null;
                SelectedSite = null;
            }

            MessageBox.Show("Employé ajouté avec succès !");
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
