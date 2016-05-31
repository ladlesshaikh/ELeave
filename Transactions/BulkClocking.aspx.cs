using ATTNPAY;
using ATTNPAY.Core;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BizHRMS.Transactions
{
    public partial class BulkClocking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //Get the Employee
        #region Get Employee Details
        [WebMethod]
        public static List<BulkClockingListVO> WM_GetEmpList(string logDate, int Branch, int Dept, int Desig, int EType, int Grade,string iInsertNewClock,int shiftType)
        {
            bool newClock;
            try
            {
                BulkClockingListBUS bus = new BulkClockingListBUS();
                if(iInsertNewClock=="0")
                {
                    newClock = false;
                }
                else
                {
                    newClock = true;
                }
                List<BulkClockingListVO> lst = new List<BulkClockingListVO>();
                lst=bus.LoadEmployeeList(newClock, logDate, shiftType, Branch, Dept, Desig, Grade, EType);
                return lst;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Process Bulk Clock Details
        [WebMethod]
        public static List<Tuple<string, string>> WM_ProcessDetails(String LogDate,string CheckInOut,string CheckIn,string CheckOut,string pData,string Reason,string IsClockIn,string IsClockOut)
        {
            JArray jData = new JArray();
            JObject jDataObj = new JObject();
            jData = JArray.Parse(pData);
            List<BulkClockingListVO> lstVO = new List<BulkClockingListVO>();
            string Edit_ClockIn="00:00:00";
            string Edit_ClockOut = "00:00:00";
            DateTime BulkClockin, BulkClockOut;
            try
            {
                DateTime BulkLogDt= DateTime.ParseExact(LogDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                bool bChkInOrOut= Convert.ToBoolean(Convert.ToInt32(CheckInOut));
                string strReason = Reason;
                bool bdtpBulkClockinCheckBox = Convert.ToBoolean(Convert.ToInt32(IsClockIn));
                bool bdtpBulkClockOutShowCheckBox = Convert.ToBoolean(Convert.ToInt32(IsClockOut));
                var objResponse1 = Newtonsoft.Json.JsonConvert.DeserializeObject<List<BulkClockingListVO>>(pData);
                if(bChkInOrOut==false)
                {
                    if (bdtpBulkClockinCheckBox == false)
                    {
                        BulkClockin = DateTime.ParseExact(CheckIn, "HH:mm", CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        BulkClockin = DateTime.ParseExact(Edit_ClockIn, "HH:mm:ss", CultureInfo.InvariantCulture);
                    }
                    if (bdtpBulkClockOutShowCheckBox == false)
                    {
                        BulkClockOut = DateTime.ParseExact(CheckOut, "HH:mm", CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        BulkClockOut = DateTime.ParseExact(Edit_ClockOut, "HH:mm:ss", CultureInfo.InvariantCulture);
                    }
                }
                else
                {
                    if (bdtpBulkClockinCheckBox == false)
                    {
                        BulkClockin = DateTime.ParseExact(CheckIn, "HH:mm", CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        if(CheckIn=="")
                        {
                            BulkClockin = DateTime.ParseExact(CheckIn, "HH:mm", CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            BulkClockin = DateTime.ParseExact(CheckIn, "HH:mm", CultureInfo.InvariantCulture);
                        }
                    }
                    if (bdtpBulkClockOutShowCheckBox == false)
                    {
                        BulkClockOut = DateTime.ParseExact(CheckOut, "HH:mm", CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        if(CheckOut=="")
                        {
                            BulkClockOut = DateTime.ParseExact(CheckOut, "HH:mm", CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            BulkClockOut = DateTime.ParseExact(CheckOut, "HH:mm", CultureInfo.InvariantCulture);
                        }
                    }
                }
              
                BulkClockingListBUS bus = new BulkClockingListBUS();
                var jcList = new List<Tuple<string, string>>();
      
                jcList= bus.SaveBuklClocking(BulkLogDt, bChkInOrOut, BulkClockin, BulkClockOut, objResponse1, strReason, bdtpBulkClockinCheckBox, bdtpBulkClockOutShowCheckBox);
                return jcList;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        #endregion





        [WebMethod]
        public static List<ComboBoxFill> WM_LoadBranch()
        {
            try
            {
                List<ComboBoxFill> lst = new List<ComboBoxFill>();
                EmployeeBUS Bus = new EmployeeBUS();
                lst = Bus.getBranch(true, "Branch_Name");
                return lst;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public static List<ComboBoxFill> WM_LoadGrade()
        {
            try
            {
                List<ComboBoxFill> lst = new List<ComboBoxFill>();
                EmployeeBUS Bus = new EmployeeBUS();
                lst = Bus.getGradeLst(true, "GRADE_Name");
                return lst;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public static List<ComboBoxFill> WM_LoadDesignation()
        {
            try
            {
                List<ComboBoxFill> lst = new List<ComboBoxFill>();
                EmployeeBUS Bus = new EmployeeBUS();
                lst = Bus.getDesignation(true, "DESIGNATION");
                return lst;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public static List<ComboBoxFill> WM_LoadDepartment()
        {
            try
            {
                List<ComboBoxFill> lst = new List<ComboBoxFill>();
                EmployeeBUS Bus = new EmployeeBUS();
                lst = Bus.getDepartment(true, "DEPARTMENT_Name");
                return lst;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public static List<ComboBoxFill> WM_LoadShiftType()
        {
            try
            {
                List<ComboBoxFill> lst = new List<ComboBoxFill>();
                EmployeeBUS Bus = new EmployeeBUS();
                lst = Bus.getShiftType(true, "SHIFT_NAME");
                return lst;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public static List<ComboBoxFill> WM_LoadEmployeeType()
        {
            try
            {
                List<ComboBoxFill> lst = new List<ComboBoxFill>();
                EmployeeBUS Bus = new EmployeeBUS();
                lst = Bus.getEmpType(true, "Employee_Type");
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}