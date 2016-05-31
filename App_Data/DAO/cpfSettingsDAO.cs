using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.ComponentModel;
using EntityMapper;

namespace ATTNPAY.Core
{
    public class CpfSettingsDAO
    {
       // private dbConnection conn;
        private string strSQL = string.Empty;
        /// <constructor>
        /// Constructor CpfSettingsDAO
        /// </constructor>
        public CpfSettingsDAO()
        {
            //conn = new dbConnection();
        }

       
        #region  CheckData
        private bool CheckData(string GroupName, string strFlag, string strRowId)
        {
            try
            {
                DataTable dt = new DataTable();
                if (strFlag == "A")
                {
                    strSQL = " SELECT [CPF_ID]  FROM [MASTER_CPF_SETTINGS] WHERE REPLACE(CPF_Description,' ','') = REPLACE('" + GroupName + "',' ','') ";
                    if (SQLHelper.ShowRecord(strSQL).Rows.Count == 0)
                        return true;
                    else
                        return false;
                }//if
                else
                {
                    strSQL = " SELECT   [CPF_ID]  FROM [MASTER_CPF_SETTINGS] WHERE REPLACE(CPF_Description,' ','') = REPLACE('" + GroupName + "',' ','') AND CPF_ID='" + strRowId + "' ";
                    dt = SQLHelper.ShowRecord(strSQL);

                    if (dt.Rows.Count > 0)
                    {
                        if (strRowId != dt.Rows[0]["CPF_ID"].ToString().Trim())
                        {
                            //"Duplicate CPF_ID
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

        #region GetLoadDataGridDT
        private DataTable GetLoadDataGridDT()
        {
            try
            {
                using (DataTable dt = new DataTable())
                {
                    strSQL = " SELECT [CPF_ID],[CPFAgeGroupID]";
                     strSQL += ",[CPFSALGROUPID],[PRYearGroup_id],[CPFGRP_MAX]";
                     strSQL += ",[TW_FACTOR],[TW_DFACTOR],[OWFACTOR],[AWFACTOR],[ACTIVATE] FROM ";
                    strSQL += " [MASTER_CPF_SETTINGS_DTLS] where Activate='A'";
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
        public List<CPFSettingsVO> LoadDataGridList()
        {
            try
            {
                //strSQL = " SELECT [CPF_ID],[CPFAgeGroupID],[CpfGroup_Id] ";
                //strSQL += ",[CPFSALGROUPID],[PRYearGroup_id],[CPFGRP_MAX]";
                //strSQL += ",[TW_FACTOR],[TW_DFACTOR],[OWFACTOR],[AWFACTOR],[ACTIVATE]";

                strSQL = " SELECT ISNULL([CPF_ID],0) CPF_ID, ISNULL([CPFAgeGroupID],-1) CPFAgeGroupID ";
                strSQL += " , ISNULL([CPFSALGROUPID],-1) CPFSALGROUPID , ISNULL([PRYearGroup_id],-1) PRYearGroup_id , ISNULL([CPFTOT_SHARE_MAX],0) CPFTOT_SHARE_MAX ";
                strSQL += " ,ISNULL( [CPFTOT_SHARE],'') CPFTOT_SHARE , ISNULL( [CPF_EMP_SHARE_MAX],0) CPF_EMP_SHARE_MAX ,ISNULL([CPF_EMP_SHARE],'') CPF_EMP_SHARE ,[ACTIVATE] FROM [MASTER_CPF_SETTINGS_DTLS] ";
                strSQL += " WHERE AND  Activate='A'";
               
                return BindClassWithData.BindClass<CPFSettingsVO>(SQLHelper.ShowRecord(strSQL)).ToList();  
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region LoadDataGridList
        public List<CPFSettingsVO> LoadDataGridList(int ConfigId)
        {
            try

            {
      
                strSQL = " SELECT ISNULL([CPF_ID],0) CPF_ID, ISNULL([CPFAgeGroupID],-1) CPFAgeGroupID ";
                strSQL += " , ISNULL([CPFSALGROUPID],-1) CPFSALGROUPID , ISNULL([PRYearGroup_id],-1) PRYearGroup_id , ISNULL([CPFTOT_SHARE_MAX],0) CPFTOT_SHARE_MAX ";
                strSQL += " ,ISNULL( [CPFTOT_SHARE],'') CPFTOT_SHARE , ISNULL( [CPF_EMP_SHARE_MAX],0) CPF_EMP_SHARE_MAX ,ISNULL([CPF_EMP_SHARE],'') CPF_EMP_SHARE ,[ACTIVATE] FROM [MASTER_CPF_SETTINGS_DTLS] ";
                strSQL += " WHERE [CPF_CONFIG_ID]=" + ConfigId.ToString() + " AND  Activate='A'";
                return BindClassWithData.BindClass<CPFSettingsVO>(SQLHelper.ShowRecord(strSQL)).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region LoadDataGridBindingList
        public BindingList<CPFSettingsVO> LoadDataGridBindingList()
        {
            try
            {

                strSQL = " SELECT ISNULL([CPF_ID],0) CPF_ID, ISNULL([CPFAgeGroupID],-1) CPFAgeGroupID ";
                strSQL += " , ISNULL([CPFSALGROUPID],-1) CPFSALGROUPID , ISNULL([PRYearGroup_id],-1) PRYearGroup_id , ISNULL([CPFTOT_SHARE_MAX],0) CPFTOT_SHARE_MAX ";
                strSQL += " ,ISNULL( [CPFTOT_SHARE],'') CPFTOT_SHARE , ISNULL( [CPF_EMP_SHARE_MAX],0) CPF_EMP_SHARE_MAX ,ISNULL([CPF_EMP_SHARE],'') CPF_EMP_SHARE ,[ACTIVATE] FROM [MASTER_CPF_SETTINGS_DTLS] ";
                strSQL += " WHERE Activate='A'";
         
                //strSQL = " SELECT [CPF_ID],[CPFAgeGroupID],[CpfGroup_Id] ";
                //strSQL += ",[CPFSALGROUPID],[PRYearGroup_id],[CPFGRP_MAX]";
                //strSQL += ",[TW_FACTOR],[TW_DFACTOR],[OWFACTOR],[AWFACTOR],[ACTIVATE] ";
                //strSQL += " FROM [MASTER_CPF_SETTINGS_DTLS]  where activate='A'";
                
                return new BindingList<CPFSettingsVO>(BindClassWithData.BindClass<CPFSettingsVO>(SQLHelper.ShowRecord(strSQL)));  
       
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        
    }
}
