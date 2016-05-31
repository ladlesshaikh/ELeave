using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    public class CanteenGroupDAO
    {
       // private dbConnection conn;
        private string strSQL = string.Empty;
        /// <constructor>
        /// Constructor CanteenGroupDAO
        /// </constructor>
        public CanteenGroupDAO()
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

                    strSQL = "SELECT ROW_ID,CANTEEN_GROUP ,ACTIVATE FROM dbo.MASTER_CANTEEN_GROUP";
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
        public List<CanteenGroupVO> LoadDataGridList()
        {
            try
            {
                // strSQL = "SELECT ID,CN_NAME,START_TIME,END_TIME,ISNULL(MAX_ALLOWED_TIME,'') MAX_ALLOWED_TIME,ISNULL(IsPaid,0) IsPaid,ACTIVATE,ISNULL(CAN_GRP_ROW_ID,0) CAN_GRP_ROW_ID FROM dbo.MASTER_CANTEEN";

                strSQL = "SELECT ROW_ID,CANTEEN_GROUP ,ACTIVATE FROM dbo.MASTER_CANTEEN_GROUP";
                return SQLHelper.ShowRecord(strSQL).DataTableToList<CanteenGroupVO>();
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region LoadDataGridBindingList
        public BindingList<CanteenGroupVO> LoadDataGridBindingList()
        {
            try
            {
                // strSQL = "SELECT ID,CN_NAME,START_TIME,END_TIME,ISNULL(MAX_ALLOWED_TIME,'') MAX_ALLOWED_TIME,ISNULL(IsPaid,0) IsPaid,ACTIVATE,ISNULL(CAN_GRP_ROW_ID,0) CAN_GRP_ROW_ID FROM dbo.MASTER_CANTEEN";

                strSQL = "SELECT ROW_ID,CANTEEN_GROUP ,ACTIVATE FROM dbo.MASTER_CANTEEN_GROUP";
                return new BindingList<CanteenGroupVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<CanteenGroupVO>());

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...


    }
}
