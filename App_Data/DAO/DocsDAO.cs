using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    public class DocsDAO
    {
        public bool SaveDocsDAO(DocsVO docs)
        {
            //Parameters
            string user_id = docs.USER_ID;
            string application_id = docs.APPLICATION_ID;
            string file_path = docs.FILE_PATH;
            string extension = docs.FILE_EXTENSION;
            int active = docs.FILE_IS_ACTIVE;
            int file_type = docs.FILE_TYPE;
            string remarks = docs.REMARKS;
            string file_name = docs.FILE_NAME;
            string fin_year = docs.FIN_YEAR;
            string strQuery="";

            //strQuery += "insert into TRAN_DOCS(USER_ID,APPLICATION_ID,FILE_NAME,FILE_EXTENSION,FILE_IS_ACTIVE,FILE_TYPE,REMARKS,FILE_PATH)";
            //strQuery += "values('" + user_id + "','" + application_id + "','" + file_name + "','" + extension + "'," + active + "," + file_type + ",'" + remarks + "','" + file_path + "')";

            strQuery += "insert into TRANS_DOCS(MEM_CODE,APPLICATION_ID,FILE_NAME,FILE_EXTENSION,Activate,FILE_TYPE,REMARKS,FILE_PATH,Add_By,Add_date,FinYear)";
            strQuery += "values('" + user_id + "','" + application_id + "','" + file_name + "','" + extension + "','" + active + "'," + file_type + ",'" + remarks + "','" + file_path + "','" + user_id + "', GETDATE(),'" + fin_year + "')";


            return (SQLHelper.ExecuteQuery(strQuery));
        }

        #region GetLoadDataList
        public List<DocsVO> GetDocLst(string app_id)
        {
            try
            {

                string strSQL = "select * from TRANS_DOCS WHERE APPLICATION_ID='" + app_id + "' and Activate=1";
                return (SQLHelper.ShowRecord(strSQL).DataTableToList<DocsVO>());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion GetLoadDataGridDT


        #region DeleteDocs
        public bool DeleteDoc(string doc_id)
        {
            try
            {

                string strSQL = "update TRANS_DOCS set Activate=0 where DOCS_ID = " + doc_id;
                return (SQLHelper.ExecuteQuery(strSQL));
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion GetLoadDataGridDT
    }
}
