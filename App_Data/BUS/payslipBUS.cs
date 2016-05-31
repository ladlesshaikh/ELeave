using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    /// <summary>
    /// Summary description for PayslipBUS
    /// </summary>
    public class PayslipBUS
    {
        private PayslipDAO _payslipDAO;

        /// <constructor>
        /// Constructor UserBUS
        /// </constructor>
        public PayslipBUS()
        {
            _payslipDAO = new PayslipDAO();
        }
        #region getPayListProcessingDatesInfo
        public List<PayslipProcessVO> getPayListProcessingDatesInfo(int iMonthId,int iYearID)
        {
            try
            {
                return _payslipDAO.GetPayslipProcessingDates(iMonthId, iYearID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion



        #region getPayListProcessingDatesInfo
        public List<PayslipProcessVO> getPayListProcessingDatesInfo(int iWeekno,int iMonthId, int iYearID)
        {
            try
            {
                return _payslipDAO.GetPayslipProcessingDates(iWeekno,iMonthId, iYearID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }



}
