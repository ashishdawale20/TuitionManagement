using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;

namespace VaishnoTutorials
{
    /// <summary>
    /// Interaction logic for AddAdmission.xaml
    /// </summary>
    public partial class AddAdmission : Window
    {
        int nubSubjectSelected = 0;
        int totalRate = 0;
        string[] selectedSubjects;
        string[] unselectedSubjects;
        public string studentId { get; set; }
        public AddAdmission()
        {
            InitializeComponent();
            bindClassList();
            bindInstallments();
        }
        public AddAdmission(string value)
        {
            
            InitializeComponent();
            bindClassList();
            bindInstallments();
            studentId = value;
            if (studentId != string.Empty)
            {
                getStudentDetails();
            }
        }
        private void getStudentDetails()
        {
            DataSet ds = BusinessLogic.BusinessLogic.GetStudentDetails(studentId);
            setAll(ds);
        }

        public void bindClassList()
        {
            DataSet ds = BusinessLogic.BusinessLogic.GetClassList();
            ddlClass.ItemsSource = ds.Tables[0].DefaultView;
            ddlClass.DisplayMemberPath = "ClassName";
            ddlClass.SelectedValuePath = "ID";
        }
        public void bindInstallments()
        {
            DataSet ds = BusinessLogic.BusinessLogic.GetInstallments();
            ddlInstallment.ItemsSource = ds.Tables[0].DefaultView;
            ddlInstallment.DisplayMemberPath = "InstallmentName";
            ddlInstallment.SelectedValuePath = "InstallmentName";
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
                
                CheckBox clickedBox = (CheckBox)sender;
                string Rate = BusinessLogic.BusinessLogic.GetRate(clickedBox.CommandParameter.ToString());
                selectedSubjects[nubSubjectSelected] = clickedBox.Content.ToString() + " = " + Rate + "\n";
                lblSelectedSubjects.Content += selectedSubjects[nubSubjectSelected];
                totalRate += Convert.ToInt32(Rate);
                if (nubSubjectSelected >= 1)
                {
                    lblTotal.Content = "-------------\n";
                    lblTotal.Content += "Total: " + totalRate;
                }
                nubSubjectSelected++;
                lblTotal.SetValue(Canvas.TopProperty, 190.0 + (nubSubjectSelected * 15.0));
                ddlSubjects.Text = clickedBox.Content.ToString() + " ,";
        }
        private void CheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            CheckBox clickedBox = (CheckBox)sender;
            nubSubjectSelected--;
            lblSelectedSubjects.Content = string.Empty;
            int i=0;
            foreach (string str in selectedSubjects)
            {
                if(str != null)
                {
                    if (!str.Contains(clickedBox.Content.ToString()))
                    {
                        lblSelectedSubjects.Content += str;
                        unselectedSubjects[i] = str;
                        i++;
                    }
                }
            }
            selectedSubjects = unselectedSubjects;
            string Rate = BusinessLogic.BusinessLogic.GetRate(clickedBox.CommandParameter.ToString());
            totalRate -= Convert.ToInt32(Rate);
            if (nubSubjectSelected >= 1)
            {
                lblTotal.Content = "-------------\n";
                lblTotal.Content += "Total: " + totalRate;
            }
            lblTotal.SetValue(Canvas.TopProperty, 190.0 + (nubSubjectSelected * 15.0));
        
        }
        private void ddlClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ddlSubjects.ItemsSource == null)
            ddlSubjects.Items.Clear();
            if (ddlClass.SelectedValue != null)
            {
                string value = ddlClass.SelectedValue.ToString();
                DataSet ds = BusinessLogic.BusinessLogic.GetSubjectList(Convert.ToInt32(value));
                ddlSubjects.ItemsSource = ds.Tables[0].DefaultView;
                ddlSubjects.DisplayMemberPath = "SubejectName";
                ddlSubjects.SelectedValuePath = "ID";
                selectedSubjects = new string[ds.Tables[0].Rows.Count];
                unselectedSubjects = new string[ds.Tables[0].Rows.Count];
            }
            lblSelectedSubjects.Content = string.Empty;
            lblTotal.Content = string.Empty;
            nubSubjectSelected = 0;
            totalRate = 0;
        }

        private void TextBox_FocusableChanged_1(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void TextBox_LostFocus_1(object sender, RoutedEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            DataSet ds = BusinessLogic.BusinessLogic.GetEnquiryDetailsFromPhoneNumber(txt.Text.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtFName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                txtMName.Text = ds.Tables[0].Rows[0]["MiddleName"].ToString();
                txtLName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
                txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
            }
        }

        private void ddlInstallment_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (ddlInstallment.SelectedValue != null)
            {
                if (ddlInstallment.SelectedValue.ToString() == "1 Installment")
                {
                    lblDueDate.Content = String.Format("{0:dd MMM yyyy}", DateTime.Now.AddDays(5)) + " -  Rs:" + totalRate + "\n";
                    chkFirst.Visibility = Visibility.Visible;
                    chkSecond.Visibility = Visibility.Hidden;
                    chkThird.Visibility = Visibility.Hidden;
                    chkFourth.Visibility = Visibility.Hidden;
                }

                if (ddlInstallment.SelectedValue.ToString() == "2 Installment")
                {
                    lblDueDate.Content = String.Format("{0:dd MMM yyyy}", DateTime.Now.AddDays(5)) + " -  Rs:" + (totalRate * 55) / 100 + "\n";
                    lblDueDate.Content += String.Format("{0:dd MMM yyyy}", DateTime.Now.AddDays(45)) + " - Rs:" + (totalRate * 55) / 100 + "\n";
                    chkFirst.Visibility = Visibility.Visible;
                    chkSecond.Visibility = Visibility.Visible;
                    chkThird.Visibility = Visibility.Hidden;
                    chkFourth.Visibility = Visibility.Hidden;
                }

                if (ddlInstallment.SelectedValue.ToString() == "3 Installment")
                {
                    lblDueDate.Content = String.Format("{0:dd MMM yyyy}", DateTime.Now.AddDays(5)) + " - Rs:" + (totalRate * 40) / 100 + "\n";
                    lblDueDate.Content += String.Format("{0:dd MMM yyyy}", DateTime.Now.AddDays(45)) + " - Rs:" + (totalRate * 40) / 100 + "\n";
                    lblDueDate.Content += String.Format("{0:dd MMM yyyy}", DateTime.Now.AddDays(95)) + " - Rs:" + (totalRate * 35) / 100 + "\n";
                    chkFirst.Visibility = Visibility.Visible;
                    chkSecond.Visibility = Visibility.Visible;
                    chkThird.Visibility = Visibility.Visible;
                    chkFourth.Visibility = Visibility.Hidden;
                }

                if (ddlInstallment.SelectedValue.ToString() == "4 Installment")
                {
                    lblDueDate.Content = String.Format("{0:dd MMM yyyy}", DateTime.Now.AddDays(5)) + " - Rs:" + (totalRate * 30) / 100 + "\n";
                    lblDueDate.Content += String.Format("{0:dd MMM yyyy}", DateTime.Now.AddDays(45)) + " - Rs:" + (totalRate * 30) / 100 + "\n";
                    lblDueDate.Content += String.Format("{0:dd MMM yyyy}", DateTime.Now.AddDays(95)) + " - Rs:" + (totalRate * 30) / 100 + "\n";
                    lblDueDate.Content += String.Format("{0:dd MMM yyyy}", DateTime.Now.AddDays(125)) + " - Rs:" + (totalRate * 30) / 100 + "\n";
                    chkFirst.Visibility = Visibility.Visible;
                    chkSecond.Visibility = Visibility.Visible;
                    chkThird.Visibility = Visibility.Visible;
                    chkFourth.Visibility = Visibility.Visible;
                }
            }
        }

        private void setInstallment()
        { 
        
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

            if (txtPhoneNumber.Text == string.Empty)
            {
                mdPhoneN.Visibility = Visibility.Visible;
                lblErrorMessage.Visibility = Visibility.Visible;
                errorcount++;
            }
            else
            {
                mdPhoneN.Visibility = Visibility.Hidden;
            }

            if (ddlClass.Text == string.Empty || ddlClass.Text == "-- Select --")
            {
                mdClass.Visibility = Visibility.Visible;
                lblErrorMessage.Visibility = Visibility.Visible;
                errorcount++;
            }
            else
            {
                mdClass.Visibility = Visibility.Hidden;
            }

            if (ddlSubjects.Text == string.Empty || ddlSubjects.Text == "-- Select --")
            {
                mdSubjects.Visibility = Visibility.Visible;
                lblErrorMessage.Visibility = Visibility.Visible;
                errorcount++;
            }
            else
            {
                mdSubjects.Visibility = Visibility.Hidden;
            }
            if (ddlInstallment.Text == string.Empty)
            {
                mdIstallments.Visibility = Visibility.Visible;
                lblErrorMessage.Visibility = Visibility.Visible;
                errorcount++;
            }
            else
            {
                mdIstallments.Visibility = Visibility.Hidden;
            }
            if (errorcount == 0)
            {
                lblErrorMessage.Visibility = Visibility.Hidden;
            }
            return (errorcount == 0);

        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                string FirstDueDate = string.Empty, SecondDueDate = string.Empty, ThirdDueDate = string.Empty, FirstDue = string.Empty, SecondDue = string.Empty, ThirdDue = string.Empty, IsFirstDue = string.Empty, IsSecondDue = string.Empty, IsThirdDue = string.Empty, IsFeesSubmitted = string.Empty;
                string FourthDue = string.Empty, IsFourthDue = string.Empty, FourthDueDate = string.Empty;
                string FirstDuePaidDate = string.Empty, SecondDuePaidDate = string.Empty, ThirdDuePaidDate = string.Empty, FourthDuePaidDate = string.Empty;
                string FName = txtFName.Text;
                string LName = txtLName.Text;
                string MName = txtMName.Text;
                string PhoneNo = txtPhoneNumber.Text;
                string Address = txtAddress.Text;
                string Class = ddlClass.Text.ToString();
                string Subject = string.Empty;
                string TotalFees = totalRate.ToString();
                string intallment = ddlInstallment.SelectedValue.ToString();
                string paymentStatus = "Pending";
                bool isMoneyFlow = false;
                if (intallment == "1 Installment")
                {
                    FirstDue = totalRate.ToString();
                    SecondDue = "0";
                    ThirdDue = "0";
                    FourthDue = "0";
                    IsFirstDue = "1";
                    IsSecondDue = "0";
                    IsThirdDue = "0";
                    IsFourthDue = "0";
                    FirstDueDate = DateTime.Now.AddDays(5).ToShortDateString();
                    SecondDueDate = "0";
                    ThirdDueDate = "0";
                    FourthDueDate = "0";
                }

                if (intallment == "2 Installment")
                {
                    FirstDue = ((totalRate * 55) / 100).ToString();
                    SecondDue = ((totalRate * 55) / 100).ToString();
                    ThirdDue = "0";
                    FourthDue = "0";
                    IsFirstDue = "1";
                    IsSecondDue = "1";
                    IsThirdDue = "0";
                    FirstDueDate = DateTime.Now.AddDays(5).ToShortDateString();
                    SecondDueDate = DateTime.Now.AddDays(45).ToShortDateString();
                    ThirdDueDate = "0";
                    FourthDueDate = "0";
                }

                if (intallment == "3 Installment")
                {
                    FirstDue = ((totalRate * 40) / 100).ToString();
                    SecondDue = ((totalRate * 40) / 100).ToString();
                    ThirdDue = ((totalRate * 35) / 100).ToString();
                    FourthDue = "0";
                    IsFirstDue = "1";
                    IsSecondDue = "1";
                    IsThirdDue = "1";
                    IsFourthDue = "0";
                    FirstDueDate = DateTime.Now.AddDays(5).ToShortDateString();
                    SecondDueDate = DateTime.Now.AddDays(45).ToShortDateString();
                    ThirdDueDate = DateTime.Now.AddDays(95).ToShortDateString();
                    FourthDueDate = "0";
                }

                if (intallment == "4 Installment")
                {
                    FirstDue = ((totalRate * 30) / 100).ToString();
                    SecondDue = ((totalRate * 30) / 100).ToString();
                    ThirdDue = ((totalRate * 30) / 100).ToString();
                    FourthDue = ((totalRate * 30) / 100).ToString();
                    IsFirstDue = "1";
                    IsSecondDue = "1";
                    IsThirdDue = "1";
                    IsFourthDue = "1";
                    FirstDueDate = DateTime.Now.AddDays(5).ToShortDateString();
                    SecondDueDate = DateTime.Now.AddDays(45).ToShortDateString();
                    ThirdDueDate = DateTime.Now.AddDays(95).ToShortDateString();
                    FourthDueDate = DateTime.Now.AddDays(125).ToShortDateString();
                }
                IsFeesSubmitted = "0";
                if (chkFirst.IsChecked == true)
                {
                    IsFirstDue = "0";
                    IsFeesSubmitted = FirstDue;
                    FirstDuePaidDate = DateTime.Now.ToString();
                    isMoneyFlow = true;
                }

                if (chkSecond.IsChecked == true)
                {
                    IsSecondDue = "0";
                    IsFeesSubmitted = ((Convert.ToInt32(SecondDue) + Convert.ToInt32(FirstDue))).ToString();
                    SecondDuePaidDate = DateTime.Now.ToString();
                    isMoneyFlow = true;
                }
                if (chkThird.IsChecked == true)
                {
                    IsThirdDue = "0";
                    IsFeesSubmitted = ((Convert.ToInt32(SecondDue) + Convert.ToInt32(FirstDue) + Convert.ToInt32(ThirdDue))).ToString();
                    ThirdDuePaidDate = DateTime.Now.ToString();
                    isMoneyFlow = true;
                }
                if (chkFourth.IsChecked == true)
                {
                    IsFourthDue = "0";
                    IsFeesSubmitted = ((Convert.ToInt32(FirstDue) + Convert.ToInt32(SecondDue) + Convert.ToInt32(ThirdDue) + Convert.ToInt32(FourthDue))).ToString();
                    FourthDuePaidDate = DateTime.Now.ToString();
                    isMoneyFlow = true;
                }

                paymentStatus = setPaymentStatus(IsFirstDue, IsSecondDue, IsThirdDue, IsFourthDue);

                if (string.IsNullOrEmpty(studentId))
                {
                    var result = string.Join(",", selectedSubjects);
                    Subject = result.ToString();
                    BusinessLogic.BusinessLogic.AddNewAdmission(FName, MName, LName, PhoneNo, Address, Class, Subject, TotalFees, intallment, FirstDue, SecondDue, ThirdDue, FourthDue, IsFirstDue, IsSecondDue, IsThirdDue, IsFourthDue, IsFeesSubmitted, FirstDueDate, SecondDueDate, ThirdDueDate, FourthDueDate, paymentStatus, FirstDuePaidDate, SecondDuePaidDate, ThirdDuePaidDate, FourthDuePaidDate);
                    txt_Success.Content = "Admission For " + txtFName.Text + " Added Successfully !!!";
                    txt_Success.Visibility = Visibility.Visible;
                    if (isMoneyFlow)
                    {
                        BusinessLogic.BusinessLogic.AddNewMoneyFlow(FName + " " + LName, "Fees Paid", IsFeesSubmitted, "Income", DateTime.Now.ToShortDateString(), studentId);
                    }
                    clearAll();
                }
                else
                {
                    Subject = lblSelectedSubjects.Content.ToString();
                    BusinessLogic.BusinessLogic.UpdateStudentInfo(studentId, FName, MName, LName, PhoneNo, Address, Class, Subject, TotalFees, intallment, FirstDue, SecondDue, ThirdDue, FourthDue, IsFirstDue, IsSecondDue, IsThirdDue, IsFourthDue, IsFeesSubmitted, FirstDueDate, SecondDueDate, ThirdDueDate, FourthDueDate, FirstDuePaidDate, SecondDuePaidDate, ThirdDuePaidDate, FourthDuePaidDate, paymentStatus);
                    txt_Success.Content = "Information For " + txtFName.Text + " updated Successfully !!!";
                    txt_Success.Visibility = Visibility.Visible;
                    if (isMoneyFlow)
                    {
                        if (paymentStatus == "2nd Installment Pending")
                            BusinessLogic.BusinessLogic.AddNewMoneyFlow(FName + " ," + LName, "Fees submitted", IsFeesSubmitted, "Income",DateTime.Now.ToShortDateString(), studentId);
                        else
                        BusinessLogic.BusinessLogic.UpdateMoneyFlow(FName + " " + LName, "Fees Paid", IsFeesSubmitted, "Income", studentId);
                    }
                }

            }
        }

        private string setPaymentStatus(string isfirstDue, string isSecondDue, string isThirdDue, string isFourthDue)
        {
            if (isfirstDue == "1")
                return "1st Installment Pending";
            else if (isSecondDue == "1") return "2nd Installment Pending";
            else if (isThirdDue == "1") return "3rd Installment Pending";
            else if (isFourthDue == "1") return "4th Installment Pending";
            else return "Completed";
        }

        private void clearAll()
        {
            txtFName.Text = string.Empty;
            txtMName.Text = string.Empty;
            txtLName.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            ddlClass.SelectedIndex = -1;
            txtAddress.Text = string.Empty;
            ddlSubjects.SelectedIndex = -1;
            ddlSubjects.Text = string.Empty;
            lblSelectedSubjects.Content = string.Empty;
            ddlInstallment.SelectedIndex = -1;
            lblDueDate.Content = string.Empty;
            lblTotal.Content = string.Empty;
            chkFirst.Visibility = Visibility.Hidden;
            chkSecond.Visibility = Visibility.Hidden;
            chkThird.Visibility = Visibility.Hidden;
            chkFourth.Visibility = Visibility.Hidden;
            chkFirst.IsChecked = false;
            chkSecond.IsChecked = false;
            chkThird.IsChecked = false;
            chkFourth.IsChecked = false;
            chkFirst.Content = "Pay";
            chkSecond.Content = "Pay";
            chkThird.Content = "Pay";
            chkFourth.Content = "Pay";
        }

        private void setAll(DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtFName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                txtMName.Text = ds.Tables[0].Rows[0]["MiddleName"].ToString();
                txtLName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
                txtPhoneNumber.Text = ds.Tables[0].Rows[0]["PhoneNo"].ToString(); 
                ddlClass.Text = ds.Tables[0].Rows[0]["Class"].ToString();
                ddlClass.IsEnabled = false;
                txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString(); ;
                ddlSubjects.SelectedIndex = -1;
                ddlSubjects.IsEnabled = false;
                lblSelectedSubjects.Content = (ds.Tables[0].Rows[0]["Subjects"].ToString()).Replace(",", "");
                ddlSubjects.Text = ds.Tables[0].Rows[0]["Subjects"].ToString();
                ddlInstallment.SelectedValue = ds.Tables[0].Rows[0]["Installments"].ToString();
                ddlInstallment.IsEnabled = false;
                totalRate =Convert.ToInt32(ds.Tables[0].Rows[0]["TotalFees"]);
                if (ds.Tables[0].Rows[0]["Installments"].ToString() == "1 Installment")
                {
                    lblDueDate.Content = ds.Tables[0].Rows[0]["FirstDueDate"].ToString() + " -  Rs:" + totalRate + "\n";
                    setVisibility(Visibility.Visible, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden);
                }

                if (ds.Tables[0].Rows[0]["Installments"].ToString() == "2 Installment")
                {
                    lblDueDate.Content = ds.Tables[0].Rows[0]["FirstDueDate"].ToString() + " -  Rs:" + (totalRate * 55) / 100 + "\n";
                    lblDueDate.Content += ds.Tables[0].Rows[0]["SecondDueDate"].ToString() + " -  Rs:" + (totalRate * 55) / 100 + "\n";
                    setVisibility(Visibility.Visible, Visibility.Visible, Visibility.Hidden, Visibility.Hidden);
                }

                if (ds.Tables[0].Rows[0]["Installments"].ToString() == "3 Installment")
                {
                    lblDueDate.Content = ds.Tables[0].Rows[0]["FirstDueDate"].ToString() + " -  Rs:" + (totalRate * 40) / 100 + "\n";
                    lblDueDate.Content += ds.Tables[0].Rows[0]["SecondDueDate"].ToString() + " -  Rs:" + (totalRate * 40) / 100 + "\n";
                    lblDueDate.Content += ds.Tables[0].Rows[0]["ThirdDueDate"].ToString() + " -  Rs:" + (totalRate * 35) / 100 + "\n";
                    setVisibility(Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Hidden);
                }

                if (ds.Tables[0].Rows[0]["Installments"].ToString() == "4 Installment")
                {
                    lblDueDate.Content = ds.Tables[0].Rows[0]["FirstDueDate"].ToString() + " -  Rs:" + (totalRate * 30) / 100 + "\n";
                    lblDueDate.Content += ds.Tables[0].Rows[0]["SecondDueDate"].ToString() + " -  Rs:" + (totalRate * 30) / 100 + "\n";
                    lblDueDate.Content += ds.Tables[0].Rows[0]["ThirdDueDate"].ToString() + " -  Rs:" + (totalRate * 30) / 100 + "\n";
                    lblDueDate.Content += ds.Tables[0].Rows[0]["FourthDueDate"].ToString() + " -  Rs:" + (totalRate * 30) / 100 + "\n";
                    setVisibility(Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible);
                }
                enableCheckBox(ds);
                setCheckBox(ds.Tables[0].Rows[0]["PaymentStatus"].ToString());
            }
        }

        private void setVisibility(Visibility vs1, Visibility vs2, Visibility vs3, Visibility vs4)
        {
            chkFirst.Visibility = vs1;
            chkSecond.Visibility = vs2;
            chkThird.Visibility = vs3;
            chkFourth.Visibility = vs4;
        }

        private void enableCheckBox(DataSet ds)
        {
            string firstDuePaidDate = ds.Tables[0].Rows[0]["FirstDuePaidDate"].ToString();
            string secondDuePaidDate = ds.Tables[0].Rows[0]["SecondDuePaidDate"].ToString();
            string thirdDuePaidDate = ds.Tables[0].Rows[0]["ThirdDuePaidDate"].ToString();
            string fourthDuePaidDate = ds.Tables[0].Rows[0]["FourthDuePaidDate"].ToString();
          
            if (!string.IsNullOrEmpty(firstDuePaidDate))
            {
                setPaymentCheckBox(chkFirst, lblFirstDuePaidDate, firstDuePaidDate);
            }
            if (!string.IsNullOrEmpty(secondDuePaidDate))
            {
                setPaymentCheckBox(chkSecond, lblSecondDuePaidDate, secondDuePaidDate);
            }
            if (!string.IsNullOrEmpty(thirdDuePaidDate))
            {
                setPaymentCheckBox(chkThird, lblThirdDuePaidDate, thirdDuePaidDate);
            }
            if (!string.IsNullOrEmpty(fourthDuePaidDate))
            {
                setPaymentCheckBox(chkFourth, lblFourthDuePaidDate, fourthDuePaidDate);
            }
        }

        private void setPaymentCheckBox(CheckBox chk, Label lbl, string duePaidDate)
        {
            chk.IsChecked = true;
            chk.IsEnabled = false;
            lbl.Visibility = Visibility.Visible;
            lbl.Content = "(" + Convert.ToDateTime(duePaidDate).ToShortDateString() + ")";
        }
        private void disableCheckBox(bool first, bool second, bool third, bool fourth)
        {
            chkFirst.IsEnabled = first;
            chkSecond.IsEnabled = second;
            chkThird.IsEnabled = third;
            chkFourth.IsEnabled = fourth;
        }
        private void setCheckBox(string paymentStatus)
        {
            if (paymentStatus.ToLower() == "1st Installment Pending".ToLower())
            {
                disableCheckBox(true, false, false, false);
            }
            if (paymentStatus.ToLower() == "2nd Installment Pending".ToLower())
            {
                disableCheckBox(false, true, false, false);
            }
            if (paymentStatus.ToLower() == "3rd Installment Pending".ToLower())
            {
                disableCheckBox(false, false, true, false);
            }
            if (paymentStatus.ToLower() == "4th Installment Pending".ToLower())
            {
                disableCheckBox(false, false, false, true);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Home hm = new Home();
            this.Hide();
            hm.ShowDialog();
        }

        private void chkFirst_Checked_1(object sender, RoutedEventArgs e)
        {
            CheckBox clickedBox = (CheckBox)sender;
            clickedBox.Content = "Paid";
        }

        private void chkFirst_Unchecked_1(object sender, RoutedEventArgs e)
        {
            CheckBox clickedBox = (CheckBox)sender;
            clickedBox.Content = "Pay";
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            ViewAllAdmissions addAdmsn = new ViewAllAdmissions();
            this.Hide();
            addAdmsn.ShowDialog();
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
    }
}
