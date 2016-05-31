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
    public class BulkClockingListBUS
    {
       // private dbConnection conn;
        string strSQL = string.Empty;
        BulkClockingListDAO _bulkClockingListDAO = new BulkClockingListDAO();

        /// <constructor>
        /// Constructor BulkClockingListBUS
        /// </constructor>
        public BulkClockingListBUS()
        {
            //conn = new dbConnection();
        }

        #region LoadEmployeeList
        public List<BulkClockingListVO> LoadEmployeeList( bool iInsertNewClock, string strLogDt,int iShiftType=0,
               int ibranchId=0, int idepartment=0,int iDesignation=0,int iGrade=0, int iEmployeeType=0 )
        {
            try
            {
                return _bulkClockingListDAO.LoadEmployeeList(iInsertNewClock, strLogDt, iShiftType = 0,
                 ibranchId = 0, idepartment, iDesignation, iGrade, iEmployeeType);

              // return BindClassWithData.BindClass<BulkClockingListVO>(SQLHelper.ShowRecord(strSQL)).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region SaveBuklClocking
        public List<Tuple<string, string>> SaveBuklClocking(DateTime BulkLogDt,bool bChkInOrOut,DateTime BulkClockin,DateTime BulkClockOut,
                                        List<BulkClockingListVO> lstBulkClockingListVO,string strReason,
                                        bool bdtpBulkClockinCheckBox, bool bdtpBulkClockOutShowCheckBox )
        {

           

            try
            {

                 return _bulkClockingListDAO.SaveBuklClocking(BulkLogDt,bChkInOrOut, BulkClockin, BulkClockOut,
                                        lstBulkClockingListVO,strReason,
                                        bdtpBulkClockinCheckBox,  bdtpBulkClockOutShowCheckBox );
                             
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        # endregion SaveBuklClocking




    }
}
