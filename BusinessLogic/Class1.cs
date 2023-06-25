using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Enquiry
    {
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }
        string Address { get; set; }
        string PhoneNo { get; set; }
        string Class { get; set; }
        string Subject { get; set; }
        string Remark { get; set; }
    }

    public static class BusinessLogic
    {
        public static void AddEnquiry(string FName, string MName, string LName, string PhoneNo, string Address, string Class, string Subject, string Remark)
        {
            try
            {
                DataAccess.DataAccess.AddEnquiry(FName, MName, LName, Address, PhoneNo, Class, Subject, Remark);
            }
            catch (Exception Ex)
            {
                DataAccess.DataAccess.logException(Ex.StackTrace, Ex.Message, "Fname:" + FName + ", " + "LName:" + LName + ", MName:" + MName + ",address:" + Address + ", PhoneNo:" + PhoneNo + ", class:" + Class + ", subjects:" + Subject + ", Remark:" + Remark);
            }

            finally { }
        }
        public static void LogException(string stackTrace, string errorMessage, string paramters)
        {
            DataAccess.DataAccess.logException(stackTrace, errorMessage, paramters);
        }

        public static DataSet GetAllEnquiries(int startIndex, int endIndex)
        {
            return DataAccess.DataAccess.GetAllEnquiries(startIndex, endIndex);
        }

        public static DataSet GetAllAdmissions(int startIndex, int endIndex,  string FName , string LName, string PhoneNo, string ClassName, string PaymentStatus)
        {
            DataSet ds = new DataSet();
            DateTime TodaysDate = DateTime.Now;
            string firstDuePaidDate = string.Empty, secondDuePaidDate = string.Empty, thirdDuePaidDate = string.Empty, fourthDuePaidDate = string.Empty;
            if (PaymentStatus != "Overdue")
            {
                ds = DataAccess.DataAccess.GetAllAdmissions(startIndex, endIndex, FName, LName, PhoneNo, ClassName, PaymentStatus);
            }
            else if (PaymentStatus == "Overdue")
            {
                ds = DataAccess.DataAccess.GetAllAdmissions(startIndex, int.MaxValue, FName, LName, PhoneNo, ClassName, string.Empty);
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                firstDuePaidDate = ds.Tables[0].Rows[i]["FirstDuePaidDate"].ToString();
                secondDuePaidDate = ds.Tables[0].Rows[i]["SecondDuePaidDate"].ToString();
                thirdDuePaidDate = ds.Tables[0].Rows[i]["ThirdDuePaidDate"].ToString();
                fourthDuePaidDate = ds.Tables[0].Rows[i]["FourthDuePaidDate"].ToString();

                if (ds.Tables[0].Rows[i]["IsFourthDue"].ToString() == "1")
                {
                    ds.Tables[0].Rows[i]["DueDate"] = ds.Tables[0].Rows[i]["FourthDueDate"].ToString();
                }
                if (ds.Tables[0].Rows[i]["IsThirdDue"].ToString() == "1")
                {
                    ds.Tables[0].Rows[i]["DueDate"] = ds.Tables[0].Rows[i]["ThirdDueDate"].ToString();
                }
                if (ds.Tables[0].Rows[i]["IsSecondDue"].ToString() == "1")
                {
                    ds.Tables[0].Rows[i]["DueDate"] = ds.Tables[0].Rows[i]["SecondDueDate"].ToString();
                }
                if (ds.Tables[0].Rows[i]["IsFirstDue"].ToString() == "1")
                {
                    ds.Tables[0].Rows[i]["DueDate"] = ds.Tables[0].Rows[i]["FirstDueDate"].ToString();
                }
                if (ds.Tables[0].Rows[i]["PaymentStatus"].ToString() == "Completed")
                {
                    ds.Tables[0].Rows[i]["DueDate"] = "NA";
                }
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[i]["AdmissionDate"].ToString()))
                {
                    ds.Tables[0].Rows[i]["AdmissionDate"] = Convert.ToDateTime(ds.Tables[0].Rows[i]["AdmissionDate"]).ToShortDateString();
                }
                if (ds.Tables[0].Rows[i]["DueDate"].ToString() != "NA")
                {
                    if (Convert.ToDateTime(ds.Tables[0].Rows[i]["DueDate"]).Date > TodaysDate.AddDays(5).Date)
                    {
                        ds.Tables[0].Rows[i]["IsOverdue"] = false;
                    }
                    else
                    {
                        ds.Tables[0].Rows[i]["IsOverdue"] = true;
                    }
                }
            }
            //if (!(PaymentStatus == string.Empty || PaymentStatus == "-- Select --"))
            //{
            //    if(PaymentStatus != "Pending")
            //    ds.Tables[0].DefaultView.RowFilter = "PaymentStatus = '" + PaymentStatus + "'";
            //    else
            //        ds.Tables[0].DefaultView.RowFilter = "PaymentStatus <> 'Completed' and rowNum >= " + startIndex + " AND rowNum <=" + endIndex + "";
            //}
            if (PaymentStatus == "Overdue")
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["DueDate"].ToString() != "NA")
                    {
                        if (Convert.ToDateTime(ds.Tables[0].Rows[i]["DueDate"]).Date > TodaysDate.AddDays(5).Date)
                        {
                            ds.Tables[0].Rows[i].Delete();
                        }
                    }
                    else
                    {
                        ds.Tables[0].Rows[i].Delete();
                    }
                }
                ds.Tables[0].AcceptChanges();
            }
              return ds;
        }

        public static DataSet GetAllPaymentStatus()
        {
         return   DataAccess.DataAccess.GetAllPaymentStatus();
        }

        public static void GetPendingPayments()
        {
            DataSet ds = new DataSet();
            DateTime dt = new DateTime();
            ds = DataAccess.DataAccess.GetPendingPayments();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["IsFourthDue"].ToString() == "1")
                {
                    ds.Tables[0].Rows[i]["DueDate"] = ds.Tables[0].Rows[i]["FourthDueDate"].ToString();
                }
                if (ds.Tables[0].Rows[i]["IsThirdDue"].ToString() == "1")
                {
                    ds.Tables[0].Rows[i]["DueDate"] = ds.Tables[0].Rows[i]["ThirdDueDate"].ToString();
                }
                if (ds.Tables[0].Rows[i]["IsSecondDue"].ToString() == "1")
                {
                    ds.Tables[0].Rows[i]["DueDate"] = ds.Tables[0].Rows[i]["SecondDueDate"].ToString();
                }
                if (ds.Tables[0].Rows[i]["IsFirstDue"].ToString() == "1")
                {
                    ds.Tables[0].Rows[i]["DueDate"] = ds.Tables[0].Rows[i]["FirstDueDate"].ToString();
                }

                if (ds.Tables[0].Rows[i]["DueDate"].ToString() != string.Empty)
                {
                    dt = Convert.ToDateTime(ds.Tables[0].Rows[i]["DueDate"]);

                    if (dt.Date >= DateTime.Now.Date.AddDays(5))
                    {
                        ds.Tables[0].Rows[i].Delete();
                    }
                }

               
            }

        }


        public static int GetEnquiryCount()
        {
            return Convert.ToInt32(DataAccess.DataAccess.GetEnquiryCount());
        }

        public static int GetMoneyFlowCount(string FlowType)
        {
            return Convert.ToInt32(DataAccess.DataAccess.GetMoneyFlowCount(FlowType));
        }

        public static DataSet GetStudentDetails(string studentId)
        {
            return DataAccess.DataAccess.GetStudentDetails(studentId);
        }
        public static int GetAdmissionCount(string FName, string LName, string PhoneNo, string ClassName, string PaymentStatus)
        {
            return Convert.ToInt32(DataAccess.DataAccess.GetAdmissionCount(FName, LName, PhoneNo, ClassName, PaymentStatus));
        }
        public static DataSet GetEnquiryForExport()
        {
            return DataAccess.DataAccess.GetAllEnquiriesForExport();
        }

        public static DataSet exportAdmissionsToExcel(string FName, string LName, string PhoneNo, string ClassName)
        {
            return DataAccess.DataAccess.exportAdmissionsToExcel(FName, LName, PhoneNo, ClassName);
        }

        public static DataSet GetClassList()
        {
            return DataAccess.DataAccess.GetClassList();
        }

        public static DataSet GetSubjectList(int ClassId)
        {
            return DataAccess.DataAccess.GetSubjectList(ClassId);
        }

        public static DataSet GetPeriod()
        {
            return DataAccess.DataAccess.GetPeriod();
        }

        public static string GetRate(string SubjectId)
        {
            DataSet ds = DataAccess.DataAccess.GetRate(SubjectId);
            return ds.Tables[0].Rows[0]["Rate"].ToString();
        }

        public static DataSet GetInstallments()
        {
            return DataAccess.DataAccess.GetInstallments();
        }

        public static DataSet GetAllMoneyFlowType()
        {
            return DataAccess.DataAccess.GetAllMoneyFlowType();
        }

        public static DataSet GetEnquiryDetailsFromPhoneNumber(string PhoneNo)
        {
            return DataAccess.DataAccess.GetEnquiryDetailsFromPhoneNumber(PhoneNo);
        }

        public static void AddNewAdmission(string FName, string MName, string LName, string PhoneNo, string Address, string Class, string Subject, string TotalFees, string istallments, string FirstDue, string SecondDue, string ThirdDue, string FourthDue, string IsFirstDue, string IsSecondDue, string IsThirdDue, string IsFourthDue, string IsFeesSubmitted, string FirstDueDate, string SecondDueDate, string ThirdDueDate,string FourthDueDate, string PaymentStatus, string FirstDuePaidDate, string SecondDuePaidDate, string ThirdDuePaidDate, string FourthDuePaidDate)
        {
            try
            {
                DataAccess.DataAccess.AddNewAdmission(FName, MName, LName, Address, PhoneNo, Class, Subject, TotalFees, istallments, FirstDue, SecondDue, ThirdDue, FourthDue ,IsFirstDue, IsSecondDue, IsThirdDue, IsFourthDue, IsFeesSubmitted, FirstDueDate, SecondDueDate, ThirdDueDate, FourthDueDate, PaymentStatus, FirstDuePaidDate, SecondDuePaidDate, ThirdDuePaidDate, FourthDuePaidDate);
            }
            catch (Exception Ex)
            {
                DataAccess.DataAccess.logException(Ex.StackTrace, Ex.Message, "Fname:" + FName + ", " + "LName:" + LName + ", MName:" + MName + ",address:" + Address + ", PhoneNo:" + PhoneNo + ", class:" + Class + ", subjects:" + Subject + "");
            }

            finally { }
        }

        public static void UpdateStudentInfo(string studentid, string FName, string MName, string LName, string PhoneNo, string Address, string Class, string Subject, string TotalFees, string istallments, string FirstDue, string SecondDue, string ThirdDue, string FourthDue, string IsFirstDue, string IsSecondDue, string IsThirdDue, string IsFourthDue, string IsFeesSubmitted, string FirstDueDate, string SecondDueDate, string ThirdDueDate, string FourthDueDate, string FirstDuePaidDate, string SecondDuePaidDate, string ThirdDuePaidDate, string FourthDuePaidDate, string PaymentStatus)
        {
            try
            {
                DataAccess.DataAccess.UpdateStudentInfo(studentid, FName, MName, LName, Address, PhoneNo, Class, Subject, TotalFees, istallments, FirstDue, SecondDue, ThirdDue, FourthDue, IsFirstDue, IsSecondDue, IsThirdDue, IsFourthDue, IsFeesSubmitted, FirstDueDate, SecondDueDate, ThirdDueDate, FourthDueDate, FirstDuePaidDate, SecondDuePaidDate, ThirdDuePaidDate, FourthDuePaidDate, PaymentStatus);
            }
            catch (Exception Ex)
            {
                DataAccess.DataAccess.logException(Ex.StackTrace, Ex.Message, "Fname:" + FName + ", " + "LName:" + LName + ", MName:" + MName + ",address:" + Address + ", PhoneNo:" + PhoneNo + ", class:" + Class + ", subjects:" + Subject + "");
            }

            finally { }
        }

        public static void AddNewMoneyFlow(string Name, string Description, string Amount, string FlowType, string FlowDate, string StudentId = "0")
        {
            try
            {
                DataAccess.DataAccess.AddNewMoneyFlow(Name, Description, Amount, FlowType, FlowDate,StudentId);
            }
            catch (Exception Ex)
            {
                DataAccess.DataAccess.logException(Ex.StackTrace, Ex.Message, "");
            }

            finally { }
        }
        public static void UpdateMoneyFlow(string Name, string Description, string Amount, string FlowType, string StudentId)
        {
            try
            {
                DataAccess.DataAccess.UpdateMoneyFlow(Name, Description, Amount, FlowType, StudentId);
            }
            catch (Exception Ex)
            {
                DataAccess.DataAccess.logException(Ex.StackTrace, Ex.Message, "");
            }

            finally { }
        }

        public static DataSet GetAllMoneyFlow(string FlowType, int startindex, int endindex)
        {
            DataSet ds = DataAccess.DataAccess.GetAllMoneyFlow(FlowType, startindex, endindex);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["FlowDate"] = Convert.ToDateTime(ds.Tables[0].Rows[i]["FlowDate"]).ToShortDateString(); 
            }
            return ds;
        }

        public static DataTable GetMoneyFlowForDuration(string Duration, string FlowType, int startindex, int endindex)
        {
            DataSet ds = new DataSet();
            DataTable newDs = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "Key";
            newDs.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "Amount";
            newDs.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "Period";
            newDs.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "FlowType";
            newDs.Columns.Add(dc);

            DataRow dr = newDs.NewRow();

           
            if (FlowType == "Income" || FlowType == "Expenditure")
            {
                 ds = DataAccess.DataAccess.GetAllMoneyFlow(FlowType, startindex, endindex);
                if (Duration == "Yearly")
                {
                    var query = from r in ds.Tables[0].Rows.Cast<DataRow>()
                                let FlowDate = Convert.ToDateTime(r[6])
                                group r by new DateTime(FlowDate.Year)
                                    into g
                                    select new
                                    {
                                        g.Key,
                                        Sum = g.Sum(r => Convert.ToInt32(r[4])),
                                        Year = g.Min(r =>Convert.ToDateTime(r[6]).Year).ToString()
                                    };

                    foreach (var s in query)
                    {
                       dr[0] = s.Key.ToString();
                        dr[1] = s.Sum.ToString();
                        dr[2] = s.Year.ToString();
                        dr[3] = FlowType;
                        newDs.Rows.Add(dr);
                        dr = newDs.NewRow();
                    }

                }

                else if(Duration == "Monthly")
                {
                    var query = from r in ds.Tables[0].Rows.Cast<DataRow>()
                                let month = Convert.ToDateTime(r[6]).Month
                                let year = Convert.ToDateTime(r[6]).Year
                                group r by new { year, month }
                                    into g
                                    select new
                                    {
                                        g.Key,
                                        Sum = g.Sum(r => Convert.ToInt32(r[4])),
                                        Year = g.Min(r => Convert.ToDateTime(r[6]).Year + " - "+ Convert.ToDateTime(r[6]).ToString("MMM", CultureInfo.InvariantCulture))
                                    };

                    foreach (var s in query)
                    {
                        dr[0] = s.Key.ToString();
                        dr[1] = s.Sum.ToString();
                        dr[2] = s.Year.ToString();
                        dr[3] = FlowType;
                        newDs.Rows.Add(dr);
                        dr = newDs.NewRow();
                    }
                }

                else if (Duration == "Quarterly")
                {
                    var query = from r in ds.Tables[0].Rows.Cast<DataRow>()
                                let Quarter = (Convert.ToDateTime(r[6]).Month-1) / 3
                                let year = Convert.ToDateTime(r[6]).Year
                                group r by new { year, Quarter }
                                    into g
                                    select new
                                    {
                                        g.Key,
                                        Sum = g.Sum(r => Convert.ToInt32(r[4])),
                                        Year = g.Min(r => Convert.ToDateTime(r[6]).Year + " - " + Convert.ToDateTime(r[6]).ToString("MMM", CultureInfo.InvariantCulture))
                                    };

                    foreach (var s in query)
                    {
                        dr[0] = s.Key.ToString();
                        dr[1] = s.Sum.ToString();
                        dr[2] = s.Key.ToString();
                        dr[3] = FlowType;
                        newDs.Rows.Add(dr);
                        dr = newDs.NewRow();
                    }
                }
            }
            else if (FlowType == "Profit")
            {
               DataTable expenditureDt = CalculateRevenue(Duration, startindex, endindex);
               newDs = expenditureDt;
            }
            return newDs;
        }

        private static DataTable CalculateRevenue(string Duration, int startindex, int endindex) {
            int index=0;
            DataTable incomeDt = GetMoneyFlowForDuration(Duration, "Income", startindex, endindex);
            DataTable expenditureDt = GetMoneyFlowForDuration(Duration, "Expenditure", startindex, endindex);

            DataTable revenueDt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "Key";
            revenueDt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "Amount";
            revenueDt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "Period";
            revenueDt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "FlowType";
            revenueDt.Columns.Add(dc);

            DataRow dr = revenueDt.NewRow();

            if(incomeDt.Rows.Count > expenditureDt.Rows.Count)
                index = incomeDt.Rows.Count;
            else
                index = expenditureDt.Rows.Count;
             DataTable TableC = new DataTable();
             DataTable TableD = new DataTable();
            if (incomeDt.Rows.Count > 0)
            {
               
                var rows = incomeDt.AsEnumerable()
        .Where(ra => !expenditureDt.AsEnumerable()
                            .Any(rb => rb.Field<string>("Period") == ra.Field<string>("Period")));
       // .CopyToDataTable();
                if (rows.Any())
                    TableC = rows.CopyToDataTable();
            }
            if (expenditureDt.Rows.Count > 0)
            {
               
                var rows = expenditureDt.AsEnumerable()
        .Where(ra => !incomeDt.AsEnumerable()
                            .Any(rb => rb.Field<string>("Period") == ra.Field<string>("Period")));
       // .CopyToDataTable();

                if (rows.Any())
                    TableD = rows.CopyToDataTable();
            }



            for (int i = 0; i < incomeDt.Rows.Count; i++)
            {
                for (int j = 0; j < expenditureDt.Rows.Count; j++)
                {
                    if (incomeDt.Rows[i][2].ToString() == expenditureDt.Rows[j][2].ToString())
                    {
                        dr[0] = incomeDt.Rows[i][0];
                        dr[1] = Convert.ToInt32(incomeDt.Rows[i][1]) - Convert.ToInt32(expenditureDt.Rows[j][1]);
                        dr[2] = incomeDt.Rows[i][2];
                        dr[3] = "Profit";
                        revenueDt.Rows.Add(dr);
                        dr = revenueDt.NewRow();
                    }
                }
            }
            
            DataRow dr1 = revenueDt.NewRow();

            for (int i = 0; i < TableC.Rows.Count; i++)
            {
                
                dr1[0] = TableC.Rows[i][0];
                dr1[1] = TableC.Rows[i][1];
                dr1[2] = TableC.Rows[i][2];
                dr1[3] = "Profit";
                revenueDt.Rows.Add(dr1);
                dr1 = revenueDt.NewRow();
            }

            for (int i = 0; i < TableD.Rows.Count; i++)
            {
                dr1[0] = TableD.Rows[i][0];
                dr1[1] = -Convert.ToInt32(TableD.Rows[i][1]);
                dr1[2] = TableD.Rows[i][2];
                dr1[3] = "Profit";
                revenueDt.Rows.Add(dr1);
                dr1 = revenueDt.NewRow();
            }
                return revenueDt;
        }

        public static void DeleteTestData()
        {
            DataAccess.DataAccess.DeleteTestData();
        }
    }
}