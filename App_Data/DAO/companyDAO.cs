using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    public class CompanyDAO
    {
       // private dbConnection conn;
        string strSQL = string.Empty;


        /// <constructor>
        /// Constructor UserDAO
        /// </constructor>
        public CompanyDAO()
        {
            //conn = new dbConnection();
        }
        //

        #region GetLoadDataGridDT
        private DataTable GetLoadDataGridDT()
        {
            try
            {

                using (DataTable dt = new DataTable())
                {
                    strSQL = "SELECT * FROM MASTER_COMPANY WHERE ACTIVATE='A'";
                    return (SQLHelper.ShowRecord(strSQL));

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion GetLoadDataGridDT


        // 

        #region GetPayHeadData
        public CompanyVO GetPayHeadData(int iCompId)
        {
            try
            {

                strSQL = "SELECT * FROM MASTER_COMPANY WHERE ACTIVATE='A' AND ID=" + iCompId;
                return (SQLHelper.ShowRecord(strSQL).DataTableToList<CompanyVO>()[0]);


            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion GetLoadDataGridDT



        #region GetLoadDataList
        public List<CompanyVO> GetLoadDataList()
        {
            try
            {

                    strSQL = "SELECT * FROM MASTER_COMPANY WHERE ACTIVATE='A'";
                    return (SQLHelper.ShowRecord(strSQL).DataTableToList<CompanyVO>());

               
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion GetLoadDataGridDT
        #region GetLoadDataList
        public BindingList<CompanyVO> LoadDataGridBindingList()
        {
            try
            {

                strSQL = "SELECT * FROM MASTER_COMPANY WHERE ACTIVATE='A'";
                return new BindingList<CompanyVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<CompanyVO>());
              

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion LoadDataGridBindingList()
        //




        #region  GetDropdownDT
        private DataTable GetDropdownDT() //Loading DropdownList
        {
            try
            {

                DataTable dt = new DataTable();
                strSQL = "SELECT EdCodeId,Description FROM MASTER_EARNING_DEDUCTION_CODE_MASTER WHERE Fixed_Variable='V' and IncomeDeduction ='I'";
                dt = SQLHelper.ShowRecord(strSQL);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion 
    }
}
