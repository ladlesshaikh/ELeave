using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    public class OvertimeTDAO
    {
       // private dbConnection conn;
        private string strSQL = string.Empty;
        /// <constructor>
        /// Constructor UserDAO
        /// </constructor>
        public OvertimeTDAO()
        {
            //conn = new dbConnection();
        }

        #region LoadDataGridDT
        private DataTable LoadDataGridDT()
        {
            try
            {
                using (DataTable dt = new DataTable())
                {
                 
                   strSQL = "SELECT ID,OT_Desc,OT_Fraction,ACTIVATE FROM MASTER_OVERTIME";
    
                    return SQLHelper.ShowRecord(strSQL);
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region LoadDataGridList
        public List<OvertimeVO> LoadDataGridList()
        {
            try
            {
                

                {
                    strSQL = "SELECT ID,OT_Desc,OT_Fraction,ACTIVATE FROM MASTER_OVERTIME";
                    return SQLHelper.ShowRecord(strSQL).DataTableToList<OvertimeVO>();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region LoadDataGridBindingList
        public BindingList<OvertimeVO> LoadDataGridBindingList()
        {
            try
            {


                {
                    strSQL = "SELECT ID,OT_Desc,OT_Fraction,ACTIVATE FROM MASTER_OVERTIME";
                   return new BindingList<OvertimeVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<OvertimeVO>());
                }
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
                    strSQL = "SELECT OT_Desc FROM MASTER_OVERTIME WHERE REPLACE(OT_Desc,' ','') = REPLACE('" + GroupName + "',' ','') ";
                    if (SQLHelper.ShowRecord(strSQL).Rows.Count == 0)
                        return true;
                    else
                        return false;
                }//if
                else
                {
                    strSQL = "SELECT ID,OT_Desc FROM MASTER_OVERTIME WHERE REPLACE(OT_Desc,' ','') = REPLACE('" + GroupName + "',' ','') AND ID='" + strRowId + "' ";
                    dt = SQLHelper.ShowRecord(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        if (strRowId != dt.Rows[0]["MEM_CODE"].ToString().Trim())
                        {
                            //Duplicate Employee Enrollment No
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
