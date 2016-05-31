using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATTNPAY;
using System.Web.Script;
using System.Web.Services;
using ATTNPAY.Core;
namespace BizHRMS

{
    public partial class AmmendClockByEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadDropDown();
        }
        private void LoadDropDown()
        {
            string strSQL;
            DataTable dtData;
            try
            {
                strSQL = "SELECT MEM_CODE,Member_Name FROM MASTER_EMPLOYEE_MAIN WHERE EMP_STATUS='A' ORDER BY MEM_CODE";
                strSQL = " SELECT Convert(nvarchar(50),MEM_CODE)+'-'+Convert(nvarchar(50),Member_Name) CODE,  MEM_CODE,Member_Name FROM MASTER_EMPLOYEE_MAIN WHERE EMP_STATUS='A' ORDER BY MEM_CODE";
                dtData = new DataTable();
                dtData = SQLHelper.ShowRecord(strSQL);
                DataRow Dr = dtData.NewRow();
                Dr["CODE"] = "";
                Dr["Member_Name"] = "Select";
                dtData.Rows.InsertAt(Dr, 0);
                if (dtData.Rows.Count > 0)
                {
                    ddlEmployee.DataSource = dtData;
                    ddlEmployee.DataTextField = "CODE";
                    ddlEmployee.DataValueField = "Member_Name";
                    ddlEmployee.DataBind();

                }
            }
            catch (Exception ex)
            {
            }
        }

        [WebMethod]
        public static List<AttnClockAmendmentVO> ShowData(string StartDate, string EndDate, string EmpName)
        {
            string strSQL;
            DataTable dtData;

            List<AttnClockAmendmentVO> attnAmendmentList = new List<AttnClockAmendmentVO>();
            AttnClockAmendmentBUS _attnClockAmendmentBUS = new AttnClockAmendmentBUS();
            var empCode = EmpName.Trim().IndexOf("-", 0) > 0 ? EmpName.Trim().Substring(0, EmpName.Trim().IndexOf("-")) : EmpName.Trim();
            attnAmendmentList = _attnClockAmendmentBUS.getAttnClockAmendmentList(StartDate, EndDate, empCode);


            //string strSQL;
            //DataTable dtData;
            //List<clsAmmendClock> emp = new List<clsAmmendClock>();
            //var empCode = string.Empty;
            //empCode = EmpName.Trim().IndexOf("-", 0) > 0 ? EmpName.Trim().Substring(0, EmpName.Trim().IndexOf("-")) : EmpName.Trim();
            //strSQL = "EXEC SP_DATEWISE_AMEND_REPORT_EMPLOYEE '" + StartDate + "','" + EndDate + "','" + empCode + "'";
            //dtData = new DataTable();
            //dtData = SQLHelper.ShowRecord(strSQL);

            //emp = (from DataRow row in dtData.Rows

            //       select new clsAmmendClock
            //       {
            //           Date = row["LOG_DATE"].ToString(),
            //           Day = row["DAY_NAME"].ToString(),
            //           Status = row["MAIN_STATUS"].ToString(),
            //           shift = row["SHIFT_NAME"].ToString(),
            //           OTP = row["IS_OFF_DAY"].ToString(),
            //           In = row["IN_TIME"].ToString(),
            //           Out = row["OUT_TIME"].ToString(),
            //           TotHours = row["TOTAL_HOUR_WORKED"].ToString(),
            //           Worked = row["WORKED_HOUR"].ToString(),
            //           ShiftHour = row["SHIFT_HOUR"].ToString(),
            //           Break = row["MAX_ALLOWED_BREAK_TIME"].ToString(),
            //           OTH = row["OT1"].ToString(),
            //           OT1 = row["OT2"].ToString(),
            //           OT2 = row["OT3"].ToString(),
            //           LastHour = row["LOST_HOUR"].ToString(),
            //           NT = row["NT"].ToString(),
            //           ActualIn = row["ACTUAL_IN_TIME"].ToString(),
            //           ActualOut = row["ACTUAL_OUT_TIME"].ToString(),
            //           Reason = row["Reason"].ToString(),
            //           dtl_row_id = row["DTL_ROW_ID"].ToString()
            //       }).ToList();

            return attnAmendmentList;
        }

        //[WebMethod]
        //public static string UpdateData(string Mode, string MemCode, string PunchDate, string ClockIn, string ClockOut, string RowId)
        //{
        //    String strSQL;
        //    DataTable dtData;
        //    ShiftBUS _shiftBus = new ShiftBUS();
        //    if (Mode == "U")
        //    {
        //        strSQL = "SELECT MEM_CODE FROM TRAN_ATTNENDANCE_FINAL_LOG WHERE MEM_CODE='" + MemCode.Trim() + "' \n" +
        //                " AND PUNCH_DATE='" + PunchDate.ToString("dd/MMM/yyyy") + "' AND CLOKIN_TIME='" + ClockIn.Trim() + "' \n" +
        //                " and ROW_ID <> '" + RowId + "'";
        //        dtData = new DataTable();
        //        dtData = SQLHelper.ShowRecord(strSQL);
        //        if (dtData.Rows.Count > 0)
        //        {

        //            return ("Employee Clocking Already Present For the date and time. Please change the time..");
        //        }
        //        strSQL = "SELECT MEM_CODE FROM TRAN_ATTNENDANCE_FINAL_LOG WHERE MEM_CODE='" + MemCode.Trim() + "' \n" +
        //           " AND PUNCH_DATE='" + PunchDate.ToString("dd/MMM/yyyy") + "' AND CLOKIN_TIME='" + ClockIn.Trim() + "' \n" +
        //           " and ROW_ID <> '" + RowId + "'";
        //        dtData = new DataTable();
        //        dtData = SQLHelper.ShowRecord(strSQL);
        //        if (dtData.Rows.Count > 0)
        //        {
        //            return ("Employee Clocking Already Present For the date. Please change the time..");
        //        }
        //    }
        //    if ((ClockIn != "00:00") && ClockOut != "00:00")
        //    {
        //        if (cl.Value >= dtpManualClockOut.Value)
        //        {

        //            bool isNightShift = _shiftBus.isNightShiftMembers(tbMemberCode.Text.Trim(), dtpLogdate.Value);
        //            if (isNightShift == false)
        //            {
        //            }
        //        }
        //    }
        //}



        //private void btnAddNewLog_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        if (Falg == "Update")
        //        {
        //            strSQL = "SELECT MEM_CODE FROM TRAN_ATTNENDANCE_FINAL_LOG WHERE MEM_CODE='" + tbMemberCode.Text.Trim() + "' \n" +
        //                " AND PUNCH_DATE='" + dtpLogdate.Value.ToString("dd/MMM/yyyy") + "' AND CLOKIN_TIME='" + dtpManualClockin.Text.Trim() + "' \n" +
        //                " and ROW_ID <> '" + strRowId + "'";
        //            dtData = new DataTable();
        //            dtData = SQLHelper.ShowRecord(strSQL);
        //            if (dtData.Rows.Count > 0)
        //            {

        //                MessageBox.Show("Employee Clocking Already Present For the date and time. Please change the time..");
        //                return;
        //            }
        //            strSQL = "SELECT MEM_CODE FROM TRAN_ATTNENDANCE_FINAL_LOG WHERE MEM_CODE='" + tbMemberCode.Text.Trim() + "' \n" +
        //               " AND PUNCH_DATE='" + dtpLogdate.Value.ToString("dd/MMM/yyyy") + "' AND CLOKIN_TIME='" + dtpManualClockOut.Text.Trim() + "' \n" +
        //               " and ROW_ID <> '" + strRowId + "'";
        //            dtData = new DataTable();
        //            dtData = SQLHelper.ShowRecord(strSQL);
        //            if (dtData.Rows.Count > 0)
        //            {
        //                MessageBox.Show("Employee Clocking Already Present For the date. Please change the time..", "Clocking Amendment", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                return;
        //            }
        //        }

        //        if ((dtpManualClockin.Value.ToString("HH:mm") != "00:00") && dtpManualClockOut.Value.ToString("HH:mm") != "00:00")
        //        {
        //            if (dtpManualClockin.Value >= dtpManualClockOut.Value)
        //            {

        //                bool isNightShift = _shiftBus.isNightShiftMembers(tbMemberCode.Text.Trim(), dtpLogdate.Value);
        //                if (isNightShift == false)
        //                {

        //                    MessageBox.Show("Clockout time should be greater than Clockin time.", "Attendance Monitor", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    return;
        //                }

        //                //MessageBox.Show("Clockin time should not be greater than or Equal to Clockout time.");
        //                //return;
        //            }
        //        }

        //        if (string.IsNullOrEmpty(tbAddLogReason.Text.Trim()) == true)
        //        {
        //            MessageBox.Show("Please provide reason...", "Clocking Amendment", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            return;
        //        }
        //        if (Falg == "Insert")
        //        {
        //            strSQL = "SELECT ENROLL_NO,Branch_ID FROM MASTER_EMPLOYEE_MAIN WHERE MEM_CODE='" + tbMemberCode.Text.Trim() + "'";
        //            dtData = new DataTable();
        //            dtData = SQLHelper.ShowRecord(strSQL);

        //            strSQL = "EXEC SP_INSERT_NEW_LOGS_ATTENDENCE_MAIN '" + tbMemberCode.Text.Trim() + "', \n" +
        //            "'" + dtData.Rows[0]["ENROLL_NO"].ToString() + "','" + dtpManualClockin.Value.ToString("HH:mm") + "','" + dtpManualClockOut.Value.ToString("HH:mm") + "',\n" +
        //            "'" + dtpLogdate.Value.ToString("yyyy-MM-dd") + "',null," + dtData.Rows[0]["Branch_ID"].ToString() + ",'IN-OUT','" + tbAddLogReason.Text.Trim() + "','I'";
        //            // MessageBox.Show(dtData.Rows[0]["ENROLL_NO"].ToString() +dtpLogdate.Value.ToString("yyyy-MM-dd") +"/"+dtpManualClockin.Value.ToString("HH:mm") + "/" + dtpManualClockOut.Value.ToString("HH:mm"));
        //        }
        //        else if (Falg == "Update")
        //        {
        //            if (lblStatus.Text.Trim() == "IN-OUT")
        //            {
        //                strSQL = "EXEC SP_UPDATE_ATTENDENCE_MAIN '" + tbMemberCode.Text.Trim() + "','" + dtpManualClockin.Text.Trim() + "','" + dtpManualClockOut.Text.Trim() + "',\n" +
        //                  "'" + dtpLogdate.Value.ToString("dd/MMM/yyyy") + "','" + tbAddLogReason.Text.Trim() + "',0,'" + strRowId + "','I'";
        //            }
        //        }


        //        if (SQLHelper.InsertRecord(strSQL) > 0)
        //        {
        //            MessageBox.Show("Data updated Successfully....", "Clocking Amendment", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            tbMemberCode.Text = "";
        //            tbMemberName.Text = "";
        //            dtpManualClockOut.Text = "00:00";
        //            dtpManualClockin.Text = "00:00";
        //            tbAddLogReason.Text = "";
        //            btnShow_Click(null, null);
        //        }
        //        else
        //        {
        //            MessageBox.Show("Data updation failed....", "Clocking Amendment", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }

        //        pnlAdd.Visible = false;
        //        dgvDisplyaSaveData.Enabled = true;
        //        pnlMainView.Enabled = true;
        //        pnlAdd.Top = 198;
        //        pnlAdd.Left = 71;
        //        pnlAdd.SendToBack();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Exception occured ..." + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {

        //    }
        //}

    }
    public class clsAmmendClock
    {
        public string Date;
        public string Day;
        public string Status;
        public string shift;
        public string ShiftHour;
        public string ActualIn;
        public string ActualOut;
        public string In;
        public string Out;
        public string TotHours;
        public string Break;
        public string Worked;
        public string NT;
        public string OTH;
        public string OT1;
        public string OT2;
        public string LastHour;
        public string OTP;
        public string Reason;
        public string dtl_row_id;
    }
}