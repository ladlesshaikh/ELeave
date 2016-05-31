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
    public class CpfAgeGroupBUS
    {
        #region initialization
        private CpfAgeGroupDAO _cpfAgeGroupDAO;

        /// <constructor>
        /// Constructor CpfAgeGroupBUS
        /// </constructor>
        public CpfAgeGroupBUS()
        {
            _cpfAgeGroupDAO = new CpfAgeGroupDAO();
        }
        #endregion
        #region getCpfAgeGroupList
        public List<CpfAgeGroupVO> getCpfAgeGroupList()
        {
            try
            {
                return _cpfAgeGroupDAO.LoadDataGridList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region getCpfAgeGroupBindingList
        public BindingList<CpfAgeGroupVO> getCpfAgeGroupBindingList()
        {
            try
            {
                return _cpfAgeGroupDAO.LoadDataGridBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region getCpfAgeGroupKeyValueBindingList
        public BindingList<CpfAgeGroupVO> getCpfAgeGroupKeyValueBindingList()
        {
            try
            {
                return _cpfAgeGroupDAO.LoadDataGridKeyValueBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

    }
}
