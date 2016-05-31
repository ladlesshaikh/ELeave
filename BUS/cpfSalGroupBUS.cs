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
    public class CpfSalGroupBUS
    {
        #region initialization
        private CpfSalGroupDAO _cpfSalGroupDAO;

        /// <constructor>
        /// Constructor CpfSalGroupBUS
        /// </constructor>
        public CpfSalGroupBUS()
        {
            _cpfSalGroupDAO = new CpfSalGroupDAO();
        }
        #endregion
        #region getCpfSalGroupList
        public List<CpfSalGroupVO> getCpfSalGroupList()
        {
            try
            {
                return _cpfSalGroupDAO.LoadDataGridList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region getCpfSalGroupBindingList
        public BindingList<CpfSalGroupVO> getCpfSalGroupBindingList()
        {
            try
            {
                return _cpfSalGroupDAO.LoadDataGridBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region getCpfSalGroupKeyValueBindingList
        public BindingList<CpfSalGroupVO> getCpfSalGroupKeyValueBindingList()
        {
            try
            {
                return _cpfSalGroupDAO.LoadDataGridKeyValueBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

    }
}
