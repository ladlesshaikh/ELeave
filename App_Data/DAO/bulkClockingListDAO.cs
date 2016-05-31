using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using EntityMapper;
using System.Linq;

namespace ATTNPAY.Core
{
    public class BulkClockingListDAO
    {
       // private dbConnection conn;
        string strSQL = string.Empty;
        ShiftBUS _shiftBus = new ShiftBUS();

        /// <constructor>
        /// Constructor BulkClockingListDAO
        /// </constructor>
        public BulkClockingListDAO()
        {
            //conn = new dbConnection();
        }

        #region LoadEmployeeList
        public List<BulkClockingListVO> LoadEmployeeList( bool iInsertNewClock, string strLogDt,int iShiftType=0,
               int ibranchId=0, int idepartment=0,int iDesignation=0,int iGrade=0, int iEmployeeType=0 )
        {
            try
            {

                if (iInsertNewClock == false)
                {
                    //ISNULL(convert(varchar(38), DTL_ROW_ID),'') DTL_ROW_ID

                    //ISNULL(CONVERT(nvarchar(8), TF.CLOKIN_TIME), '') CLOCKIN, 
                    // ISNULL(CONVERT(nvarchar(8), TF.CLOCKOUT_TIME), '') CLOCKOUT, 

                    //strSQL = "SELECT  1 SEL,M.MEM_CODE,M.ENROLL_NO,M.Member_Name,M.Branch_ID,M.Employee_Type_Id Employee_Type,ISNULL(CONVERT(nvarchar(8), TF.CLOKIN_TIME), '') CLOCKIN, \n" +
                    //          " ISNULL(CONVERT(nvarchar(8), TF.CLOCKOUT_TIME), '') CLOCKOUT,ISNULL(convert(varchar(38), TF.ROW_ID),'') ROW_ID  FROM TRAN_ATTN_MAIN T  \n" +
                    //          " INNER JOIN MASTER_EMPLOYEE_MAIN M ON T.MEM_CODE = M.MEM_CODE \n" +
                    //          " INNER JOIN TRAN_ATTNENDANCE_FINAL_LOG TF ON T.ROW_ID = TF.MAIN_ROW_ID \n" +
                    //          " WHERE LOG_DATE='" + string.Format("{0:dd/MMM/yyyy}", strLogDt.Trim()) + "' AND TF.STATUS='IN-OUT' \n" +
                    //          " AND T.MEM_CODE  \n" +
                    //          " NOT IN (SELECT MEM_CODE FROM TRAN_LEAVE WHERE '" + string.Format("{0:dd/MMM/yyyy}", strLogDt.Trim()) + "' BETWEEN FROM_DATE AND TO_DATE)  \n" +
                    //          " AND T.MEM_CODE NOT IN  \n" +
                    //          " ( SELECT MEM_CODE FROM TRAN_TOUR WHERE '" + string.Format("{0:dd/MMM/yyyy}", strLogDt.Trim()) + "' BETWEEN FROM_DATE AND TO_DATE)";

                    strSQL = "SELECT  1 SEL,M.MEM_CODE,M.ENROLL_NO,M.Member_Name,M.Branch_ID," +
                             "BR.[Branch_Name]," +
                             "ET.[Employee_Type] as emp_type_name," +
                             "M.Employee_Type_Id Employee_Type," +
                             "ISNULL(CONVERT(nvarchar(8), TF.CLOKIN_TIME), '') CLOCKIN," +
                             "ISNULL(CONVERT(nvarchar(8), TF.CLOCKOUT_TIME), '') CLOCKOUT," +
                             "ISNULL(convert(varchar(38), TF.ROW_ID), '') ROW_ID FROM TRAN_ATTN_MAIN  T " +
                             "INNER JOIN MASTER_EMPLOYEE_MAIN M ON T.MEM_CODE = M.MEM_CODE " +
                             "INNER JOIN TRAN_ATTNENDANCE_FINAL_LOG TF ON T.ROW_ID = TF.MAIN_ROW_ID " +
                             "INNER JOIN MASTER_BRANCH BR ON M.Branch_ID = BR.Branch_ID " +
                             "INNER JOIN MASTER_EMPLOYEE_TYPE ET ON ET.Employee_Type_Id = M.Employee_Type_Id " +
                             "WHERE LOG_DATE = '" + string.Format("{0:dd/MMM/yyyy}", strLogDt.Trim()) + "' AND TF.STATUS = 'IN-OUT' " +
                             "AND T.MEM_CODE " +
                             "NOT IN(SELECT MEM_CODE FROM TRAN_LEAVE WHERE '" + string.Format("{0:dd/MMM/yyyy}", strLogDt.Trim()) + "' BETWEEN FROM_DATE AND TO_DATE) " +
                             "AND T.MEM_CODE NOT IN " +
                             "(SELECT MEM_CODE FROM TRAN_TOUR WHERE '" + string.Format("{0:dd/MMM/yyyy}", strLogDt.Trim()) + "' BETWEEN FROM_DATE AND TO_DATE)";    
                }
            else
            {

                if (iShiftType != 0 )
                {

                        strSQL = "SELECT  1 SEL,M.MEM_CODE,M.ENROLL_NO,M.Member_Name,M.Branch_ID,M.Employee_Type_Id Employee_Type,'00:00' CLOCKIN, \n" +
                                 " '00:00' CLOCKOUT,'' ROW_ID  FROM MASTER_EMPLOYEE_MAIN M  \n" +
                                 " LEFT OUTER JOIN TRAN_SHIFT_ROSTER SR ON M.MEM_CODE=SR.MEM_CODE \n" +
                                 " WHERE SR.SCH_TYPE_ID=" + iShiftType.ToString() + " AND \n" +
                                 " M.MEM_CODE  \n" +
                                 " NOT IN (SELECT MEM_CODE FROM TRAN_LEAVE WHERE '" + string.Format("{0:dd/MMM/yyyy}", strLogDt.Trim()) + "' BETWEEN FROM_DATE AND TO_DATE)   \n" +
                                 " AND M.MEM_CODE NOT IN   \n" +
                                 " (SELECT MEM_CODE FROM TRAN_TOUR WHERE '" + string.Format("{0:dd/MMM/yyyy}", strLogDt.Trim()) + "' BETWEEN FROM_DATE AND TO_DATE) \n" +
                                 " AND M.MEM_CODE NOT IN (SELECT MEM_CODE FROM TRAN_ATTN_MAIN WHERE LOG_DATE='" + string.Format("{0:dd/MMM/yyyy}", strLogDt.Trim()) + "') ";
                   
                }
                else
                {
                        
                        strSQL = "SELECT  1 SEL,M.MEM_CODE,M.ENROLL_NO,M.Member_Name,M.Branch_ID,M.Employee_Type_Id Employee_Type,'00:00' CLOCKIN, BR.[Branch_Name],ET.[Employee_Type] as emp_type_name, \n" +
                                 " BR.[Branch_Name],ET.[Employee_Type],"+ 
                                 " '00:00' CLOCKOUT,'' ROW_ID  FROM MASTER_EMPLOYEE_MAIN M  \n" +
                                 " INNER JOIN MASTER_BRANCH BR ON M.Branch_ID = BR.Branch_ID"+
                                 " INNER JOIN MASTER_EMPLOYEE_TYPE ET ON ET.Employee_Type_Id = M.Employee_Type_Id"+
                                 " WHERE  \n" +
                                 " M.MEM_CODE  \n" +
                                 " NOT IN (SELECT MEM_CODE FROM TRAN_LEAVE WHERE '" + string.Format("{0:dd/MMM/yyyy}", strLogDt.Trim()) + "' BETWEEN FROM_DATE AND TO_DATE)   \n" +
                                 " AND M.MEM_CODE NOT IN   \n" +
                                 " (SELECT MEM_CODE FROM TRAN_TOUR WHERE '" + string.Format("{0:dd/MMM/yyyy}", strLogDt.Trim()) + "' BETWEEN FROM_DATE AND TO_DATE) \n" +
                                 " AND M.MEM_CODE NOT IN (SELECT MEM_CODE FROM TRAN_ATTN_MAIN WHERE LOG_DATE='" + string.Format("{0:dd/MMM/yyyy}", strLogDt.Trim()) + "') ";
                    
                }

            }

            if (ibranchId != 0)
            {
                    strSQL = strSQL + " AND M.Branch_ID='" + ibranchId.ToString().Trim() + "'";
            }
            if (idepartment != 0)
                {

                    strSQL = strSQL + " AND M.DEPT_Id='" + idepartment.ToString().Trim() + "'";
                
             }
            if (iDesignation!=0)
            {

                    strSQL = strSQL + " AND M.DESIG_Id='" + iDesignation.ToString().Trim() + "'";
                 
            }
            if (iGrade!=0)
            {
                    strSQL = strSQL + " AND M.GRADE_Id='" + iGrade.ToString().Trim() + "'";
            }

            if (iEmployeeType !=0)
            {

                    strSQL = strSQL + " AND M.Employee_Type_Id='" + iEmployeeType.ToString().Trim() + "'";
                 
            }


            if (ibranchId== 0 && idepartment==0 && iDesignation==0 && iGrade ==0 && iEmployeeType!=0)
            {

                    return null;
            }
                //return SQLHelper.ShowRecord(strSQL).DataTableToList<BulkClockingListVO>();
                return BindClassWithData.BindClass<BulkClockingListVO>(SQLHelper.ShowRecord(strSQL)).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region SaveBuklClocking
        public List<Tuple<string, string>> SaveBuklClocking(DateTime BulkLogDt, bool bChkInOrOut, DateTime BulkClockin, DateTime BulkClockOut,
                                        List<BulkClockingListVO> lstBulkClockingListVO,string strReason,
                                        bool bdtpBulkClockinCheckBox, bool bdtpBulkClockOutShowCheckBox )
        {

            int rtn = 0;
            var jcList = new List<Tuple<string, string>>();
            //List<KeyValuePair<string, string>> mylist = new List<KeyValuePair<string, string>>();

            try
            {

                //mylist.Add(new KeyValuePair<string, string>("1233", "sfsdfdF"));

                if (bChkInOrOut == false)
                {
                    if (BulkClockin > BulkClockOut)
                    {

                        if (BulkClockin > BulkClockOut)
                        {

                            // check the selected member list are in night shift

                            var _memList = lstBulkClockingListVO.Select(x=>x.Mem_code).ToList();
                            if (lstBulkClockingListVO == null && lstBulkClockingListVO.Count > 0)
                            {
                              return null;// "Please select employee(s) ...
                            }


                            var _delimitedmemList = lstBulkClockingListVO.Select(x => new Func<string>(() =>
                            {
                                return "'" + x.Mem_code.Trim() + "'";
                            })).Select(t => t.Invoke()).ToArray<string>().Aggregate((a, b) => a + "," + b);



                            if (lstBulkClockingListVO == null && lstBulkClockingListVO.Count > 0)
                            {
                                //check all selected employees are in night shift ... 
                                var nightshmemlist = _shiftBus.getNightShiftMembersList(_delimitedmemList, BulkLogDt);
                                if (nightshmemlist != null && nightshmemlist.Count>0   )
                                {
                                    //check all the selected mem code in the selected mem list ...
                                    bool bValidList = _memList.All(mem_code => nightshmemlist.Contains(mem_code));

                                    if (bValidList == false)
                                    {
                                       
                                        return null; // "All selected employees are not in night shift..."
                                    }
                                }
                                else //nightshmemlist != null
                                {
                                    return null; // "Invalid time ... all selected employees are not in night shift...", "Attendance Monitor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                  
                                }
                            }
                        }//if (dtpBulkClockin.Value > dtpBulkClockOut.Value)




                        // MessageBox.Show("Clockout Time Should Greter than Clockin Time....", "Bulk Clocking", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //return;
                    }
                }

                //if (MessageBox.Show("Are you sure want to Continue..\n\n Continuing this action will Delete all old data of the this date", "WARNING", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel)
                //{
                //    return;
                //}


                //if (string.IsNullOrEmpty(tbreason.Text.Trim()) == true)
                //{
                //    MessageBox.Show("Please provide reason...", "Bulk Clocking", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}


                foreach (BulkClockingListVO items in lstBulkClockingListVO)
                {
                    if (bChkInOrOut == false)
                    {
                        
                        if (items.Sel == true)
                        {
                            strSQL = "SELECT * FROM TRAN_ATTN_MAIN WHERE  ISNULL(MAIN_STATUS,'') <> '' AND LOG_DATE='" + BulkLogDt.ToString("dd/MMM/yyyy") + "' AND MEM_CODE='" + items.Mem_code.ToString().Trim() + "' ";
                            DataTable Xdt = new DataTable();
                            Xdt = SQLHelper.ShowRecord(strSQL);
                            if (Xdt.Rows.Count <= 0)
                            {
                                
                                if (BulkClockin.ToString("HH:mm") == "00:00")
                                {

                                    return null;// Please provide In Time...",  
                                }
                                if (BulkClockOut.ToString("HH:mm") == "00:00")
                                {

                                    return null; //"Please provide Out Time...",
                                }

                                strSQL = "EXEC SP_INSERT_NEW_LOGS_ATTENDENCE_MAIN '" + items.Mem_code.Trim() + "', \n" +
                                "'" + items.Entroll_No.Trim() + "','" + BulkClockin.ToString("HH:mm") + "','" + BulkClockOut.ToString("HH:mm") + "',\n" +
                                "'" + BulkLogDt.ToString("dd/MMM/yyyy") + "',null," + items.Branch_id.ToString() + ",'IN-OUT','" + strReason.Trim() + "','I'";

                                if (SQLHelper.InsertRecord(strSQL) > 0)
                                {
                                    jcList.Add(Tuple.Create(items.Mem_code.Trim(),"P"));
                                   // dgr.Cells["PROCESS"].Value = "Process"; here u put the logic of add processed flag in array tuple
                                }
                            }
                            else
                            {
                                //dgr.Cells["PROCESS"].Value = "Leave/Tour Application";
                            }
                        }

                    }
                    else
                    {
                        if (items.Sel == true)
                        {
                            
                            
                            //if ((bdtpBulkClockinCheckBox == true) && (bdtpBulkClockOutShowCheckBox == true))
                            //{

                            if ((bdtpBulkClockinCheckBox == true) && (bdtpBulkClockOutShowCheckBox == true))
                                {
                                    strSQL = "EXEC SP_UPDATE_ATTENDENCE_MAIN '" + items.Mem_code.ToString().Trim() + "','" + BulkClockin.ToString("HH:mm") + "','" + BulkClockOut.ToString("HH:mm") + "',\n" +
                                        "'" + BulkLogDt.ToString("dd/MMM/yyyy") + "','" + strReason.Trim() + "',0,'','I'";
                                }

                            else if ((bdtpBulkClockinCheckBox == true) && (bdtpBulkClockOutShowCheckBox == false))
                                {
                                    strSQL = "EXEC SP_UPDATE_ATTENDENCE_MAIN '" + items.Mem_code.ToString().Trim() + "','" + BulkClockin.ToString("HH:mm") + "','" + BulkClockOut.ToString("HH:mm") + "',\n" +
                                      "'" + BulkLogDt.ToString("dd/MMM/yyyy") + "','" + strReason.Trim() + "',0,'" +items.Row_Id.Trim() + "','I'";
                                }
                            else if ((bdtpBulkClockinCheckBox == false) && (bdtpBulkClockOutShowCheckBox == true))
                                {

                                    strSQL = "EXEC SP_UPDATE_ATTENDENCE_MAIN '" + items.Mem_code.ToString().Trim() + "','" + items.Clock_In.Trim() + "','" + BulkClockOut.ToString("HH:mm") + "',\n" +
                                      "'" + BulkLogDt.ToString("dd/MMM/yyyy") + "','" + strReason.Trim() + "',0,'" + items.Row_Id.Trim() + "','I'";
                                }
                                //else if ((dtpBulkClockin.Checked == false) && (dtpBulkClockOut.Checked == false))
                                //{
                                //   // MessageBox.Show("Please select Logout or Login...", "Bulk Clocking", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //    return;
                                //}

                            //}

                            if (SQLHelper.InsertRecord(strSQL) > 0)
                            {
                                jcList.Add(Tuple.Create(items.Mem_code.Trim(), "P"));
                                //dgr.Cells["PROCESS"].Value = "Process";
                            }
                            else
                            {
                               // dgr.Cells["PROCESS"].Value = "Failed";
                            }
                           
                        }
                    }
                }
               return jcList;
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        # endregion SaveBuklClocking




    }
}
