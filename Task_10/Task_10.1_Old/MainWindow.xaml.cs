using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        DataCustomers dataCustomers = new DataCustomers();
        //private string _nameFileCustomers = "customers.xml";
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = dataCustomers;
            dataCustomers.LoadCustomer();
            //txt_NumCustomer.Text = dataCustomers.CustID.ToString();
            Visibility vis = new Visibility();
            txt_NumCustomer.TextChanged += txt_NumCustomer_TextChanged;
        }

        private void Txt_NumCustomer_TextChanged(object sender, TextChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void btn_RemoveCustomer_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btn_AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            dataCustomers.isXmlFileExist();
            if(txt_NameCustomer.Text == null && txt_MidnameCustomer == null && txt_LasnameCustomer == null && txt_PhoneCustomer == null && txt_PassportCustomer.Text == null)
            {
                MessageBox.Show("Вы должны заполнить все поля!");
            }
            else
            {
                dataCustomers.AddCustomer(txt_NameCustomer.Text,txt_MidnameCustomer.Text,txt_LasnameCustomer.Text,
                    Convert.ToUInt32(txt_PhoneCustomer.Text), Convert.ToInt32(txt_PassportCustomer.Text));
                dataCustomers.SaveCustomer();
                lbl_Test.Content = dataCustomers.ShowCustomerName();
            }
        }

        private void btn_ChangeCustomer_Click(object sender, RoutedEventArgs e)
        {

        }
        private void cmb_ChangeEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.ChoiceEmployee();
        }
        #region Methods
        public void ChoiceEmployee()
        {
            if (cmb_ChangeEmployees.Items.CurrentItem == Consultant.Content)
            {
                grdc_EnabledCustomer.Width = new GridLength(0, GridUnitType.Star);
            }
            else
            {
                stp_ChangeCustomer.Visibility = Visibility.Visible;
                grdc_EnabledCustomer.Width = new GridLength(1, GridUnitType.Star);
            }
        }
        #endregion

        private void txt_NumCustomer_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(txt_NameCustomer.Text == dataCustomers.CustID.ToString())
            {
                txt_NameCustomer.Text = dataCustomers.CustName;
                Debug.WriteLine(dataCustomers.CustName);
                txt_MidnameCustomer.Text = dataCustomers.CustMidname;
            }
        }
    }
}
