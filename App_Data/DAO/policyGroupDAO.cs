using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    public class PolicyGroupDAO
    {
       // private dbConnection conn;
        string strSQL = string.Empty;

        /// <constructor>
        /// Constructor UserDAO
        /// </constructor>
        public PolicyGroupDAO()
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


                    strSQL = "SELECT GROUP_ID,GROUP_NAME,WEF_DATE,Re_Evaluate,IsDefault,Activate FROM MASTER_POLICY_GROUP";
                    return SQLHelper.ShowRecord(strSQL);
                }
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region LoadDataGridDR
        private List<DataRow> LoadDataGridDR()
        {
            try
            {
                //if (HdrProfileDet[p]["PROF_COD_1"] 

                using (DataTable dt = new DataTable())
                {
                    strSQL = "SELECT GROUP_ID,GROUP_NAME,WEF_DATE,Re_Evaluate,IsDefault,Activate FROM MASTER_POLICY_GROUP";
                    return (new List<DataRow>(SQLHelper.ShowRecord(strSQL).Select()));
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region LoadDataGridList
        public List<PolicyGroupVO> LoadDataGridList()
        {
            try
            {
                

                {
                    strSQL = "SELECT GROUP_ID,GROUP_NAME,WEF_DATE,Re_Evaluate,IsDefault,Activate FROM MASTER_POLICY_GROUP";
                    return SQLHelper.ShowRecord(strSQL).DataTableToList<PolicyGroupVO>();
                   
                    

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region LoadDataGridBindingList
        public BindingList<PolicyGroupVO> LoadDataGridBindingList()
        {
            try
            {


                {
                    strSQL = "SELECT GROUP_ID,GROUP_NAME,WEF_DATE,Re_Evaluate ReEvaluate,IsDefault,Activate FROM MASTER_POLICY_GROUP";

                    return new BindingList<PolicyGroupVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<PolicyGroupVO>());
                    

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...




    }
}
