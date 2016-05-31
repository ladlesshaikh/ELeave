using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    /// <summary>
    /// Summary description for cpfConfigBUS
    /// </summary>
    public class CpfConfigBUS
    {
        #region initialization
        private CpfConfigDAO    _cpfConfigDAO;

        /// <constructor>
        /// Constructor CpfConfigBUS
        /// </constructor>
        public CpfConfigBUS()
        {
            _cpfConfigDAO = new  CpfConfigDAO();
        }
        #endregion
        #region getCpfConfigList
        public List<CpfConfigVO> getCpfConfigList()
        {
            try
            {
                return _cpfConfigDAO.LoadDataGridList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region getCpfConfigBindingList
        public BindingList<CpfConfigVO> getCpfConfigBindingList()
        {
            try
            {
                return _cpfConfigDAO.LoadDataGridBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

    }
}
