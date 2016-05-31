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
    public class PaymentModeBUS
    {
        private PaymentModeDAO _paymentModeDAO;

        /// <constructor>
        /// Constructor UserBUS
        /// </constructor>
        public PaymentModeBUS()
        {
            _paymentModeDAO = new  PaymentModeDAO();
        }

        #region getPaybasisList
        public List<PaymentModeVO> getPaymentModeList()
        {
            try
            {
                return _paymentModeDAO.LoadDataGridList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region getPaybasisBindingList
        public BindingList<PaymentModeVO> getPaybasisBindingList()
        {
            try
            {
                return _paymentModeDAO.LoadDataGridBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
