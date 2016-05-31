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
    public partial class AmmenTClockByDate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
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
            catch(Exception ex)
            {
                throw ex;
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
                throw ex;
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
                throw ex;
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
                throw ex;
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
                throw ex;
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

        //Get the Binding data.
        [WebMethod]
        public static List<AttnClockAmendmentVO> WM_GetGridData(string CurrDate, string Branch, string Dept, string Desig, string EType, string Grade)
        {
            List<AttnClockAmendmentVO> attnAmendmentList = new List<AttnClockAmendmentVO>();
            AttnClockAmendmentBUS _attnClockAmendmentBUS = new AttnClockAmendmentBUS();
            attnAmendmentList= _attnClockAmendmentBUS.getAttnClockAmendmentListDate(CurrDate, Branch, Dept, Desig, EType, Grade);
            return attnAmendmentList;
        }


    }
}