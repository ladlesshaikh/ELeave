using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATTNPAY;

namespace BizHRMS.UserControls
{
    public partial class Navigation : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Account_Name.InnerHtml = "Welcome, " + GlobalVariable.UserName;
            string roleId = GlobalVariable.RoleId;
            if(roleId=="2")
            {
                ul_Menu.Style.Add("display", "none");
                ul2.Style.Add("display", "");
                li_Logout.InnerHtml = "<a href='../../Login.aspx'>Logout</a>";
            }
            else
            {
                ul2.Style.Add("display", "none");
            }
        }
    }
}