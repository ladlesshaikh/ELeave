using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    public class CanteenDAO
    {
       // private dbConnection conn;
        private string strSQL = string.Empty;
        /// <constructor>
        /// Constructor CanteenDAO
        /// </constructor>
        public CanteenDAO()
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
                    strSQL = "SELECT ID,CN_NAME Shift_Name,START_TIME,END_TIME,ISNULL(MAX_ALLOWED_TIME,'00:00') MAX_ALLOWED_TIME,ISNULL(IsPaid,0) IsPaid,ACTIVATE,ISNULL(CAN_GRP_ROW_ID,0) CAN_GRP_ROW_ID FROM dbo.MASTER_CANTEEN";
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
        public List<CanteenVO> LoadDataGridList()
        {
            try
            {
                   // strSQL = "SELECT ID,CN_NAME,START_TIME,END_TIME,ISNULL(MAX_ALLOWED_TIME,'') MAX_ALLOWED_TIME,ISNULL(IsPaid,0) IsPaid,ACTIVATE,ISNULL(CAN_GRP_ROW_ID,0) CAN_GRP_ROW_ID FROM dbo.MASTER_CANTEEN";
                   
                    strSQL = "  SELECT ID,CN_NAME, CONVERT(VARCHAR(8),START_TIME)START_TIME,CONVERT(VARCHAR(8),END_TIME)END_TIME ," ;
                    strSQL += " ISNULL(CONVERT(VARCHAR(8),MAX_ALLOWED_TIME),'00:00') MAX_ALLOWED_TIME,ISNULL(IsPaid,0) IsPaid,ACTIVATE,ISNULL(CAN_GRP_ROW_ID,0) CAN_GRP_ROW_ID FROM dbo.MASTER_CANTEEN ";
                    return SQLHelper.ShowRecord(strSQL).DataTableToList<CanteenVO>();
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region LoadDataGridBindingList
        public BindingList<CanteenVO> LoadDataGridBindingList()
        {
            try
            {
                // strSQL = "SELECT ID,CN_NAME,START_TIME,END_TIME,ISNULL(MAX_ALLOWED_TIME,'') MAX_ALLOWED_TIME,ISNULL(IsPaid,0) IsPaid,ACTIVATE,ISNULL(CAN_GRP_ROW_ID,0) CAN_GRP_ROW_ID FROM dbo.MASTER_CANTEEN";
                

                
				 strSQL = " SELECT ID,CN_NAME, CONVERT(VARCHAR(5),START_TIME,108) START_TIME,CONVERT(VARCHAR(5),END_TIME,108)END_TIME , ";
                 strSQL += "  ISNULL(CONVERT(VARCHAR(5),MAX_ALLOWED_TIME,108),'00:00') MAX_ALLOWED_TIME,ISNULL(IsPaid,0) IsPaid,ACTIVATE,ISNULL(CAN_GRP_ROW_ID,0) CAN_GRP_ROW_ID FROM dbo.MASTER_CANTEEN ";
			

                //strSQL = "  SELECT ID,CN_NAME, CONVERT(VARCHAR(8),START_TIME)START_TIME,CONVERT(VARCHAR(8),END_TIME)END_TIME ,";
               // strSQL += " ISNULL(CONVERT(VARCHAR(8),MAX_ALLOWED_TIME),'00:00') MAX_ALLOWED_TIME,ISNULL(IsPaid,0) IsPaid,ACTIVATE,ISNULL(CAN_GRP_ROW_ID,0) CAN_GRP_ROW_ID FROM dbo.MASTER_CANTEEN ";
               
                return new BindingList<CanteenVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<CanteenVO>());

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...


    }
}
