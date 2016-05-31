using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using EntityMapper;
using System.Linq;

namespace ATTNPAY.Core
{
    public class EmailCCDetlsDAO
    {
       // private dbConnection conn;
        private string strSQL = string.Empty;
        /// <constructor>
        /// EmailCCDetlsDAO
        /// </constructor>
        public EmailCCDetlsDAO()
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
                    strSQL = "SELECT [ROW_ID],[MEM_CODE],[EMAILCC_GROUP_ID],Activate FROM MASTER_EMAIL_CC_DTLS";
                    return SQLHelper.ShowRecord(strSQL);
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region LoadDataGridList
        public List<EmailCCDetlsVO > LoadDataGridList()
        {
            try
            {

                strSQL = "SELECT [ROW_ID],[MEM_CODE],[EMAILCC_GROUP_ID],Activate FROM MASTER_EMAIL_CC_DTLS";
                return SQLHelper.ShowRecord(strSQL).DataTableToList<EmailCCDetlsVO>();
               

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region LoadDataGridBindingList
        public BindingList<EmailCCDetlsVO> LoadDataGridBindingList(int? emailGroupId )
        {
            try
            {


                strSQL = "  SELECT ISNULL(convert(varchar(38), A.ROW_ID), '')  ROW_ID ,A.[MEM_CODE] ,A.[EMAILCC_GROUP_ID], \n " +
                        "   A.Activate,B.Member_Name , B.EmailAddress ,'F' ISMODIFIED,C.EMAILCC_GROUP_NAME FROM MASTER_EMAIL_CC_DTLS A \n" +
                        "   INNER JOIN MASTER_EMPLOYEE_MAIN B ON A.MEM_CODE = B.MEM_CODE \n" +
                         "  INNER JOIN  MASTER_EMAILCC_GROUP C ON A.EMAILCC_GROUP_ID = C.EMAILCC_GROUP_ID";
                
                strSQL += emailGroupId.HasValue ? emailGroupId.Value!=0? " WHERE A.EMAILCC_GROUP_ID = " + emailGroupId.Value.ToString() : " " :"";
                return new BindingList<EmailCCDetlsVO>(BindClassWithData.BindClass<EmailCCDetlsVO>(SQLHelper.ShowRecord(strSQL)));  

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region getEmailCCList
        /// <method>
        /// Get getEmailCCMemberList
        /// </method>

        public List<string> LoadDataCCList(string strMemCode, string orderBy)
        {

            try
            {
                //strSQL = " SELECT ISNULL(EmailAddress, '') EmailAddress \n" +
                //          " FROM MASTER_EMPLOYEE_MAIN WHERE  MEM_CODE = (SELECT top 1 ISNULL(RO_MEM_CODE, '') \n" +
                //          "  MEM_CODE FROM dbo.MASTER_RO_DTLS WHERE MEM_CODE = '" + strMemCode.Trim() + "' and ro_mem_code not in ('" + ApprMemCode.Trim() + "') )";



                strSQL = "  SELECT B.Member_Name , B.EmailAddress EmailAddress, A.Activate FROM MASTER_EMAIL_CC_DTLS A \n" +
                         "  INNER JOIN MASTER_EMPLOYEE_MAIN B ON A.MEM_CODE = B.MEM_CODE \n" +
                         "  WHERE Activate = 'A' ";

                if (!string.IsNullOrEmpty(orderBy))
                    strSQL += " Order by A." + orderBy.Trim();

                return SQLHelper.ShowRecord(strSQL).AsEnumerable()
                          .Select(r => r.Field<string>("EmailAddress"))
                          .ToList();
                //return (SQLHelper.ShowRecord(strSQL).DataTableToList<string>();

            }
            catch (Exception ex)
            {
                return null;
            }






           
        }
        #endregion





        #region LoadDataGridBindingList
        public DataTable LoadDataGridList(string strmemCode, string orderBy)
        {
            try
            {

                strSQL = "  SELECT B.Member_Name code, B.EmailAddress Name, A.Activate FROM MASTER_EMAIL_CC_DTLS A \n" +
                         "  INNER JOIN MASTER_EMPLOYEE_MAIN B ON A.MEM_CODE = B.MEM_CODE \n" +
                         "  WHERE Activate = 'A' ";

                if (!string.IsNullOrEmpty(orderBy))
                    strSQL += " Order by A." +  orderBy.Trim();
                return (SQLHelper.ShowRecord(strSQL));

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
                    strSQL = "SELECT EMAILCC_GROUP_NAME FROM MASTER_EMAILCC_GROUP WHERE REPLACE(EMAILCC_GROUP_NAME,' ','') = REPLACE('" + GroupName + "',' ','') ";
                          //  " SELECT [ROW_ID],[MEM_CODE],[EMAILCC_GROUP_ID],Activate "

                    if (SQLHelper.ShowRecord(strSQL).Rows.Count == 0)
                        return true;
                    else
                        return false;
                }//if
                else
                {
                    strSQL = "SELECT EMAILCC_GROUP_ID, EMAILCC_GROUP_NAME FROM MASTER_EMAILCC_GROUP WHERE REPLACE(Relationship_Name,' ','') = REPLACE('" + GroupName + "',' ','') AND EMAILCC_GROUP_ID='" + strRowId + "' ";
                    dt = SQLHelper.ShowRecord(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        if (strRowId != dt.Rows[0]["EMAILCC_GROUP_ID"].ToString().Trim())
                        {
                            //Duplicate Relation Type
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
