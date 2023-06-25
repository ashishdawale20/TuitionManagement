using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// Interaction logic for ViewAllEnquiries.xaml
    /// </summary>
    public partial class ViewAllEnquiries : Window
    {
        public int PageIndex
        {
            get;
            set;
        }

        public int EnquiryCount
        {
            get;
            set;
        }

        public int PagesCount
        {
            get;
            set;
        }

        public ViewAllEnquiries()
        {
            PageIndex = 0;
            EnquiryCount = BusinessLogic.BusinessLogic.GetEnquiryCount();
            InitializeComponent();
            gvEnquiry.Items.Clear();
            bindGrid(1, 10);
        }

        public void bindGrid(int startIndex, int endIndex)
        {
           
            //DataSet vDs = BusinessLogic.BusinessLogic.GetAllEnquiries(Math.Abs(startIndex-EnquiryCount) +1, Math.Abs(endIndex - EnquiryCount)+1);
            DataSet vDs = BusinessLogic.BusinessLogic.GetAllEnquiries(startIndex, endIndex);
             gvEnquiry.ItemsSource = new DataView(vDs.Tables[0]);
             EnableDisablePaginationButton();
        }

        private void btn_ViewAllEnquiries_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mn = new MainWindow();
            this.Hide();
            mn.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Home hm = new Home();
            this.Hide();
            hm.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow mn = new MainWindow();
            this.Hide();
            mn.ShowDialog();
        }

        private void btnLastPage_Click(object sender, RoutedEventArgs e) {
            PageIndex = PagesCount -1;
            bindGrid(PageIndex * 10 + 1, (PageIndex + 1) * 10);
        }
        private void btnFirstPage_Click(object sender, RoutedEventArgs e) {
            PageIndex = 0;
            bindGrid(1, 10);
        }
        private void btnPreviousPage_Click(object sender, RoutedEventArgs e) {
            PageIndex--;
            bindGrid(PageIndex * 10 + 1, (PageIndex +1) * 10);
        }
        private void btnNextPage_Click(object sender, RoutedEventArgs e) {
            PageIndex++;
            bindGrid(PageIndex * 10 + 1, (PageIndex + 1) * 10);
        }

        public void EnableDisablePaginationButton()
        {
            lblPageIndex.Content = PageIndex + 1;
            double cal = ((double)EnquiryCount / 10);
            double count = Math.Ceiling(cal);
            lblNumberOfPages.Content = count.ToString();
            PagesCount =Convert.ToInt32(count);
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

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            DataSet ds = BusinessLogic.BusinessLogic.GetEnquiryForExport();
            ExporttoExcel(ds.Tables[0]);
        }

        private void ExporttoExcel(DataTable datatable)
        {
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook excelworkBook;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet;
            Microsoft.Office.Interop.Excel.Range excelCellrange;

            try
            {
                // Start Excel and get Application object.
                excel = new Microsoft.Office.Interop.Excel.Application();

                // for making Excel visible
                excel.Visible = false;
                excel.DisplayAlerts = false;

                // Creation a new Workbook
                excelworkBook = excel.Workbooks.Add(Type.Missing);

                // Workk sheet
                excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
                excelSheet.Name = "Enquiries";

                // loop through each row and add values to our sheet
                int rowcount = 2;

                foreach (DataRow datarow in datatable.Rows)
                {
                    rowcount += 1;
                    for (int i = 1; i <= datatable.Columns.Count; i++)
                    {
                        // on the first iteration we add the column headers
                        if (rowcount == 3)
                        {
                            excelSheet.Cells[2, i] = datatable.Columns[i - 1].ColumnName;
                            excelSheet.Cells.Font.Color = System.Drawing.Color.Black;

                        }

                        excelSheet.Cells[rowcount, i] = datarow[i - 1].ToString();

                        //for alternate rows
                        if (rowcount > 3)
                        {
                            if (i == datatable.Columns.Count)
                            {
                                if (rowcount % 2 == 0)
                                {
                                    excelCellrange = excelSheet.Range[excelSheet.Cells[rowcount, 1], excelSheet.Cells[rowcount, datatable.Columns.Count]];
                                    FormattingExcelCells(excelCellrange, "#CCCCFF", System.Drawing.Color.Black, false);
                                }

                            }
                        }

                    }

                }

                // now we resize the columns
                excelCellrange = excelSheet.Range[excelSheet.Cells[1, 1], excelSheet.Cells[rowcount, datatable.Columns.Count]];
                excelCellrange.EntireColumn.AutoFit();
                Microsoft.Office.Interop.Excel.Borders border = excelCellrange.Borders;
                border.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                border.Weight = 2d;


                excelCellrange = excelSheet.Range[excelSheet.Cells[1, 1], excelSheet.Cells[2, datatable.Columns.Count]];
                FormattingExcelCells(excelCellrange, "#000099", System.Drawing.Color.White, true);



                excel.Visible = true;
                excelSheet.Activate();
            }
            catch (COMException ex)
            {
                MessageBox.Show("Error accessing Excel: " + ex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }

        /// <summary>
        /// FUNCTION FOR FORMATTING EXCEL CELLS
        /// </summary>
        /// <param name="range"></param>
        /// <param name="HTMLcolorCode"></param>
        /// <param name="fontColor"></param>
        /// <param name="IsFontbool"></param>
        public void FormattingExcelCells(Microsoft.Office.Interop.Excel.Range range, string HTMLcolorCode, System.Drawing.Color fontColor, bool IsFontbool)
        {
            range.Interior.Color = System.Drawing.ColorTranslator.FromHtml(HTMLcolorCode);
            range.Font.Color = System.Drawing.ColorTranslator.ToOle(fontColor);
            if (IsFontbool == true)
            {
                range.Font.Bold = IsFontbool;
            }
        }
    }
}
