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

namespace Task_10._1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CustomerData customerData = new CustomerData();
        private string fileNameCustomers = "customers.xml";
        public MainWindow()
        {
            InitializeComponent();
            customerData.LoadCustomersFromXML(fileNameCustomers);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            customerData.AddXMLFileCustomers(fileNameCustomers);
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
