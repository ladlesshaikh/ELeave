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
    public class DocumentDAO
    {
       // private dbConnection conn;
        private string strSQL = string.Empty;
        /// <constructor>
        /// Constructor DocumentDAO
        /// </constructor>
        public DocumentDAO()
        {
            //conn = new dbConnection();
        }

        #region IsMedicalDocument
        private int IsMedicalDocument(int iDocID)
        {
            try
            {
                string strRtn = string.Empty;
                strSQL = "  SELECT ISNULL(IS_MEDICAL_TYPE,'') IS_MEDICAL_TYPE FROM MASTER_DOCUMEMT WHERE DOC_Id =" + iDocID.ToString();
                strRtn = SQLHelper.GetSingleValue(strSQL);
                if (strRtn != string.Empty)
                    return Convert.ToInt32(strRtn);
                else
                    return -1; // error
               
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        #endregion GetLoadDataGridDT


        #region GetLoadDataGridDT
        private DataTable GetLoadDataGridDT()
        {
            try
            {
                strSQL =" SELECT [DOC_Id] ,[DOC_NAME],[DOC_DESC],[DOC_CAT_Id],[IS_MEDICAL_TYPE] \n"+
                        "  ,[Activate] FROM MASTER_DOCUMEMT ";
                return (SQLHelper.ShowRecord(strSQL));

               
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion GetLoadDataGridDT
        #region LoadDataGridList
        public List<DocumentVO> LoadDataGridList()
        {
            try
            {

                strSQL = " SELECT [DOC_Id] ,[DOC_NAME],[DOC_DESC],[DOC_CAT_Id],[IS_MEDICAL_TYPE] \n" +
                       "  ,[Activate] FROM MASTER_DOCUMEMT ";
                return BindClassWithData.BindClass<DocumentVO>(SQLHelper.ShowRecord(strSQL)).ToList();
               
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        
        #region LoadDataGridList
        public BindingList<DocumentVO> LoadDataGridBindingList()
        {
            try
            {
               
                strSQL = "  SELECT DM.[DOC_Id] ,DM.[DOC_NAME],DM.[DOC_DESC],DM.[DOC_CAT_Id], DC.DOC_CAT_NAME Document_Cat_Desc,\n" +
                         " IS_MEDICAL_TYPE,CASE WHEN[IS_MEDICAL_TYPE] = 1 THEN 'MEDICAL' ELSE 'OTHERS'  END MEDICAL_TYPE  \n" +
                         " , DM.[Activate] FROM MASTER_DOCUMEMT DM \n" +
                         " INNER JOIN MASTER_DOCUMEMT_CAT DC ON DM.DOC_CAT_Id=DC.DOC_CAT_Id ";

                return new BindingList<DocumentVO>( BindClassWithData.BindClass<DocumentVO>(SQLHelper.ShowRecord(strSQL)).ToList());
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
                    strSQL = "SELECT DOC_NAME FROM MASTER_DOCUMEMT WHERE REPLACE(DOC_NAME,' ','') = REPLACE('" + GroupName + "',' ','') ";
                    if (SQLHelper.ShowRecord(strSQL).Rows.Count == 0)
                        return true;
                    else
                        return false;
                }//if
                else
                {
                    strSQL = "SELECT DOC_Id,DOC_NAME FROM MASTER_DOCUMEMT WHERE REPLACE(DOC_Id,' ','') = REPLACE('" + GroupName + "',' ','') AND DOC_Id='" + strRowId + "' ";
                    dt = SQLHelper.ShowRecord(strSQL);
                    
                    if (dt.Rows.Count > 0)
                    {
                        if (strRowId != dt.Rows[0]["DOC_Id"].ToString().Trim())
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
