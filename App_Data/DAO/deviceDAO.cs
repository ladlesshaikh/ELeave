using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    public class DeviceDAO
    {
       // private dbConnection conn;
        private string strSQL = string.Empty;

        /// <constructor>
        /// Constructor UserDAO
        /// </constructor>
        public DeviceDAO()
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
                    strSQL = "SELECT DV_ID,DEVICE_NAME,DEVICE_LOCATION,DV_IP,PORT,ACTIVATE FROM MASTER_DEVICE";
                    return (SQLHelper.ShowRecord(strSQL));

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion GetLoadDataGridDT
        #region GetDisplayGridDT
        private DataTable GetDisplayGridDT(string strParam)
        {
            try
            {
                using (DataTable dt = new DataTable())
                {
                    strSQL = "SELECT ID ROW_ID,FROM_AMOUNT,TO_AMOUNT,PERCENTAGE,PLUS_AMOUNT FROM MASTER_TAX_DTILS WHERE ROW_ID=" + strParam.Trim();
                    return (SQLHelper.ShowRecord(strSQL));

                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion
        #region LoadDataGridList
        public List<DeviceVO> LoadDataGridList()
        {
            try
            {
                strSQL = "SELECT DV_ID,DEVICE_NAME,DEVICE_LOCATION,DV_IP,PORT,ACTIVATE FROM MASTER_DEVICE";
                return SQLHelper.ShowRecord(strSQL).DataTableToList<DeviceVO>();
               
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region LoadDataGridBindingList
        public BindingList<DeviceVO> LoadDataGridBindingList()
        {
            try
            {
                strSQL = "SELECT DV_ID,DEVICE_NAME,DEVICE_LOCATION,DV_IP,PORT,IsAutoLog,ACTIVATE FROM MASTER_DEVICE";
                return new BindingList<DeviceVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<DeviceVO>());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        
        
    }
}
