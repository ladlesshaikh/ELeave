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
    public class TaxSlabBUS
    {
        private TaxSlabDAO _taxSlabDAO;

        /// <constructor>
        /// Constructor UserBUS
        /// </constructor>
        public TaxSlabBUS()
        {
            _taxSlabDAO = new TaxSlabDAO();
        }

        #region getTaxSlabList
        public List<TaxSlabVO> getTaxSlabList()
        {
            try
            {
                return _taxSlabDAO.LoadDataGridList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region getTaxSlabBindingList
        public BindingList<TaxSlabVO> getTaxSlabBindingList()
        {
            try
            {
                return _taxSlabDAO.LoadDataGridBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
