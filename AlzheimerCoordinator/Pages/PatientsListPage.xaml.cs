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
using AlzheimerCoordinator.Data;

namespace AlzheimerCoordinator.Pages
{
    /// <summary>
    /// Interaction logic for PatientsListPage.xaml
    /// </summary>
    public partial class PatientsListPage : Page
    {
        public List<Patient> Patients { get; set; }
        public PatientsListPage()
        {
            InitializeComponent();
            Patients = DataAccess.GetPatients();
            lvPatients.ItemsSource = Patients;
        }

        private void btnMakeRequest_Click(object sender, RoutedEventArgs e)
        {
            var patient = (sender as Button).DataContext as Patient;

            if (patient != null)
            {
                var request = new Request { 
                    Patient = patient, 
                    Date = DateTime.Today 
                    //User Рандомно 
                };
                DataAccess.SaveRequest(request);
            }
        }
    }
}
