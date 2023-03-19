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
using System.Collections.ObjectModel;
using System.Diagnostics.Tracing;

namespace Task_9._1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int i = 0;
        ObservableCollection<string> words = new ObservableCollection<string>();
        UserTextConvert userTextConvert = new UserTextConvert();
        public MainWindow()
        {
            InitializeComponent();
            listbSplitText.ItemsSource = words;
        }

        private void btnSplitText_Click(object sender, RoutedEventArgs e)
        {
            words.Clear();
            string[] strWords = userTextConvert.UserTextSplit(txtbTextUser.Text);
            for (int i = 0; i < strWords.Length; i++)
            {
                words.Add(strWords[i]);
            }
        }

        private void btnReverseText_Click(object sender, RoutedEventArgs e)
        {
            string strWord = userTextConvert.UserTextReverse(txtbTextUser.Text);
            lblReverseText.Content = strWord;
        }

    }
}
