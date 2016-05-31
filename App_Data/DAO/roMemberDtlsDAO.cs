using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Linq;
using EntityMapper;

namespace ATTNPAY.Core
{
    public class RoMemberDtlsDAO
    {
       // private dbConnection conn;
        private string strSQL = string.Empty;
        /// <constructor>
        /// Constructor RoMemberDtlsDAO
        /// </constructor>
        public RoMemberDtlsDAO()
        {
            //conn = new dbConnection();
        }

              
        #region GetMemCodes
        public List<ListVO> GetMemCodes(string strMemCode)
        {
            try
            {

                if (string.IsNullOrEmpty(strMemCode))// all list
                   return null;
                else
                    strSQL = "SELECT RO_MEM_CODE LOV FROM [MASTER_RO_DTLS] where MEM_CODE=" + strMemCode.Trim() + " AND ACTIVATE='A'";
                return new List<ListVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<ListVO>());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion GetMemCodes
        #region LoadDataGridBindingList
        public DataTable LoadDataGrid(string strmemCode, string orderBy)
        {
            try
            {

                strSQL = " SELECT A.RO_MEM_CODE Code, B.Member_Name Name  FROM  MASTER_RO_DTLS A \n" +
                         " INNER JOIN MASTER_EMPLOYEE_MAIN B ON  A.RO_MEM_CODE = B.MEM_CODE \n" +
                        "  WHERE A.MEM_CODE = '" + strmemCode.Trim() + "'";
                if (!string.IsNullOrEmpty(orderBy))
                    strSQL += " Order by " + orderBy;
                return SQLHelper.ShowRecord(strSQL);  //SQLHelper.ShowRecord(strSQL).DataTableToList<EmployeeVO>());



            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region LoadDataGridBindingList
        public BindingList<RoMemberDetlsVO > LoadDataGridBindingList(string strmemCode,string orderBy)
        {
            try
            {

                strSQL = " SELECT ISNULL(convert(varchar(38), A.ROW_ID),'') ROW_ID , B.Member_Name,A.MEM_CODE, A.SEQ_NO, A.RO_MEM_CODE,A.ACTIVATE,'F' ISMODIFIED FROM  MASTER_RO_DTLS A \n" +
                         " INNER JOIN MASTER_EMPLOYEE_MAIN B ON  A.RO_MEM_CODE = B.MEM_CODE \n" +
                        "  WHERE A.MEM_CODE = '" + strmemCode.Trim()+"'";
                  if(!string.IsNullOrEmpty(orderBy))
                         strSQL +=" Order by " + orderBy;
                return new BindingList<RoMemberDetlsVO>(BindClassWithData.BindClass<RoMemberDetlsVO>(SQLHelper.ShowRecord(strSQL)));  //SQLHelper.ShowRecord(strSQL).DataTableToList<EmployeeVO>());

               
               
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region LoadDataGridBindingList
        public List<RoMemberDetlsVO> LoadDataGridList(string strmemCode, string orderBy)
        {
            try
            {

                strSQL = " SELECT  MEM_CODE,[RO_MEM_CODE]  FROM [MASTER_RO_DTLS] \n" +
                         " WHERE MEM_CODE='" + strmemCode.Trim() + "'" + " AND ACTIVATE='A'";  
                if (!string.IsNullOrEmpty(orderBy))
                    strSQL += " Order by " + orderBy.Trim();
                return new List<RoMemberDetlsVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<RoMemberDetlsVO>());

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
         

    }
}
