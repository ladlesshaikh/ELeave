using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    public class ProjectGroupDAO
    {
       // private dbConnection conn;
        private string strSQL = string.Empty;
        /// <constructor>
        /// Constructor ProjectGroupDAO
        /// </constructor>
        public ProjectGroupDAO()
        {
            //conn = new dbConnection();
        }

        #region GetLoadDataGridDT
        private DataTable GetLoadDataGridDT()
        {
            try
            {

                using (DataTable dt = new DataTable())
                {

                    strSQL = "SELECT SHIFT_GROUP_ID,SHIFT_GROUP_NAME,ACTIVATE FROM dbo.MASTER_SHIFT_GROUP";
          
                    return (SQLHelper.ShowRecord(strSQL));

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion GetLoadDataGridDT
        #region LoadDataGridList
        public List<ShiftGroupVO> LoadDataGridList()
        {
            try
            {

                strSQL = "SELECT SHIFT_GROUP_ID,SHIFT_GROUP_NAME,ACTIVATE FROM dbo.MASTER_SHIFT_GROUP";
                return SQLHelper.ShowRecord(strSQL).DataTableToList<ShiftGroupVO>();
                //return SQLHelper.ShowRecord(strSQL).ToList<DepartmentVO>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        // #region LoadDataGridBindingList
        //public BindingList<BankVO> LoadDataGridBindingList()
        #region LoadDataGridList
        public BindingList<ShiftGroupVO> LoadDataGridBindingList()
        {
            try
            {

                strSQL = "SELECT SHIFT_GROUP_ID,SHIFT_GROUP_NAME,ACTIVATE FROM dbo.MASTER_SHIFT_GROUP";
                return new BindingList<ShiftGroupVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<ShiftGroupVO>());
               
                //return SQLHelper.ShowRecord(strSQL).ToList<DepartmentVO>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...


        #region  CheckData
        private bool CheckData(string GroupName, string strFlag, string strRowId)
        {
            try
            {
                DataTable dt = new DataTable();
                if (strFlag == "A")
                {


                    strSQL = "SELECT SHIFT_GROUP_NAME FROM MASTER_SHIFT_GROUP WHERE REPLACE(SHIFT_GROUP_NAME,' ','') = REPLACE('" + GroupName + "',' ','') ";
                    if (SQLHelper.ShowRecord(strSQL).Rows.Count == 0)
                        return true;
                    else
                        return false;
                }//if
                else
                {
                    strSQL = "SELECT [SHIFT_GROUP_ID],SHIFT_GROUP_NAME FROM MASTER_SHIFT_GROUP WHERE REPLACE(SHIFT_GROUP_NAME,' ','') = REPLACE('" + GroupName + "',' ','') AND SHIFT_GROUP_ID='" + strRowId + "' ";
                    dt = SQLHelper.ShowRecord(strSQL);
                    
                    if (dt.Rows.Count > 0)
                    {
                        if (strRowId != dt.Rows[0]["ID"].ToString().Trim())
                        {
                            //"Duplicate Department ...
                            return false;
                        }
                        else
                            return true;
                    }
                    else
                        return true;
                }//else
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion 

    }
}
