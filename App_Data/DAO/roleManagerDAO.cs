using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    public class RoleManagerDAO
    {
       // private dbConnection conn;
        string strSQL = string.Empty;

        /// <constructor>
        /// Constructor UserDAO
        /// </constructor>
        public RoleManagerDAO()
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
                    strSQL = "SELECT ID,Bank_Name,IFSC,MICR,Branch,Address,Activate FROM MASTER_BANK";
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
                    strSQL = "SELECT ID,Bank_Name,IFSC,MICR,Branch,Address,Activate FROM MASTER_BANK";
                    return (new List<DataRow>(SQLHelper.ShowRecord(strSQL).Select()));
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region LoadList
        public List<RoleManagerVO> LoadList()
        {
            try
            {
                

                {

                    strSQL = " SELECT UROLE.ROLE_ID RoleID,Form_Id,UROLE.Form_Name Form_Name ,Menu_Caption,Menu_Name, ";
                    strSQL += " ISNULL(IsAdd,0) IsAdd,ISNULL(IsEdit,0) IsEdit,ISNULL(IsInactive,0) IsInactive, ";
                    strSQL += " ISNULL(IsView,0)IsView FROM MASTER_USER MU INNER JOIN ";
                    strSQL += " (SELECT MG.ROLE_ID,MF.Form_Id Form_Id  ,MF.Form_Name,MF.Menu_Caption,Menu_Name,IsAdd,IsEdit,IsInactive,IsView,MG.Activate ";
                    strSQL += " FROM MASTER_ROLE MG ";
                    strSQL += " INNER JOIN MASTER_FORM MF ON MG.Form_Id = MF.Form_Id WHERE MG.Activate='A' AND MF.Activate='A') UROLE ON MU.ROLE_ID = UROLE.ROLE_ID  ";
                    return SQLHelper.ShowRecord(strSQL).DataTableToList<RoleManagerVO>();
                 
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region LoadBindingList
        public BindingList<RoleManagerVO> LoadBindingList()
        {
            try
            {
                {
                    strSQL =    " SELECT UROLE.ROLE_ID,Form_Id,UROLE.Form_Name,Menu_Caption,Menu_Name, ";
                    strSQL +=   " ISNULL(IsAdd,0) IsAdd,ISNULL(IsEdit,0) IsEdit,ISNULL(IsInactive,0) IsInactive, ";
                    strSQL +=   " ISNULL(IsView,0)IsView FROM MASTER_USER MU INNER JOIN ";
                    strSQL +=   " (SELECT MG.ROLE_ID,MF.Form_Id Form_Id  ,MF.Form_Name,MF.Menu_Caption,Menu_Name,IsAdd,IsEdit,IsInactive,IsView,MG.Activate ";  
                    strSQL +=   " FROM MASTER_ROLE MG ";  
                    strSQL +=   " INNER JOIN MASTER_FORM MF ON MG.Form_Id = MF.Form_Id WHERE MG.Activate='A' AND MF.Activate='A') UROLE ON MU.ROLE_ID = UROLE.ROLE_ID  ";

                //--WHERE MU.MEM_CODE='0100001' AND UROLE.ROLE_ID=(SELECT MASTER_USER.ROLE_ID FROM MASTER_USER
                // --WHERE  MEM_CODE='0100001')                        
                //                --AND UROLE.Form_Name='" + Form_Name + "' ";
                    
              
                return new BindingList<RoleManagerVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<RoleManagerVO>());
                    

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
