using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    public class ResidenceStatusDAO
    {
       // private dbConnection conn;
        private string strSQL = string.Empty;
        /// <constructor>
        /// Constructor ResidenceStatusDAO
        /// </constructor>
        public ResidenceStatusDAO()
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

                    strSQL = "SELECT ResidenceStatusId,ResidenceStatusName ,ACTIVATE FROM MASTER_Residence_Status";
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
        public List<ResidenceStatusVO> LoadDataGridList()
        {
            try
            {
                // strSQL = "SELECT ID,CN_NAME,START_TIME,END_TIME,ISNULL(MAX_ALLOWED_TIME,'') MAX_ALLOWED_TIME,ISNULL(IsPaid,0) IsPaid,ACTIVATE,ISNULL(CAN_GRP_ROW_ID,0) CAN_GRP_ROW_ID FROM dbo.MASTER_CANTEEN";

                strSQL = "SELECT ResidenceStatusId,ResidenceStatusName ,ACTIVATE FROM MASTER_Residence_Status";
                return SQLHelper.ShowRecord(strSQL).DataTableToList<ResidenceStatusVO>();
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region LoadDataGridBindingList
        public BindingList<ResidenceStatusVO> LoadDataGridBindingList()
        {
            try
            {
                // strSQL = "SELECT ID,CN_NAME,START_TIME,END_TIME,ISNULL(MAX_ALLOWED_TIME,'') MAX_ALLOWED_TIME,ISNULL(IsPaid,0) IsPaid,ACTIVATE,ISNULL(CAN_GRP_ROW_ID,0) CAN_GRP_ROW_ID FROM dbo.MASTER_CANTEEN";

                strSQL = "SELECT ResidenceStatusId,ResidenceStatusName ,ACTIVATE FROM MASTER_Residence_Status";
                return new BindingList<ResidenceStatusVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<ResidenceStatusVO>());

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...


    }
}
