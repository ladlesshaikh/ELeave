using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATTNPAY;
namespace BizHRMS.UserControls
{
    public partial class Header : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtLoginDetails.InnerHtml = "<span style='font-size:17px;color:#000; margin-right:10px;' class='mif-user'></span>" + GlobalVariable.UserName + " @ " + DateTime.Now;
        }
    }
}