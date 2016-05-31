using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using EntityMapper;
using System.Linq;
using System.Configuration;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{
    public class AttnClockAmendmentDAO
    {
        // private dbConnection conn;
        string strSQL = string.Empty;

        /// <constructor>
        /// Constructor YearDAO
        /// </constructor>
        public AttnClockAmendmentDAO()
        {
            //conn = new dbConnection();
        }

        #region GetYearList()
        public List<AttnClockAmendmentVO> GetClockAmendmentList(string strStartDt, string strEndDt, string strEmpCode)
        {
            try
            {
                if (string.IsNullOrEmpty(strStartDt) || string.IsNullOrEmpty(strEndDt) || string.IsNullOrEmpty(strEmpCode))
                {
                    return null;
                }

                strSQL = "EXEC SP_DATEWISE_AMEND_REPORT_EMPLOYEE '" + String.Format("{0:dd/MMM/yyyy}", strStartDt) + "','" + String.Format("{0:dd/MMM/yyyy}", strEndDt) + "','" + strEmpCode.Trim() + "'";
                return BindClassWithData.BindClass<AttnClockAmendmentVO>(SQLHelper.ShowRecord(strSQL)).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion ...


        #region Get Grid Data for Ammendment by date
        //public string GetClockAmmendDateData(string CurrDate,string Branch,string Dept,string Desig,string EType,string Grade)
         public List<AttnClockAmendmentVO>  GetClockAmmendDateData(string CurrDate, string Branch, string Dept, string Desig, string EType, string Grade)
        {
           // string GridData;
            try
            {
                strSQL = "EXEC SP_DATEWISE_AMEND_REPORT '" + String.Format("{0:dd/MMM/yyyy}", CurrDate) + "','" + String.Format("{0:dd/MMM/yyyy}", CurrDate) + "'," + Branch + "," + Dept + "," + Desig + "," + EType + "," + Grade;
                //GridData=DataTableToJSONWithStringBuilder(SQLHelper.ShowRecord(strSQL));
                //return GridData;
               return BindClassWithData.BindClass<AttnClockAmendmentVO>(SQLHelper.ShowRecord(strSQL)).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion ...



        public string DataTableToJSONWithStringBuilder(DataTable table)
        {
            var JSONString = new StringBuilder();
            if (table.Rows.Count > 0)
            {
                JSONString.Append("[");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    JSONString.Append("{");
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        if (j < table.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\",");
                        }
                        else if (j == table.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\"");
                        }
                    }
                    if (i == table.Rows.Count - 1)
                    {
                        JSONString.Append("}");
                    }
                    else
                    {
                        JSONString.Append("},");
                    }
                }
                JSONString.Append("]");
            }
            return JSONString.ToString();
        }


        #region DelAttnLog
        public int DelAttnLog(string strRowMainId, string strRowDetId)
        {
            QueryBuilderHelper querybuilder;
            string strSqlQuarry = string.Empty;
            string strSqlQuarry1 = string.Empty;
            
            int rtn1 = 0, rtn2 = 0;

            try
            {

                if (string.IsNullOrEmpty(strRowMainId) && string.IsNullOrEmpty(strRowDetId))
                {

                    return -1; // null values of Row Main ID and RowDetId
                }


                /*
                Delete attendance => 

                Set the Activate to I in TRAN_ATTNENDANCE_FINAL_LOG
                set the Activate to I in TRANS_ATTN_MAIN where 
                PROCESSED flag is null.

                Attendance delete process steps:

                1. Only delete the attendance details which OT is not processed. ie. the system not delete OT processed attendance.

                2. De Activate those record deleted by the user.

                */


                // UPDATE RECORD ...

                if (!String.IsNullOrEmpty(strRowMainId))
                {
                    querybuilder = new QueryBuilderHelper();
                    querybuilder.QueryType = QueryTypes.Update;
                    querybuilder.AddTable("TRAN_ATTN_MAIN");
                    querybuilder.AddNameValuePair("Activate", "'I'");
                    querybuilder.AddNameValuePair("REJECTED_ATTENDANCE", "1");
                    querybuilder.AddNameValuePair("Edit_By", "'" + GlobalVariable.UserCode.Trim() + "'");
                    querybuilder.AddNameValuePair("Edit_Date", "GETDATE()");
                    querybuilder.AddCondition("ROW_ID='" + strRowMainId.Trim() + "'");

                    strSqlQuarry = querybuilder.ToString();
                }

                if (!String.IsNullOrEmpty(strRowDetId))
                {
                    querybuilder = new QueryBuilderHelper();
                    querybuilder.QueryType = QueryTypes.Update;
                    querybuilder.AddTable("TRAN_ATTNENDANCE_FINAL_LOG");
                    querybuilder.AddNameValuePair("Activate", "'I'");

                    querybuilder.AddNameValuePair("Edit_By", "'" + GlobalVariable.UserCode.Trim() + "'");
                    querybuilder.AddNameValuePair("Edit_Date", "GETDATE()");
                    querybuilder.AddCondition("ROW_ID='" + strRowDetId.Trim() + "'");

                    strSqlQuarry1 = querybuilder.ToString();
                }

                if (!string.IsNullOrEmpty(strSqlQuarry))
                {
                    rtn1 = SQLHelper.InsertRecord(strSqlQuarry);
                }

                if (!string.IsNullOrEmpty(strSqlQuarry1))
                {
                    rtn2 = SQLHelper.InsertRecord(strSqlQuarry1);
                }

                if (rtn1 > 0 && rtn2 > 0)
                {
                    return 0;//success
                }
                else
                    return -2;// failed
            }
            catch (Exception ex)
            {
                return -3; // exception ....
            }
        }
        #endregion DelAttnLog


        #region LoadDataGridList
        public List<AttnClockAmendmentVO> LoadDataGridList(string strStartDt, string strEndDt, string strEmpCode)
        {
            try
            {
                if (string.IsNullOrEmpty(strStartDt) || string.IsNullOrEmpty(strEndDt) || string.IsNullOrEmpty(strEmpCode))
                {
                    return null;
                }

                strSQL = "EXEC SP_DATEWISE_AMEND_REPORT_EMPLOYEE '" + String.Format("{0:dd/MMM/yyyy}", strStartDt) + "','" + String.Format("{0:dd/MMM/yyyy}", strEndDt) + "','" + strEmpCode.Trim() + "'";
                return SQLHelper.ShowRecord(strSQL).DataTableToList<AttnClockAmendmentVO>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...


        #region LoadDataGridBindingList
        public bool CheckClockingTime(string strMemberCode, string strLogdate, string strClockedTime, string strRowId)
        {

            try
            {

                strSQL = "SELECT MEM_CODE FROM TRAN_ATTNENDANCE_FINAL_LOG WHERE MEM_CODE='" + strMemberCode.Trim() + "' \n" +
                      " AND PUNCH_DATE='" + String.Format("{0:dd/MMM/yyyy}", strLogdate) + "' AND CLOKIN_TIME='" + strClockedTime.Trim() + "' \n" +
                      " and ROW_ID <> '" + strRowId + "'";
                return (SQLHelper.ShowRecord(strSQL).Rows.Count > 0);

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion ...

        #region Save Clock - in out 
        public bool AddNewLog(string strMemberCode, string strLogdate, string strClockedInTime, string strClockedOutTime, string strReason, string strRowId, string strStatus)
        {

            try
            {
                DataTable dtData;
                if (string.IsNullOrEmpty(strRowId)) // insert
                {
                    strSQL = "SELECT ENROLL_NO,Branch_ID FROM MASTER_EMPLOYEE_MAIN WHERE MEM_CODE='" + strMemberCode.Trim() + "'";
                    dtData = new DataTable();
                    dtData = SQLHelper.ShowRecord(strSQL);

                    if (dtData.Rows.Count > 0)
                    {
                        strSQL = "EXEC SP_INSERT_NEW_LOGS_ATTENDENCE_MAIN '" + strMemberCode.Trim() + "', \n" +
                        "'" + dtData.Rows[0]["ENROLL_NO"].ToString() + "','" + String.Format("{0:HH:mm}", strClockedInTime) + "','" + String.Format("{0:HH:mm}", strClockedOutTime) + "',\n" +
                        "'" + String.Format("{0:yyyy-MM-dd}", strLogdate) + "',null," + dtData.Rows[0]["Branch_ID"].ToString() + ",'IN-OUT','" + strReason.Trim() + "','I'";
                    }
                    else
                        return false;
                }
                else if (!string.IsNullOrEmpty(strRowId)) // Falg == "Update")
                {
                    if (strStatus.Trim() == "IN-OUT")
                    {
                        strSQL = "EXEC SP_UPDATE_ATTENDENCE_MAIN '" + strMemberCode.Trim() + "','" + String.Format("{0:HH:mm}", strClockedInTime) + "','" + String.Format("{0:HH:mm}", strClockedOutTime) + "',\n" +
                          "'" + String.Format("{0:dd/MMM/yyyy}", strLogdate) + "','" + strReason.Trim() + "',0,'" + strRowId.Trim() + "','I'";
                    }
                }


                return (SQLHelper.InsertRecord(strSQL) > 0);


            }
            catch (Exception ex)
            {
        
                return false;
            }
        }
        #endregion

        #region ProcessAttnLog
        public int ProcessAttnLog(string strProcedure, DataTable dt)
        {

            try
            {
                return SQLHelper.InsertRecord(strProcedure, dt);
            }
            catch (Exception ex)
            {
                return -3; // exception ....
            }
        }
        #endregion ProcessAttnLog

        #region Insert Record using stored procedure

        public static int InsertRecord(string strSpname, DataTable dt)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            try
            {

                using (SqlConnection cnn = new SqlConnection(connectionString))
                {

                    SqlCommand cmd = new SqlCommand(strSpname, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter sqlparam = cmd.Parameters.AddWithValue("@dt", dt);
                    sqlparam.SqlDbType = SqlDbType.Structured;
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();

                }
                return (0);
            }
            catch (Exception exp)
            {
                return -1;
            }
        }

        #endregion Insert Record using stored procedure

        #region LoadDataGridBindingList
        public BindingList<AttnClockAmendmentVO> LoadDataGridBindingList(string strStartDt, string strEndDt, string strEmpCode)
        {
            try
            {
                strSQL = "SELECT PLACE_Id,PLACE_Name,ACTIVATE FROM MASTER_TOUR_PLACE";
                try
                {
                    if (string.IsNullOrEmpty(strStartDt) || string.IsNullOrEmpty(strEndDt) || string.IsNullOrEmpty(strEmpCode))
                    {
                        return null;
                    }

                    strSQL = "EXEC SP_DATEWISE_AMEND_REPORT_EMPLOYEE '" + String.Format("{0:dd/MMM/yyyy}", strStartDt) + "','" + String.Format("{0:dd/MMM/yyyy}", strEndDt) + "','" + strEmpCode.Trim() + "'";
                    return new BindingList<AttnClockAmendmentVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<AttnClockAmendmentVO>());

                }
                catch (Exception ex)
                {
                    return null;
                }








            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region LoadDataGridBindingList
        //public bool CheckClockingTime(string strMemberCode, string strLogdate, string strClockedTime, string strRowId)
        //{

        //    try
        //    {

        //        strSQL = "SELECT MEM_CODE FROM TRAN_ATTNENDANCE_FINAL_LOG WHERE MEM_CODE='" + strMemberCode.Trim() + "' \n" +
        //              " AND PUNCH_DATE='" + String.Format("{0:dd/MMM/yyyy}", strLogdate) + "' AND CLOKIN_TIME='" + strClockedTime.Trim() + "' \n" +
        //              " and ROW_ID <> '" + strRowId + "'";
        //        return (SQLHelper.ShowRecord(strSQL).Rows.Count > 0);

        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}
        #endregion ...








    }
}
