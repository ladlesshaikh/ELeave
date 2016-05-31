using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    /// <summary>
    /// Summary description for CpfGroupBUS
    /// </summary>
    public class CpfGroupBUS
    {
        #region initialization
        private CpfGroupDAO _cpfGroupDAO;

        /// <constructor>
        /// Constructor CpfGroupBUS
        /// </constructor>
        public CpfGroupBUS()
        {
            _cpfGroupDAO = new CpfGroupDAO();
        }
        #endregion
        #region getCpfGroupList
        public List<CpfGroupVO> getCpfGroupList()
        {
            try
            {
                return _cpfGroupDAO.LoadDataGridList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region getCpfGroupBindingList
        public BindingList<CpfGroupVO> getCpfGroupBindingList()
        {
            try
            {
                return _cpfGroupDAO.LoadDataGridBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

    }
}
