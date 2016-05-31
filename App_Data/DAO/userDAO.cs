using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    public class UserDAO
    {
       // private dbConnection conn;
        private string strSQL = string.Empty;
        /// <constructor>
        /// Constructor UserDAO
        /// </constructor>
        public UserDAO()
        {
            //conn = new dbConnection();
        }
               

        private DataTable GetDataGridDT()
        {
            try
            {
                DataTable dt = new DataTable();

                strSQL = "SELECT U.ROW_ID,U.USER_NAME,U.MEM_CODE,E.Member_Name, U.Password, \n" +
                " U.PasswordHint,U.ROLE_ID,R.ROLE_NAME,U.Activate FROM MASTER_USER U  \n" +
                " INNER JOIN MASTER_USER_GROUP R ON U.ROLE_ID = R.ROW_ID  \n" +
                " INNER JOIN MASTER_EMPLOYEE_MAIN E ON U.MEM_CODE = E.MEM_CODE WHERE U.Branch_Id=" + GlobalVariable.BarnchCode;
                dt = SQLHelper.ShowRecord(strSQL);
                return (dt);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #region LoadDataGridList
        public List<UserVO> LoadDataGridList()
        {
            try
            {
               
                strSQL = "SELECT U.ROW_ID,U.USER_NAME,U.MEM_CODE,E.Member_Name, U.Password, \n" +
               " U.PasswordHint,U.ROLE_ID,R.ROLE_NAME,U.Activate FROM MASTER_USER U  \n" +
               " INNER JOIN MASTER_USER_GROUP R ON U.ROLE_ID = R.ROW_ID  \n" +
               " INNER JOIN MASTER_EMPLOYEE_MAIN E ON U.MEM_CODE = E.MEM_CODE WHERE U.Branch_Id=" + GlobalVariable.BarnchCode;
                return SQLHelper.ShowRecord(strSQL).DataTableToList<UserVO>();
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region LoadDataGridBindingList
        public BindingList<UserVO> LoadDataGridBindingList()
        {
            try
            {

                strSQL = "SELECT U.ROW_ID,U.USER_NAME,U.MEM_CODE,E.Member_Name, U.Password, \n" +
               " U.PasswordHint,U.ROLE_ID,R.ROLE_NAME,U.Activate FROM MASTER_USER U  \n" +
               " INNER JOIN MASTER_USER_GROUP R ON U.ROLE_ID = R.ROW_ID  \n" +
               " INNER JOIN MASTER_EMPLOYEE_MAIN E ON U.MEM_CODE = E.MEM_CODE WHERE U.Branch_Id=" + GlobalVariable.BarnchCode;
                
                return new BindingList<UserVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<UserVO>());

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
