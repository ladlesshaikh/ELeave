using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    public class TourApplicationDAO
    {
       // private dbConnection conn;
        string strSQL = string.Empty;

        /// <constructor>
        /// Constructor UserDAO
        /// </constructor>
        public TourApplicationDAO()
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
                    strSQL = "SELECT T.ROW_ID,T.MEM_CODE,M.Member_Name,T.TRA_ID,  \n" +
                             " MT.PLACE_Name,CONVERT(VARCHAR(12),APP_DATE,103) APP_DATE,CONVERT(VARCHAR(12),FROM_DATE,103) FROM_DATE, \n" +
                             " CONVERT(VARCHAR(12),TO_DATE,103) TO_DATE,TOT_DAY,T.ACTIVATE,T.REASON FROM TRAN_TOUR T  \n" +
                              " INNER JOIN MASTER_TOUR_PLACE MT ON T.TRA_ID = MT.PLACE_Id   \n" +
                              " INNER JOIN MASTER_EMPLOYEE_MAIN M ON T.MEM_CODE = M.MEM_CODE";
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
        public List<TourApplicationVO> LoadDataGridList()
        {
            try
            {

                strSQL = "SELECT CONVERT(VARCHAR(36),T.ROW_ID) ROW_ID ,T.MEM_CODE,M.Member_Name,T.TRA_ID,  \n" +
                              " MT.PLACE_Name,CONVERT(VARCHAR(12),APP_DATE,103) APP_DATE,CONVERT(VARCHAR(12),FROM_DATE,103) FROM_DATE, \n" +
                              " CONVERT(VARCHAR(12),TO_DATE,103) TO_DATE,TOT_DAY,T.ACTIVATE,T.REASON FROM TRAN_TOUR T  \n" +
                               " INNER JOIN MASTER_TOUR_PLACE MT ON T.TRA_ID = MT.PLACE_Id   \n" +
                               " INNER JOIN MASTER_EMPLOYEE_MAIN M ON T.MEM_CODE = M.MEM_CODE";
                return SQLHelper.ShowRecord(strSQL).DataTableToList<TourApplicationVO>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region LoadDataGridBindingList
        public BindingList<TourApplicationVO> LoadDataGridBindingList()
        {
            try
            {

                strSQL = "SELECT CONVERT(VARCHAR(36),T.ROW_ID) ROW_ID ,T.MEM_CODE,M.Member_Name,T.TRA_ID,  \n" +
                              " MT.PLACE_Name,CONVERT(VARCHAR(12),APP_DATE,103) APP_DATE,CONVERT(VARCHAR(12),FROM_DATE,103) FROM_DATE, \n" +
                              " CONVERT(VARCHAR(12),TO_DATE,103) TO_DATE,TOT_DAY,T.ACTIVATE,T.REASON FROM TRAN_TOUR T  \n" +
                               " INNER JOIN MASTER_TOUR_PLACE MT ON T.TRA_ID = MT.PLACE_Id   \n" +
                               " INNER JOIN MASTER_EMPLOYEE_MAIN M ON T.MEM_CODE = M.MEM_CODE";
                
                return new BindingList<TourApplicationVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<TourApplicationVO>());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
      
        


    }
}
