using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    /// <summary>
    /// Summary description for UserBUS
    /// </summary>
    public class PayslipListBUS
    {
        private PayslipListDAO _payslipListDAO;

        /// <constructor>
        /// Constructor PayslipListBUS
        /// </constructor>
        public PayslipListBUS()
        {
            _payslipListDAO = new  PayslipListDAO();
        }

        #region GetPayslip
        public PayslipListVO GetPayslip(string sMemCode, int iMonth, int iYear, int iWEEKNO = 0, DateTime processDt = default(DateTime))

        {
            try
            {
                return _payslipListDAO.GetPayslip(sMemCode, iMonth, iYear, iWEEKNO ,  processDt);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        
    }
}
