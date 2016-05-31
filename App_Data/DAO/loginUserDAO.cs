using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Linq;

namespace ATTNPAY.Core
{
    public class LoginUserDAO
    {
        // private dbConnection conn;
        private string strSQL = string.Empty;
        /// <constructor>
        /// Constructor LoginUserDAO
        /// </constructor>
        public LoginUserDAO()
        {
            //conn = new dbConnection();
        }


        private DataTable GetDataGridDT(string strBranchCode)
        {
            try
            {
                DataTable dt = new DataTable();

                strSQL = "SELECT U.ROW_ID,U.USER_NAME,U.MEM_CODE,E.Member_Name, U.Password, \n" +
                " U.PasswordHint,U.ROLE_ID,R.ROLE_NAME,U.Activate FROM MASTER_USER U  \n" +
                " INNER JOIN MASTER_USER_GROUP R ON U.ROLE_ID = R.ROW_ID  \n" +
                " INNER JOIN MASTER_EMPLOYEE_MAIN E ON U.MEM_CODE = E.MEM_CODE WHERE U.Branch_Id=" + strBranchCode; // GlobalVariable.BarnchCode;
                dt = SQLHelper.ShowRecord(strSQL);
                return (dt);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #region LoadDataGridList
        public List<LoginUserVO> LoadDataGridList(string strBranchCode)
        {
            try
            {


                strSQL = "SELECT U.ROW_ID,U.USER_NAME,U.MEM_CODE,E.Member_Name, U.Password, \n" +
               " U.PasswordHint,U.ROLE_ID,R.ROLE_NAME,U.Activate FROM MASTER_USER U  \n" +
               " INNER JOIN MASTER_USER_GROUP R ON U.ROLE_ID = R.ROW_ID  \n" +
               " INNER JOIN MASTER_EMPLOYEE_MAIN E ON U.MEM_CODE = E.MEM_CODE WHERE U.Branch_Id=" + strBranchCode;

                return SQLHelper.ShowRecord(strSQL).DataTableToList<LoginUserVO>();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region GetAdminUser
        public LoginUserVO GetAdminUser(string strBranchCode)
        {
            try
            {

                strSQL = "SELECT U.ROW_ID,U.USER_NAME,U.MEM_CODE,E.Member_Name, U.Password, \n" +
                " U.PasswordHint,U.ROLE_ID,R.ROLE_NAME,U.Activate FROM MASTER_USER U  \n" +
                " INNER JOIN MASTER_USER_GROUP R ON U.ROLE_ID = R.ROW_ID  \n" +
                " INNER JOIN MASTER_EMPLOYEE_MAIN E ON U.MEM_CODE = E.MEM_CODE WHERE U.Branch_Id=" + strBranchCode + "\n" +
                " AND UPPER(R.ROLE_NAME)='ADMIN'";
                return SQLHelper.ShowRecord(strSQL).DataTableToList<LoginUserVO>().FirstOrDefault();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region LoadDataGridBindingList
        public BindingList<LoginUserVO> LoadDataGridBindingList(string strBranchCode)
        {
            try
            {


                strSQL = "SELECT U.ROW_ID,U.USER_NAME,U.MEM_CODE,E.Member_Name, U.Password, \n" +
               " U.PasswordHint,U.ROLE_ID,R.ROLE_NAME,U.Activate FROM MASTER_USER U  \n" +
               " INNER JOIN MASTER_USER_GROUP R ON U.ROLE_ID = R.ROW_ID  \n" +
               " INNER JOIN MASTER_EMPLOYEE_MAIN E ON U.MEM_CODE = E.MEM_CODE WHERE U.Branch_Id=" + strBranchCode;

                //return SQLHelper.ShowRecord(strSQL).DataTableToList<LoginUserVO>();
                return new BindingList<LoginUserVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<LoginUserVO>());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        private DataTable GetDropdownDT() //Loading DropdownList
        {
            try
            {
                DataTable dt = new DataTable();
                strSQL = "SELECT ROW_ID,ROLE_NAME FROM MASTER_USER_GROUP";
                dt = SQLHelper.ShowRecord(strSQL);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }

        }




    }
}
