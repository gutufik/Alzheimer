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
using Alzheimer.Data;

namespace Alzheimer.Pages
{
    /// <summary>
    /// Interaction logic for RequestPage.xaml
    /// </summary>
    public partial class RequestPage : Page
    {
        public Request Request { get; set; }
        public RequestPage()
        {
            InitializeComponent();
            Request = DataAccess.GetRequests().FirstOrDefault(x => x.Date == DateTime.Today && x.User == App.User);
            if (Request != null && Request.Id != 0)
            {
                spRequest.Visibility = Visibility.Visible;
                tbPatient.Text = Request.Patient.Name;
            }
        }

        private void btnApprove_Click(object sender, RoutedEventArgs e)
        {
            Request.IsOpened = true;
        }

        private void btnRefuse_Click(object sender, RoutedEventArgs e)
        {
            Request.IsOpened = false;
        }
    }
}
