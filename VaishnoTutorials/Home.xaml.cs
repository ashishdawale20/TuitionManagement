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
using System.Windows.Shapes;

namespace VaishnoTutorials
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
            GetPendingPayments();
        }
        private void GetPendingPayments()
        {
            BusinessLogic.BusinessLogic.GetPendingPayments();
        }

        private void btn_AddEnquiry_Click(object sender, RoutedEventArgs e)
        {
            MainWindow addEnquiry = new MainWindow();
            this.Hide();
            addEnquiry.ShowDialog();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            ViewAllEnquiries all = new ViewAllEnquiries();
            this.Hide();
            all.ShowDialog();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            AddAdmission addAdmsn = new AddAdmission();
            this.Hide();
            addAdmsn.ShowDialog();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            ViewAllAdmissions addAdmsn = new ViewAllAdmissions();
            this.Hide();
            addAdmsn.ShowDialog();
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            MoneyFlow moneyFlw = new MoneyFlow();
            this.Hide();
            moneyFlw.ShowDialog();
        }
        
      
    }
}
