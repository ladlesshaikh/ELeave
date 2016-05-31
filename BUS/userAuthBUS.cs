using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace ATTNPAY.Core
{
    /// <summary>
    /// Summary description for UserBUS
    /// </summary>
    public class userAuthBUS
    {
        private UserDAO _userDAO;

        /// <constructor>
        /// Constructor UserBUS
        /// </constructor>
        public userAuthBUS()
        {
            _userDAO  = new UserDAO();
        }

        #region UserAuth
        public static bool UserAuth(string Form_Name, string Status)
        {
            DataTable AuthDt = new DataTable();

            string str = "SELECT UROLE.Form_Name,Menu_Caption,  \n" +
                          "  ISNULL(IsAdd,0) IsAdd,ISNULL(IsEdit,0) IsEdit,ISNULL(IsInactive,0) IsInactive, \n" +
                          "  ISNULL(IsView,0)IsView FROM MASTER_USER MU INNER JOIN   \n" +
                          "  (SELECT MG.ROLE_ID,MF.Form_Name,MF.Menu_Caption,IsAdd,IsEdit,IsInactive,IsView   \n" +
                          "  FROM MASTER_ROLE MG   \n" +
                          "  INNER JOIN MASTER_FORM MF ON MG.Form_Id = MF.Form_Id )UROLE ON MU.ROLE_ID = UROLE.ROLE_ID \n" +
                          "  WHERE MU.MEM_CODE='" + GlobalVariable.UserCode + "' AND UROLE.Form_Name='" + Form_Name + "' ";

                           AuthDt = SQLHelper.ShowRecord(str);
            if (AuthDt.Rows.Count > 0)
            {
                return Convert.ToBoolean(AuthDt.Rows[0][Status].ToString());
            }
            else
            {
                return false;
            }
        }

        #endregion UserAuth

       
    }
}
