using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess
{
    public static class DataAccess
    {
        public static string CS = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=VaishnoTutorials.accdb;
Persist Security Info=False;";

        public static void AddEnquiry(string FName, string MName, string LName, string Address, string PhoneNo, string classes, string subject, string Remark)
        {
            try
            {
                OleDbConnection con = new OleDbConnection(CS);
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into tbl_Enquiry ([FirstName],[MiddleName], [LastName], [Address], [PhoneNo], [Class], [Subject], Remark, EnquiryDate) values('" + FName + "','" + MName + "','" + LName + "','" + Address + "','" + PhoneNo + "','" + classes + "','" + subject + "','" + Remark + "', '"+ DateTime.Now.ToShortDateString()+"')";
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception Ex)
            {
                DataAccess.logException(Ex.StackTrace, Ex.Message, "Fname:" + FName + ", " + "LName:" + LName + ", MName:" + MName + ",address:" + Address + ", PhoneNo:" + PhoneNo + ", class:" + classes + ", subjects:" + subject + ", Remark:" + Remark);
            }

            finally { }
        }

        public static void logException(string stackTrace, string ErrorMessage, string Parameters)
        {
            try
            {
                OleDbConnection con = new OleDbConnection(CS);
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into tbl_ExceptionLog ([TimeStamp],[StackTrace], [ErrorMessage], [Parameter]) values('" + DateTime.Now + "','" + stackTrace + "','" + ErrorMessage + "','" + Parameters + "')";
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception Ex)
            {

            }

            finally { }
        }

        public static DataSet GetAllEnquiries(int startindex, int endIndex)
        {
            DataSet ds = new DataSet();
            try {
                string sql = "select * from (select *, ( select count(*) from tbl_enquiry p2 where p1.id <= p2.id) as rowNum from tbl_enquiry p1 ) WHERE   rowNum >= " + startindex + " AND rowNum <=" + endIndex +" order by 1";
                OleDbConnection con = new OleDbConnection(CS);
                OleDbDataAdapter da = new OleDbDataAdapter(sql, con);
                con.Open();
                da.Fill(ds);
                con.Close();
               
            }
            catch (Exception ex) { }
            finally { }
            return ds;
        }

        public static DataSet GetAllAdmissions(int startindex, int endIndex, string FName, string LName, string PhoneNo, string ClassName, string PaymentStatus)
        {
            DataSet ds = new DataSet();
            try
            {
               // string sql = "select FirstName + ' ' + MiddleName + ' ' + LastName as Name,  '' as DueDate, * from (select *, ( select count(*) from tbl_admission p2 where p1.id <= p2.id) as rowNum from tbl_admission p1 ) WHERE   rowNum >= " + startindex + " AND rowNum <=" + endIndex + " order by 3";

                string whereCondition = string.Empty;
                string orderBy = "order by ID desc";
                if (FName != string.Empty)
                {
                    whereCondition += " and";
                    whereCondition += " FirstName like '%" + FName + "%' ";
                    orderBy = string.Empty;
                }
                if (LName != string.Empty)
                {
                    whereCondition += " and";
                    whereCondition += " LastName like '%" + LName + "%' ";
                    orderBy = string.Empty;
                }
                if (PhoneNo != string.Empty)
                {
                    whereCondition += " and";
                    whereCondition += " PhoneNo like '%" + PhoneNo + "%' ";
                    orderBy = string.Empty;
                }

                if (!(ClassName == string.Empty || ClassName == "-- Select --"))
                {
                    whereCondition += " and";
                    whereCondition += " [Class] like '%" + ClassName + "%' ";
                    orderBy = string.Empty;
                }

                if (!(PaymentStatus == string.Empty || PaymentStatus == "-- Select --"))
                {
                    whereCondition += " and";
                    whereCondition += " [PaymentStatus] like '%" + PaymentStatus + "%' ";
                    orderBy = string.Empty;
                }
                string sql = "select FirstName + ' ' + MiddleName + ' ' + LastName as Name,  '' as DueDate, '' as IsOverdue,  * from (select *, ( select count(*) from tbl_admission p2 where p1.id <= p2.id " + whereCondition + ") as rowNum from tbl_admission p1 )  WHERE   rowNum >= " + startindex + " AND rowNum <=" + endIndex + " " + whereCondition + ""+orderBy+ "";
                OleDbConnection con = new OleDbConnection(CS);
                OleDbDataAdapter da = new OleDbDataAdapter(sql, con);
                con.Open();
                da.Fill(ds);
                con.Close();
            }
            catch (Exception ex) { }
            finally { }
            return ds;
        }

        public static DataSet exportAdmissionsToExcel(string FName, string LName, string PhoneNo, string ClassName)
        {
            DataSet ds = new DataSet();
            try
            {
                string sql = "select ID, FirstName, MiddleName, LastName, PhoneNo,Address, Class,Subjects, TotalFees, Installments, FirstDue, SecondDue, ThirdDue, FourthDue, FirstDueDate, SecondDueDate, ThirdDueDate, FourthDueDate, isFeesSubmitted as FeesSubmitted, AdmissionDate, FirstDuePaidDate, SecondDuePaidDate, ThirdDuePaidDate, FourthDuePaidDate from tbl_Admission";

                if (FName != string.Empty || LName != string.Empty || PhoneNo != string.Empty || !(ClassName == string.Empty || ClassName == "-- Select --"))
                {
                    sql += " where";
                }
                if (FName != string.Empty)
                {
                    sql += " FirstName like '%" + FName + "%' ";
                }
                if (LName != string.Empty)
                {
                    if (FName != string.Empty)
                    {
                        sql += " and";
                    }
                    sql += " LastName like '%" + LName + "%' ";
                }
                if (PhoneNo != string.Empty)
                {
                    if (FName != string.Empty || LName != string.Empty)
                    {
                        sql += " and";
                    }
                    sql += " PhoneNo like '%" + PhoneNo + "%' ";
                }

                if (!(ClassName == string.Empty || ClassName == "-- Select --"))
                {
                    if (FName != string.Empty || LName != string.Empty || PhoneNo != string.Empty)
                    {
                        sql += " and";
                    }
                    sql += " [Class] like '%" + ClassName + "%' ";
                }

                sql += " order by ID desc";

                OleDbConnection con = new OleDbConnection(CS);
                OleDbDataAdapter da = new OleDbDataAdapter(sql, con);
                con.Open();
                da.Fill(ds);
                con.Close();
            }
            catch (Exception ex) { }
            finally { }
            return ds;
        }

        public static DataSet GetAllEnquiriesForExport()
        {
            DataSet ds = new DataSet();
            try
            {
                string sql = "select * from tbl_enquiry order by 1 desc";
                OleDbConnection con = new OleDbConnection(CS);
                OleDbDataAdapter da = new OleDbDataAdapter(sql, con);
                con.Open();
                da.Fill(ds);
                con.Close();

            }
            catch (Exception ex) { }
            finally { }
            return ds;
        }


        public static DataSet GetClassList()
        {
            DataSet ds = new DataSet();
            try
            {
                string sql = "select * from tbl_Class order by 1";
                OleDbConnection con = new OleDbConnection(CS);
                OleDbDataAdapter da = new OleDbDataAdapter(sql, con);
                con.Open();
                da.Fill(ds);
                con.Close();

            }
            catch (Exception ex) { }
            finally { }
            return ds;
        }


        public static DataSet GetPendingPayments()
        {
            DataSet ds = new DataSet();
            try
            {
                string sql = "select *, '' as DueDate from tbl_Admission  where IsFirstDue = '1' or IsSecondDue='1' or IsThirdDue = '1' or IsFourthDue='1' order by 1";
                OleDbConnection con = new OleDbConnection(CS);
                OleDbDataAdapter da = new OleDbDataAdapter(sql, con);
                con.Open();
                da.Fill(ds);
                con.Close();

            }
            catch (Exception ex) { }
            finally { }
            return ds;
        }


        public static DataSet GetSubjectList(int ClassId)
        {
            DataSet ds = new DataSet();
            try
            {
                string sql = "select * from tbl_Subjects where Classid = "+ClassId+" order by 1";
                OleDbConnection con = new OleDbConnection(CS);
                OleDbDataAdapter da = new OleDbDataAdapter(sql, con);
                con.Open();
                da.Fill(ds);
                con.Close();

            }
            catch (Exception ex) { }
            finally { }
            return ds;
        }

        public static DataSet GetRate(string SubjectId)
        {
            DataSet ds = new DataSet();
            try
            {
                string sql = "select * from tbl_Rate where SubjectId = "+SubjectId+"  order by 1";
                OleDbConnection con = new OleDbConnection(CS);
                OleDbDataAdapter da = new OleDbDataAdapter(sql, con);
                con.Open();
                da.Fill(ds);
                con.Close();

            }
            catch (Exception ex) { }
            finally { }
            return ds;
        }

        public static DataSet GetInstallments()
        {
            DataSet ds = new DataSet();
            try
            {
                string sql = "select * from tbl_installment order by 1";
                OleDbConnection con = new OleDbConnection(CS);
                OleDbDataAdapter da = new OleDbDataAdapter(sql, con);
                con.Open();
                da.Fill(ds);
                con.Close();

            }
            catch (Exception ex) { }
            finally { }
            return ds;
        }


        public static string GetEnquiryCount()
        {
            string count =  string.Empty;
            try
            {
                string sql = "SELECT count(1) FROM  tbl_enquiry ";
                OleDbConnection con = new OleDbConnection(CS);
                OleDbCommand cmd = new OleDbCommand(sql, con);
                con.Open();
                 count = cmd.ExecuteScalar().ToString();
                con.Close();

            }
            catch (Exception ex) { }
            finally { }
            return count;
        }

        public static string GetMoneyFlowCount(string FlowType)
        {
            string count = string.Empty;
            try
            {
                string whereCondition = string.Empty;
                if (!(FlowType == string.Empty || FlowType == "-- Select --"))
                {
                    whereCondition = " where Type='" + FlowType + "'";
                }
                string sql = "SELECT count(1) FROM  tbl_MoneyFlow "+whereCondition;
                OleDbConnection con = new OleDbConnection(CS);
                OleDbCommand cmd = new OleDbCommand(sql, con);
                con.Open();
                count = cmd.ExecuteScalar().ToString();
                con.Close();

            }
            catch (Exception ex) { }
            finally { }
            return count;
        }

        public static string GetAdmissionCount(string FName, string LName, string PhoneNo, string ClassName, string PaymentStatus)
        {
            string count = string.Empty;
            try
            {
                string sql = "SELECT count(1) FROM  tbl_admission";
                if (FName != string.Empty || LName != string.Empty || PhoneNo != string.Empty || (!(ClassName == string.Empty || ClassName == "-- Select --")) || (!(PaymentStatus == string.Empty || PaymentStatus == "-- Select --")))
                {
                    sql += " where";
                }

                if (FName != string.Empty)
                {
                    sql += " FirstName like '%" + FName + "%' ";
                }
                if (LName != string.Empty)
                {
                    if (FName != string.Empty)
                    {
                        sql += " and";
                    }
                    sql += " LastName like '%" + LName + "%' ";
                }
                if (PhoneNo != string.Empty)
                {
                    if (FName != string.Empty || LName != string.Empty)
                    {
                        sql += " and";
                    }
                    sql += " PhoneNo like '%" + PhoneNo + "%' ";
                }

                if (!(ClassName == string.Empty || ClassName == "-- Select --"))
                {
                    if (FName != string.Empty || LName != string.Empty || PhoneNo != string.Empty)
                    {
                        sql += " and";
                    }
                    sql += " [Class] like '%" + ClassName + "%' ";
                }

                if (!(PaymentStatus == string.Empty || PaymentStatus == "-- Select --"))
                {
                    if (FName != string.Empty || LName != string.Empty || PhoneNo != string.Empty || !(ClassName == string.Empty || ClassName == "-- Select --"))
                    {
                        sql += " and";
                    }
                    sql += " [PaymentStatus] like '%" + PaymentStatus + "%' ";
                }

                OleDbConnection con = new OleDbConnection(CS);
                OleDbCommand cmd = new OleDbCommand(sql, con);
                con.Open();
                count = cmd.ExecuteScalar().ToString();
                con.Close();

            }
            catch (Exception ex) { }
            finally { }
            return count;
        }

        public static DataSet GetStudentDetails(string studentId )
        {
            string count = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                string sql = "SELECT * FROM  tbl_admission where Id="+studentId+"";
                OleDbConnection con = new OleDbConnection(CS);
                OleDbCommand cmd = new OleDbCommand(sql, con);
                OleDbDataAdapter da = new OleDbDataAdapter(sql, con);
                con.Open();
                da.Fill(ds);
                con.Close();

            }
            catch (Exception ex) { }
            finally { }
            return ds;
        }

        public static DataSet GetEnquiryDetailsFromPhoneNumber(string PhoneNo)
        {
            DataSet ds = new DataSet();
            try
            {
               string sql = "select top 1 * from tbl_Enquiry where PhoneNo='" +PhoneNo + "'";
                OleDbConnection con = new OleDbConnection(CS);
                OleDbDataAdapter da = new OleDbDataAdapter(sql, con);
                con.Open();
                da.Fill(ds);
                con.Close();

            }
            catch (Exception ex) { }
            finally { }
             return ds;;
        }

        public static void AddNewAdmission(string FName, string MName, string LName, string Address, string PhoneNo, string classes, string subjects, string TotalFees, string istallments, string FirstDue, string SecondDue, string ThirdDue, string FourthDue, string IsFirstDue, string IsSecondDue, string IsThirdDue, string IsFourthDue,string IsFeesSubmitted, string FirstDueDate, string SecondDueDate, string ThirdDueDate, string FourthDueDate, string PaymentStatus, string FirstDuePaidDate, string SecondDuePaidDate, string ThirdDuePaidDate, string FourthDuePaidDate)
        {
            try
            {
                OleDbConnection con = new OleDbConnection(CS);
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into tbl_Admission ([FirstName],[MiddleName], [LastName], [Address], [PhoneNo], [Class], [Subjects], TotalFees, Installments, FirstDue, SecondDue, ThirdDue, FourthDue, IsFirstDue, IsSecondDue, IsThirdDue, IsFourthDue, IsfeesSubmitted, FirstDueDate, SecondDueDate, ThirdDueDate, FourthDueDate, AdmissionDate, FeesSubmitted, PaymentStatus, FirstDuePaidDate, SecondDuePaidDate, ThirdDuePaidDate, FourthDuePaidDate) values('" + FName + "','" + MName + "','" + LName + "','" + Address + "','" + PhoneNo + "','" + classes + "','" + subjects + "','" + TotalFees + "','" + istallments + "', '" + FirstDue + "','" + SecondDue + "','" + ThirdDue + "','" + FourthDue + "', '" + IsFirstDue + "', '" + IsSecondDue + "','" + IsThirdDue + "','" + IsFourthDue + "','" + IsFeesSubmitted + "','" + FirstDueDate + "', '" + SecondDueDate + "', '" + ThirdDueDate + "', '" + FourthDueDate + "', '" + DateTime.Now.Date + "','0', '" + PaymentStatus + "', '" + FirstDuePaidDate + "', '" + SecondDuePaidDate + "', '" + ThirdDuePaidDate + "', '" + FourthDuePaidDate + "')";
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception Ex)
            {
                DataAccess.logException(Ex.StackTrace, Ex.Message, "Fname:" + FName + ", " + "LName:" + LName + ", MName:" + MName + ",address:" + Address + ", PhoneNo:" + PhoneNo + ", class:" + classes + ", subjects:" + subjects + "");
            }

            finally { }
        }

        public static void UpdateStudentInfo(string studentid,string FName, string MName, string LName, string Address, string PhoneNo, string classes, string subjects, string TotalFees, string istallments, string FirstDue, string SecondDue, string ThirdDue, string FourthDue, string IsFirstDue, string IsSecondDue, string IsThirdDue, string IsFourthDue, string IsFeesSubmitted, string FirstDueDate, string SecondDueDate, string ThirdDueDate, string FourthDueDate, string FirstDuePaidDate, string SecondDuePaidDate, string ThirdDuePaidDate, string FourthDuePaidDate, string PaymentStatus)
        {
            try
            {
                OleDbConnection con = new OleDbConnection(CS);
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = "update  tbl_Admission set FirstName='" + FName + "', MiddleName='" + MName + "',LastName = '" + LName + "',Address = '" + Address + "',PhoneNo ='" + PhoneNo + "',Class ='" + classes + "',Subjects='" + subjects + "',TotalFees='" + TotalFees + "',Installments ='" + istallments + "', FirstDue ='" + FirstDue + "',SecondDue='" + SecondDue + "',ThirdDue='" + ThirdDue + "',FourthDue='" + FourthDue + "', IsFirstDue='" + IsFirstDue + "', IsSecondDue='" + IsSecondDue + "',IsThirdDue='" + IsThirdDue + "',IsFourthDue='" + IsFourthDue + "',isFeesSubmitted='" + IsFeesSubmitted + "',FirstDueDate='" + FirstDueDate + "', SecondDueDate='" + SecondDueDate + "', ThirdDueDate='" + ThirdDueDate + "', FourthDueDate='" + FourthDueDate + "', FirstDuePaidDate='" + FirstDuePaidDate + "' , SecondDuePaidDate='" + SecondDuePaidDate + "' , ThirdDuePaidDate='" + ThirdDuePaidDate + "' , FourthDuePaidDate='" + FourthDuePaidDate + "', PaymentStatus='" + PaymentStatus + "' where id= " + studentid + "";
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception Ex)
            {
                DataAccess.logException(Ex.StackTrace, Ex.Message, "Fname:" + FName + ", " + "LName:" + LName + ", MName:" + MName + ",address:" + Address + ", PhoneNo:" + PhoneNo + ", class:" + classes + ", subjects:" + subjects + "");
            }

            finally { }
        }

        public static DataSet GetAllPaymentStatus()
        {
            DataSet ds = new DataSet();
            try
            {
                OleDbConnection con = new OleDbConnection(CS);
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = con;
                string sql = "select * from tbl_PaymentStatus";
                OleDbDataAdapter da = new OleDbDataAdapter(sql, con);
                con.Open();
                da.Fill(ds);
                con.Close();
            }
            catch (Exception Ex)
            {
                DataAccess.logException(Ex.StackTrace, Ex.Message, "");
            }
               
            finally { }
            return ds;
        }

        public static DataSet GetAllMoneyFlowType()
        {
            DataSet ds = new DataSet();
            try
            {
                OleDbConnection con = new OleDbConnection(CS);
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = con;
                string sql = "select * from tbl_MoneyFlowType";
                OleDbDataAdapter da = new OleDbDataAdapter(sql, con);
                con.Open();
                da.Fill(ds);
                con.Close();
            }
            catch (Exception Ex)
            {
                DataAccess.logException(Ex.StackTrace, Ex.Message, "");
            }

            finally { }
            return ds;
        }


        public static DataSet GetAllMoneyFlow(string FlowType, int startindex, int endIndex)

        {
            DataSet ds = new DataSet();
            try
            {
                OleDbConnection con = new OleDbConnection(CS);
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = con;
                string whereCondition = string.Empty;
                if (!(FlowType == string.Empty || FlowType == "-- Select --"))
                {
                    whereCondition = "and Type='" + FlowType + "'";
                }
                //string sql = "select * from tbl_MoneyFlow where "+ whereCondition;
                string sql = "select * from (select *, ( select count(*) from tbl_MoneyFlow p2 where p1.id <= p2.id " + whereCondition + ") as rowNum from tbl_MoneyFlow p1 )  WHERE   rowNum >= " + startindex + " AND rowNum <=" + endIndex + " " + whereCondition + "";
                OleDbDataAdapter da = new OleDbDataAdapter(sql, con);
                con.Open();
                da.Fill(ds);
                con.Close();
            }
            catch (Exception Ex)
            {
                DataAccess.logException(Ex.StackTrace, Ex.Message, "");
            }

            finally { }
            return ds;
        }

        public static DataSet GetPeriod()
        {
            DataSet ds = new DataSet();
            try
            {
                OleDbConnection con = new OleDbConnection(CS);
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = con;
                string sql = "select * from tbl_Period";
                OleDbDataAdapter da = new OleDbDataAdapter(sql, con);
                con.Open();
                da.Fill(ds);
                con.Close();
            }
            catch (Exception Ex)
            {
                DataAccess.logException(Ex.StackTrace, Ex.Message, "");
            }

            finally { }
            return ds;
        }


        public static void AddNewMoneyFlow(string Name, string Description, string Amount, string FlowType, string FlowDate, string StudentId)
        {
            try
            {
                OleDbConnection con = new OleDbConnection(CS);
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into tbl_MoneyFlow (FlowName, Description, Amount, Type, FlowDate, StudentId) values('"+Name+"','" +Description+"', '" +Amount+"', '" + FlowType+"', '" +FlowDate+"', '"+StudentId+"')";
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception Ex)
            {
                DataAccess.logException(Ex.StackTrace, Ex.Message, "");
            }

            finally { }
        }

        public static void UpdateMoneyFlow(string Name, string Description, string Amount, string FlowType, string StudentID)
        {
            try
            {
                OleDbConnection con = new OleDbConnection(CS);
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = "update tbl_MoneyFlow set FlowName='"+Name+"', Description='"+Description+"', Amount='"+Amount+"', Type='"+FlowType+"', FlowDate='"+DateTime.Now.Date+"' where studentId='"+StudentID+"'";
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception Ex)
            {
                DataAccess.logException(Ex.StackTrace, Ex.Message, "");
            }

            finally { }
        }

        public static void DeleteTestData()
        {
            OleDbConnection con = new OleDbConnection(CS);
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "DELETE FROM tbl_Admission";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.CommandText = "ALTER TABLE tbl_Admission ALTER COLUMN id COUNTER (1, 1);";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close(); 
        }
    }
}
