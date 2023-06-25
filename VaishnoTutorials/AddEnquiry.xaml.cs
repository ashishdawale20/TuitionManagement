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

namespace VaishnoTutorials
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btn_ViewAllEnquiries_Click(object sender, RoutedEventArgs e)
        {
            ViewAllEnquiries objViewAll = new ViewAllEnquiries();
            this.Hide();
            objViewAll.ShowDialog();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Validate())
                {
                    string FName = txtFName.Text;
                    string LName = txtLName.Text;
                    string MName = txtMName.Text;
                    string PhoneNo = txtPhoneNo.Text;
                    string Address = new TextRange(txtAddress.Document.ContentStart, txtAddress.Document.ContentEnd).Text;
                    string Class = txtClass.Text;
                    string Subject = txtSubject.Text;
                    string Remark = txtRemark.Text;
                    BusinessLogic.BusinessLogic.AddEnquiry(FName, MName, LName, PhoneNo, Address, Class, Subject, Remark);
                    txt_Success.Content = "Enquiry For " + txtFName.Text + " Added Successfully !!!";
                    txt_Success.Visibility = Visibility.Visible;
                    clearAll();
                }
            }

            catch (Exception Ex)
            {
                BusinessLogic.BusinessLogic.LogException(Ex.StackTrace, Ex.Message, string.Empty);
            }

            finally { }
        }

        private bool Validate()
        {
            int errorcount = 0;
            if (txtFName.Text == string.Empty)
            {
                mdFirstN.Visibility = Visibility.Visible;
                lblErrorMessage.Visibility = Visibility.Visible;
                errorcount++;
            }
            else
            {
                mdFirstN.Visibility = Visibility.Hidden;
            }

            if (txtLName.Text == string.Empty)
            {
                mdLastN.Visibility = Visibility.Visible;
                lblErrorMessage.Visibility = Visibility.Visible;
                errorcount++;
            }
            else
            {
                mdLastN.Visibility = Visibility.Hidden;
            }

            if (txtPhoneNo.Text == string.Empty)
            {
                mdPhoneN.Visibility = Visibility.Visible;
                lblErrorMessage.Visibility = Visibility.Visible;
                errorcount++;
            }
            else
            {
                mdPhoneN.Visibility = Visibility.Hidden;
            }

            if (errorcount == 0)
            {
                lblErrorMessage.Visibility = Visibility.Hidden;
            }
            return (errorcount == 0);

        }
       

        private void clearAll()
        {
            txtFName.Text = string.Empty;
            txtMName.Text = string.Empty;
            txtLName.Text = string.Empty;
            txtPhoneNo.Text = string.Empty;
            txtClass.Text = string.Empty;
            txtSubject.Text = string.Empty;
            txtRemark.Text = string.Empty;
            txtAddress.Document.Blocks.Clear();
        }

        private void txtPhoneNo_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            e.Handled = IsTextNumeric(e.Text);
        }

        private static bool IsTextNumeric(string str)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^0-9]");
            return reg.IsMatch(str);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Home hm = new Home();
            this.Hide();
            hm.ShowDialog();
        }
    }
}
