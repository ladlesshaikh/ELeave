using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    public class MasterFpBackupDAO
    {
       // private dbConnection conn;
        private string strSQL = string.Empty;

        /// <constructor>
        /// Constructor UserDAO
        /// </constructor>
        public MasterFpBackupDAO()
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

                    strSQL = "SELECT [ID],[MacID],[DEVICE_LOCATION] LocationName,[BackupNo],[Backup_Mode] BackupMode,";
                    strSQL += "[Fp_Total] fpTotal ,[Face_Total] faceTotal,[Card_Total] cardTotal,[BackupDate],[Add_By] Uid FROM [MASTER_FPBACKUP]";
                    strSQL += " WHERE BackupNo=" + strParam.Trim();
                    return (SQLHelper.ShowRecord(strSQL));

                 
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion
        //GetBackUpItem(strBackUpNo);

        #region GetBackUpItem
        public MasterFpBackupVO GetBackUpItem(string strBckNo)
        {
            try
            {
                if (string.Empty != strBckNo.Trim())
                {
                    strSQL = " SELECT [ID],[MacID] ,[DEVICE_LOCATION] LocationName,[BackupNo],[Backup_Mode] BackupMode,";
                    strSQL += " [Fp_Total] fpTotal ,[Face_Total] faceTotal,[Card_Total] cardTotal,[BackupDate],[Add_By] Uid FROM [MASTER_FPBACKUP] ";
                    strSQL += " Where [BackupNo]='" + strBckNo.Trim()+"'";
                    //....
                    return SQLHelper.ShowRecord(strSQL).DataTableToList<MasterFpBackupVO>()[0];
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...


        #region LoadDataGridList
        public List<MasterFpBackupVO> LoadDataGridList()
        {
            try
            {
                strSQL = "SELECT [ID],[MacID] ,[DEVICE_LOCATION] LocationName,[BackupNo],[Backup_Mode] BackupMode,";
                strSQL += "[Fp_Total] fpTotal ,[Face_Total] faceTotal,[Card_Total] cardTotal,[BackupDate],[Add_By] Uid FROM [MASTER_FPBACKUP]";
                return SQLHelper.ShowRecord(strSQL).DataTableToList<MasterFpBackupVO>();
               
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region LoadDataGridBindingList
        public BindingList<MasterFpBackupVO> LoadDataGridBindingList()
        {
            try
            {
                strSQL = "SELECT [ID],[MacID] ,[DEVICE_LOCATION] LocationName,[BackupNo],[Backup_Mode] BackupMode,";
                strSQL += "[Fp_Total] fpTotal ,[Face_Total] faceTotal,[Card_Total] cardTotal,[BackupDate],[Add_By] Uid FROM [MASTER_FPBACKUP]";
                return new BindingList<MasterFpBackupVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<MasterFpBackupVO>());
            }
                

            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        //GetLastBackupNo
        #region GetLastBackupNo
        public string  GetLastBackupNo(string bkmode)
        {
            try
            {
                strSQL = "  SELECT ISNULL(MASER_FPBACKUP.BackupNo,'') from MASER_FPBACKUP " +
                          " WHERE ID=( SELECT ISNULL(MAX(ID),0) from MASER_FPBACKUP WHERE Backup_Mode='" +bkmode.Trim()+"')";
                return (SQLHelper.GetSingleValue(strSQL));
 
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion GetLastBackupNo


    }
}
