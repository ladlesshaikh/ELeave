using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;

using System.ComponentModel;
using System.Drawing;
using System.Text;

using System.Security.Cryptography;
using ATTNPAY;
using ATTNPAY.Core;

namespace BizHRMS
{
    public partial class Login : System.Web.UI.Page
    {
        private EDSecurity _decryptObj = new EDSecurity();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Binding the Branch Drop down
            DataTable brnch = new DataTable();
            brnch = SQLHelper.ShowRecord("SELECT Branch_ID,Branch_Name FROM MASTER_BRANCH");
            ddlBranch.DataSource = brnch;
            ddlBranch.DataValueField = "Branch_ID";
            ddlBranch.DataTextField = "Branch_Name";
            ddlBranch.DataBind();
            //Binding the Month Drop down
            String SQL = " SELECT MONTH_NAME + '-'  + CONVERT(VARCHAR(4), Year(YD.MONTH_START_DATE)) MONTH_NAME,MONTH_NO FROM MASTER_YEAR_MAIN YM \n" +
                    " INNER JOIN MASTER_YEAR_DTLS YD ON YM.MAIN_ID = YD.MAIN_ID \n" +
                    " WHERE YD.ACTIVATE='A' AND YM.Activate='A' AND ISNULL(YM.CurrentYear,0)=1";
            DataTable Xdt = new DataTable();
            Xdt = SQLHelper.ShowRecord(SQL);
            ddlMonth.DataSource = Xdt;
            ddlMonth.DataTextField = "MONTH_NAME";
            ddlMonth.DataValueField = "MONTH_NO";
            ddlMonth.DataBind();
            //Selecting the Current Month
            SQL = "SELECT TOP 1 MONTH_NO,MONTH_NAME FROM MASTER_YEAR_MAIN YM \n" +
                     " INNER JOIN MASTER_YEAR_DTLS YD ON YM.MAIN_ID = YD.MAIN_ID \n" +
                     " WHERE YM.Activate='A' AND YD.ACTIVATE='A' AND  \n" +
                     " ISNULL(YD.MONTH_NO,0)=" + DateTime.Now.Month.ToString() + " AND \n " +
                     " ISNULL(YM.CurrentYear,0)=1 AND ISNULL(YD.MonthEnd,0)=0";
            Xdt = new DataTable();
            Xdt = SQLHelper.ShowRecord(SQL);
            if (Xdt.Rows.Count > 0)
            {
                ListItem li = ddlMonth.Items.FindByValue(Xdt.Rows[0]["MONTH_NO"].ToString().Trim());
                li.Selected = true;
            }
            //Fetching Financial Year
            SQL = "SELECT FINANCIAL_YEAR FROM MASTER_YEAR_MAIN YM where YM.Activate='A' AND ISNULL(YM.CurrentYear,0)=1";
            Xdt = new DataTable();
            Xdt = SQLHelper.ShowRecord(SQL);
            if (Xdt.Rows.Count > 0)
            {
                Div_Fin_Year.InnerHtml = "Financial Year - " + Xdt.Rows[0]["FINANCIAL_YEAR"].ToString().Trim();
            }
        }
        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            string strRtn = string.Empty;
            String SQL;
            DataTable DT = new DataTable();
            Div_Alert_Box.Style.Add("display", "none");
            try
            {
                #region Check Client Server Date
                Int32 ClientDate, ServerDate;
                ClientDate = Convert.ToInt32(System.DateTime.Now.Date.ToString("yyyyMMdd"));
                SQL = "SELECT Convert(VARCHAR(8),GETDATE(),112) ServerDt";
                DT = new DataTable();
                strRtn = SQLHelper.GetSingleValue(SQL);
                if (!string.IsNullOrEmpty(strRtn))
                {
                    ServerDate = Convert.ToInt32(strRtn);
                }
                else
                {
                    ServerDate = 0;
                }
                #endregion


                if (txtUsername.Value.Trim() == string.Empty || txtPassword.Value.Trim() == string.Empty)
                {
                    Div_Alert_Box.Style.Add("display", "block");
                    Div_Alert_Box.InnerHtml = "Please Enter Username & Password";
                    return;

                }
                if (txtUsername.Value.Trim() != string.Empty || txtPassword.Value.Trim() != string.Empty)
                {
                    // Div_Alert_Box.Style.Add("display", "block");
                    // Div_Alert_Box.InnerHtml = "Please Enter Username & Password";
                    // return;

                    if (DT.Rows.Count > 0)
                    {
                        if (!_decryptObj.Decrypt(DT.Rows[0]["Password"].ToString().Trim()).Equals(txtPassword.Value.Trim()))
                        {
                            Div_Alert_Box.Style.Add("display", "block");
                            Div_Alert_Box.InnerHtml = "Invalid User ID/Password!";
                            return;
                        }
                    }
                    DT = new DataTable();
                    SQL = "SELECT U.ROLE_ID,G.ROLE_NAME,U.MEM_CODE,U.[User_Name],M.Member_Name ,U.Password Collate Latin1_General_CS_AI Password,  \n" +
                           " U.IsSuperUser,ISNULL(IsSuperUser,0) IsSupperuser \n" +
                           " FROM MASTER_USER U   \n" +
                            "inner join MASTER_EMPLOYEE_MAIN M ON U.MEM_CODE = M.MEM_CODE INNER JOIN MASTER_USER_GROUP G ON  U.ROLE_ID = G.ROW_ID \n" +
                           " WHERE U.Activate='A' AND U.[User_Name]=@uid AND U.Branch_Id=@br";

                    DT = SQLHelper.LoginCheck(SQL, txtUsername.Value.Trim().Replace("'", "''").ToString(), ddlBranch.Value.ToString());
                    if (DT.Rows.Count > 0)
                    {
                        if (string.Compare(_decryptObj.Decrypt(DT.Rows[0]["Password"].ToString().Trim()), txtPassword.Value.Trim()) != 0)
                        {
                            Div_Alert_Box.Style.Add("display", "block");
                            Div_Alert_Box.InnerHtml = "Invalid Password!";
                        }
                        Div_Red_Succ.Style.Add("display", "block");
                        Div_Red_Succ.InnerHtml = "Successfully Redirecting..";
                        SQL = "SELECT ID,Company_Name,Address +' '+ Country + ', '+ State + ',  ZIP:'+ ZIP Address,email,Contact FROM MASTER_COMPANY WHERE Activate='A'";
                        DataTable CompDt = new DataTable();
                        CompDt = SQLHelper.ShowRecord(SQL);
                        if (CompDt.Rows.Count > 0)
                        {
                            GlobalVariable.CompanyCode = CompDt.Rows[0]["ID"].ToString();
                            GlobalVariable.CompanyName = CompDt.Rows[0]["Company_Name"].ToString();
                            GlobalVariable.CompanyAddress = CompDt.Rows[0]["Address"].ToString();
                            GlobalVariable.CompanyEmail = CompDt.Rows[0]["email"].ToString();
                            GlobalVariable.CompanyPhone = CompDt.Rows[0]["Contact"].ToString();

                        }
                        GlobalVariable.RoleId = DT.Rows[0]["ROLE_ID"].ToString().Trim();
                        GlobalVariable.RoleName = DT.Rows[0]["ROLE_NAME"].ToString().Trim();

                        GlobalVariable.UserCode = DT.Rows[0]["MEM_CODE"].ToString();
                        GlobalVariable.UserName = DT.Rows[0]["Member_Name"].ToString();
                        GlobalVariable.BranchName = ddlBranch.Items.FindByValue(ddlBranch.Value).Text;

                        GlobalVariable.BarnchCode = ddlBranch.Value.ToString(); //cbBranch.SelectedValue.ToString()

                        string FinYear = Div_Fin_Year.InnerHtml.Split('-')[1].ToString();
                        GlobalVariable.FinanCialYear = FinYear.Replace(" ", "");
                        GlobalVariable.Month = ddlMonth.Value;

                        SQL = " SELECT M.MAIN_ID,CONVERT(VARCHAR(12),START_DATE,106) START_DATE,CONVERT(VARCHAR(12),END_DATE,106) END_DATE \n" +
                             " FROM MASTER_YEAR_DTLS D INNER JOIN MASTER_YEAR_MAIN M ON D.MAIN_ID = M.MAIN_ID \n" +
                             " WHERE MONTH_NO=" + GlobalVariable.Month + " AND D.ACTIVATE='A'  \n" +
                             " AND M.Activate='A' AND ISNULL(M.CurrentYear,0)=1";
                        DataTable xt = new DataTable();
                        xt = SQLHelper.ShowRecord(SQL);
                        if (xt.Rows.Count > 0)
                        {
                            GlobalVariable.YearID = xt.Rows[0]["MAIN_ID"].ToString().Trim();
                            GlobalVariable.YearStartDate = xt.Rows[0]["START_DATE"].ToString().Trim();
                            GlobalVariable.YearEndDate = xt.Rows[0]["END_DATE"].ToString().Trim();
                        }
                        GlobalVariable.Year = ddlMonth.Items.FindByValue(ddlMonth.Value).Text.Substring(ddlMonth.Items.FindByValue(ddlMonth.Value).Text.Length - 4, 4).Trim();

                        SQL = "SELECT MONTH_START_DATE,MONTH_END_DATE,CONVERT(VARCHAR(12),MONTH_START_DATE,106) D_MONTH_START_DATE,CONVERT(VARCHAR(12),MONTH_END_DATE,106) D_MONTH_END_DATE FROM MASTER_YEAR_DTLS  \n" +
                            " WHERE ACTIVATE='A' AND MONTH_NO=" + GlobalVariable.Month + " AND MAIN_ID=" + GlobalVariable.YearID;
                        xt = new DataTable();
                        xt = SQLHelper.ShowRecord(SQL);
                        if (xt.Rows.Count > 0)
                        {
                            GlobalVariable.StartDate = xt.Rows[0]["MONTH_START_DATE"].ToString().Trim();
                            GlobalVariable.EndDate = xt.Rows[0]["MONTH_END_DATE"].ToString().Trim();
                            GlobalVariable.MonStartDate = xt.Rows[0]["D_MONTH_START_DATE"].ToString().Trim();
                            GlobalVariable.MonEndDate = xt.Rows[0]["D_MONTH_END_DATE"].ToString().Trim();
                        }
                        string role = GlobalVariable.RoleId;
                        if (role == "2")
                        {
                            // Response.Redirect("Transactions/ApplyLeave.aspx");
                            string branchCode = GlobalVariable.BarnchCode;
                            LeaveApplicationBUS LAB = new LeaveApplicationBUS();
                            List<LeaveApplicationVO> lstLeaveApp = new List<LeaveApplicationVO>();
                            lstLeaveApp = LAB.getLeaveApplicationListByRO(GlobalVariable.UserCode, branchCode);
                            //if (lstLeaveApp.Count == 0)
                            //{
                            //    Response.Redirect("Transactions/Leave/ApplyLeave.aspx");
                            //}

                            Response.Redirect("Transactions/LeaveRequest.aspx");
                        }

                        else
                        {
                            Response.Redirect("Transactions/Home.aspx");
                        }
                    }
                    else
                    {
                        Div_Alert_Box.Style.Add("display", "block");
                        Div_Alert_Box.InnerHtml = "Invalid Password!";
                        return;
                    }
                }
            }

            catch
            {

            }
        }
    }
}
        
    
