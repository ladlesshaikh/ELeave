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
    public class DocumentCategoryDAO
    {
       // private dbConnection conn;
        private string strSQL = string.Empty;
        /// <constructor>
        /// Constructor DocumentCategoryDAO
        /// </constructor>
        public DocumentCategoryDAO()
        {
            //conn = new dbConnection();
        }

        #region GetLoadDataGridDT
        private DataTable GetLoadDataGridDT()
        {
            try
            {
                    strSQL = "SELECT DOC_CAT_Id,DOC_CAT_NAME,ACTIVATE FROM dbo.MASTER_DOCUMEMT_CAT";
                    return (SQLHelper.ShowRecord(strSQL));

               
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion GetLoadDataGridDT
        #region LoadDataGridList
        public List<DocumentCategoryVO> LoadDataGridList()
        {
            try
            {

                strSQL = "SELECT DOC_CAT_Id,DOC_CAT_NAME,ACTIVATE FROM dbo.MASTER_DOCUMEMT_CAT";
                // return SQLHelper.ShowRecord(strSQL).DataTableToList<DocumentCategoryVO>();
                return BindClassWithData.BindClass<DocumentCategoryVO>(SQLHelper.ShowRecord(strSQL)).ToList();
               
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        
        #region LoadDataGridList
        public BindingList<DocumentCategoryVO> LoadDataGridBindingList()
        {
            try
            {

                strSQL = "SELECT DOC_CAT_Id,DOC_CAT_NAME,ACTIVATE FROM dbo.MASTER_DOCUMEMT_CAT";
               // return new BindingList<DocumentCategoryVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<DocumentCategoryVO>());
                return new BindingList< DocumentCategoryVO >( BindClassWithData.BindClass<DocumentCategoryVO>(SQLHelper.ShowRecord(strSQL)).ToList());
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
                    strSQL = "SELECT DOC_CAT_NAME FROM MASTER_DOCUMEMT_CAT WHERE REPLACE(DOC_CAT_NAME,' ','') = REPLACE('" + GroupName + "',' ','') ";
                    if (SQLHelper.ShowRecord(strSQL).Rows.Count == 0)
                        return true;
                    else
                        return false;
                }//if
                else
                {
                    strSQL = "SELECT DOC_CAT_Id,DOC_CAT_NAME FROM MASTER_DOCUMEMT_CAT WHERE REPLACE(DOC_CAT_Id,' ','') = REPLACE('" + GroupName + "',' ','') AND DOC_CAT_Id='" + strRowId + "' ";
                    dt = SQLHelper.ShowRecord(strSQL);
                    
                    if (dt.Rows.Count > 0)
                    {
                        if (strRowId != dt.Rows[0]["DOC_CAT_Id"].ToString().Trim())
                        {
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
