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
    public class PaybasisBUS
    {
        private PaybasisDAO _paybasisDAO;

        /// <constructor>
        /// Constructor UserBUS
        /// </constructor>
        public PaybasisBUS()
        {
            _paybasisDAO = new PaybasisDAO();
        }

        #region getPaybasisList
        public List<PaybasisVO> getPayBasisList()
        {
            try
            {
                return _paybasisDAO.LoadDataGridList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region getPaybasisBindingList
        public BindingList<PaybasisVO> getPaybasisBindingList()
        {
            try
            {
                return _paybasisDAO.LoadDataGridBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
