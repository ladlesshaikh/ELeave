using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using ATTNPAY;
using ATTNPAY.Core;
namespace BizHRMS
{
    public partial class AmmendClock : System.Web.UI.Page
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
                //Dr["MEM_CODE"] = "";
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            string strSQL;
            DataTable dtData;
            //if (cbEmployee.SelectedIndex == 0)
            if (ddlEmployee.Value.Trim() == string.Empty)

            {
                dgvDisplyaSaveData.DataSource = null;
                return;
            }
                 var empCode = string.Empty;
                empCode = ddlEmployee.Items.FindByValue(ddlEmployee.Value).Text.Trim().IndexOf("-", 0) > 0 ? ddlEmployee.Items.FindByValue(ddlEmployee.Value).Text.Trim().Substring(0, ddlEmployee.Items.FindByValue(ddlEmployee.Value).Text.Trim().IndexOf("-")) : ddlEmployee.Items.FindByValue(ddlEmployee.Value).Text.Trim();
                strSQL = "EXEC SP_DATEWISE_AMEND_REPORT_EMPLOYEE '" + txtStartDate.Value + "','" + txtEndDate.Value+ "','" + empCode + "'"; // cbEmployee.Text.Trim().Substring(0, cbEmployee.Text.Trim().IndexOf("-")) + "'";
                dtData = new DataTable();
                dtData = SQLHelper.ShowRecord(strSQL);
                if (dtData == null)
                {
                    dgvDisplyaSaveData.DataSource = null;

                }

                if (dtData != null && dtData.Rows.Count == 0)
                {
                    dgvDisplyaSaveData.DataSource = null;
                }
                var UniqueRows = dtData.AsEnumerable().Distinct(DataRowComparer.Default);
                DataTable dt2 = UniqueRows.CopyToDataTable();
                DataView Dv = dt2.DefaultView;
            //dgvDisplyaSaveData.DataSource = dt;
           // dgvDisplyaSaveData.DataBind();
        }
    }
}