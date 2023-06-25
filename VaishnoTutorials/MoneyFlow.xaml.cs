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
    /// Interaction logic for MoneyFlow.xaml
    /// </summary>
    public partial class MoneyFlow : Window

    {
        public int PageIndex
        {
            get;
            set;
        }

        public int MoneyFlowCount
        {
            get;
            set;
        }

        public int PagesCount
        {
            get;
            set;
        }
        public MoneyFlow()
        {
            PageIndex = 0;
            InitializeComponent();
            MoneyFlowCount = BusinessLogic.BusinessLogic.GetMoneyFlowCount(ddlFilMoneyFlowTyep.Text);
            gvMoneyFlow.Items.Clear();
            gvMoneyFlowPeriod.Items.Clear();
            getAllMoneyFlowType();
            getAllMoneyFlow(1, 10);
            setPeriodDdl();
        }
        public void EnableDisablePaginationButton()
        {
            lblPageIndex.Content = PageIndex + 1;
            double cal = ((double)MoneyFlowCount / 10);
            double count = Math.Ceiling(cal);
            lblNumberOfPages.Content = count.ToString();
            PagesCount = Convert.ToInt32(count);
            if (PageIndex == 0)
            {
                btnFirstPage.IsEnabled = false;
                btnPreviousPage.IsEnabled = false;
            }
            if (PageIndex > 0)
            {
                btnFirstPage.IsEnabled = true;
                btnPreviousPage.IsEnabled = true;
            }
            if (PageIndex + 1 == count)
            {
                btnNextPage.IsEnabled = false;
                btnLastPage.IsEnabled = false;
            }
            else
            {
                btnNextPage.IsEnabled = true;
                btnLastPage.IsEnabled = true;
            }
        }

        private void getAllMoneyFlowType()
        {
            DataSet ds = BusinessLogic.BusinessLogic.GetAllMoneyFlowType();
            ddlMoneyFlowTyep.ItemsSource = ds.Tables[0].DefaultView;
            ddlMoneyFlowTyep.DisplayMemberPath = "Type";
            ddlMoneyFlowTyep.SelectedValuePath = "ID";

            ddlFilMoneyFlowTyep.ItemsSource = ds.Tables[0].DefaultView;
            ddlFilMoneyFlowTyep.DisplayMemberPath = "Type";
            ddlFilMoneyFlowTyep.SelectedValuePath = "ID";
        }

        private void getAllMoneyFlow(int startIndex, int endIndex)
        {
            DataSet ds = BusinessLogic.BusinessLogic.GetAllMoneyFlow(ddlFilMoneyFlowTyep.Text, startIndex, endIndex);
            if(ds.Tables[0].Rows.Count > 0)
            gvMoneyFlow.ItemsSource = (ds.Tables[0].DefaultView);
            EnableDisablePaginationButton();
        }
        private void setPeriodDdl()
        {
            DataSet ds = BusinessLogic.BusinessLogic.GetPeriod();
            ddlDuration.ItemsSource = ds.Tables[0].DefaultView;
            ddlDuration.DisplayMemberPath = "Period";
            ddlDuration.SelectedValuePath = "ID";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Home hm = new Home();
            this.Hide();
            hm.ShowDialog();
        }
        private void btnAdd_Click_1(object sender, RoutedEventArgs e)
        {
            string flowType = string.Empty, flowName = string.Empty, flowDescription = string.Empty, amount = string.Empty, FlowDate = string.Empty;
            flowType = ddlMoneyFlowTyep.Text;
            flowName = txtFName.Text;
            flowDescription = txtLName.Text;
            FlowDate = txtFlowDate.Text;
            amount = txtPhone.Text;
            BusinessLogic.BusinessLogic.AddNewMoneyFlow(flowName, flowDescription, amount, flowType, FlowDate);
            label16.Content = "Added " + flowType + " Successfully!";
            label16.Visibility = Visibility.Visible;
            clearAll();
            getAllMoneyFlow(1,10);
        }

        private void clearAll()
        {
            ddlMoneyFlowTyep.SelectedIndex = -1;
            ddlMoneyFlowTyep.Text = "-- Select --";
            txtFName.Text = string.Empty;
            txtLName.Text = string.Empty;
            txtPhone.Text = string.Empty;
        }
        
        private void btnLastPage_Click(object sender, RoutedEventArgs e)
        {
            PageIndex = PagesCount - 1;
            getAllMoneyFlow(PageIndex * 10 + 1, (PageIndex + 1) * 10);
        }
        private void btnFirstPage_Click(object sender, RoutedEventArgs e)
        {
            PageIndex = 0;
            getAllMoneyFlow(1, 10);
        }
        private void btnPreviousPage_Click(object sender, RoutedEventArgs e)
        {
            PageIndex--;
            getAllMoneyFlow(PageIndex * 10 + 1, (PageIndex + 1) * 10);
        }
        private void btnNextPage_Click(object sender, RoutedEventArgs e)
        {
            PageIndex++;
            getAllMoneyFlow(PageIndex * 10 + 1, (PageIndex + 1) * 10);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void btnSearch_Click_1(object sender, RoutedEventArgs e)
        {
            string duration  = ddlDuration.Text;
            if (duration == string.Empty || duration == "-- Select --")
            {
                MoneyFlowCount = BusinessLogic.BusinessLogic.GetMoneyFlowCount(ddlFilMoneyFlowTyep.Text);
                getAllMoneyFlow(1, 10);
                EnableDisablePaginationButton();
            }
            else
            {
               DataTable dt =  BusinessLogic.BusinessLogic.GetMoneyFlowForDuration(duration, ddlFilMoneyFlowTyep.Text, 1, 10);
               showPeroidGrid(dt);
            }
        }

        private void showPeroidGrid(DataTable dt)
        {
            gvMoneyFlow.Visibility = Visibility.Hidden;
            gvMoneyFlowPeriod.Visibility = Visibility.Visible;
        
            gvMoneyFlowPeriod.ItemsSource = dt.DefaultView;
        }
      
    }
}
