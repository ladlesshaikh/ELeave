using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATTNPAY;
using System.Web.Script;
using System.Web.Services;
using ATTNPAY.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft;
using Newtonsoft.Json.Linq;

namespace BizHRMS.Transactions
{
    public partial class AmmentClockByEmp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        

        [WebMethod]
        public static int DeleteDetails(string MainRowId,string RowId)
        {
            try
            {
                AttendanceBUS bus = new AttendanceBUS();
                int ret = bus.DeleteDetails(MainRowId, RowId);
                return ret;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public static List<ComboBoxFill> getEmpLst()
        {
            List<ComboBoxFill> lst = new List<ComboBoxFill>();
            EmployeeBUS _employeeBUS = new EmployeeBUS();
            lst = _employeeBUS.getEmployeeDropDownList(true, "Member_Name");
            return lst;
        }
        [WebMethod]
        public static List<AttnClockAmendmentVO> ShowData(string StartDate, string EndDate, string EmpCode)
        {
            List<AttnClockAmendmentVO> attnAmendmentList = new List<AttnClockAmendmentVO>();
            AttnClockAmendmentBUS _attnClockAmendmentBUS = new AttnClockAmendmentBUS();
            attnAmendmentList = _attnClockAmendmentBUS.getAttnClockAmendmentList(StartDate, EndDate, EmpCode);
            return attnAmendmentList;
        }

        //Checking the NS Status
        [WebMethod]
        public static bool CheckNightShift(string MemCode,string logDate)
        {
            CultureInfo germanCulture = CultureInfo.CreateSpecificCulture("de-DE");
            DateTime workDt = Convert.ToDateTime(logDate);
            Console.WriteLine(workDt.ToString());
            ShiftBUS _shiftBus=new ShiftBUS();
            bool isNightShift = _shiftBus.isNightShiftMembers(MemCode, workDt);
            return isNightShift;
        }
        [WebMethod]
        public static bool SaveEntry(string MemCode,string LogDate,string ClockIn,string ClockOut,string Reason,string RowId,string StrStatus)
        {
            AttnClockAmendmentBUS attnclock = new AttnClockAmendmentBUS();
            bool ret= attnclock.AddNewLog(MemCode, LogDate, ClockIn, ClockOut, Reason, RowId, StrStatus);
            return ret;
        }
        [WebMethod]
        public static void ProcessOT(string pData)
        {
            DataTable dt=new DataTable();
            JArray jData = new JArray();
            JObject jDataObj = new JObject();
            jData = JArray.Parse(pData);
            int i = 0;
            try
            {
                dt.Columns.Add("MEM_CODE",typeof(string));
                dt.Columns.Add("MAIN_STATUS", typeof(string));
                dt.Columns.Add("REJECTED_ATTENDANCE", typeof(byte));
                dt.Columns.Add("PROCESSED", typeof(string));
                dt.Columns.Add("LOG_DATE", typeof(string));
                dt.Columns.Add("IN_TIME", typeof(string));
                dt.Columns.Add("OUT_TIME", typeof(string));
                string MEM_CODE="", MAIN_STATUS="", PROCESSED="", LOG_DATE="", IN_TIME="", OUT_TIME="";
                int REJECTED_ATTENDANCE=0;
                    foreach (JObject content in jData.Children<JObject>())
                    {
                        foreach (JProperty prop in content.Properties())
                        {
                           string tempValue = prop.Name.ToString(); // This is not allowed 
                           if(prop.Name== "empId")
                            {
                                 MEM_CODE = prop.Value.ToString();
                            }
                            if (prop.Name == "MainStatus")
                            {

                                 MAIN_STATUS= prop.Value.ToString();
                            }
                            if (prop.Name == "RejectedAttendance")
                            {
                                if(prop.Value.ToString()=="false")
                                {
                                     REJECTED_ATTENDANCE = 0;
                                }
                                else
                                {
                                     REJECTED_ATTENDANCE = 1;
                                }
                            }
                            if (prop.Name == "PFlag")
                            {
                                 PROCESSED = prop.Value.ToString();
                            }
                            if (prop.Name == "PunchDate")
                            {
                                 LOG_DATE = prop.Value.ToString();
                            }
                            if (prop.Name == "InTime")
                            {
                                 IN_TIME = prop.Value.ToString();
                            }
                            if (prop.Name == "OutTime")
                            {
                                 OUT_TIME = prop.Value.ToString();
                            }
                        }
                        dt.Rows.Add(MEM_CODE,MAIN_STATUS,REJECTED_ATTENDANCE,PROCESSED,LOG_DATE,IN_TIME,OUT_TIME);
                    }
                AttnClockAmendmentBUS bus = new AttnClockAmendmentBUS();
                bus.ProcessAttnLog("SP_CREATE_OVERTIME_TVP", dt);
            }
            catch
            {

            }
        }
    }
  
}