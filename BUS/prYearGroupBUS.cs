using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    /// <summary>
    /// Summary description for PRYearGroupBUS
    /// </summary>
    public class PRYearGroupBUS
    {
        #region initialization
        private PrYearGroupDAO _prYearGroupDAO;

        /// <constructor>
        /// Constructor PRYearGroupBUS
        /// </constructor>
        public PRYearGroupBUS()
        {
            _prYearGroupDAO = new PrYearGroupDAO();
        }
        #endregion
        #region getCpfAgeGroupListgetYearGroupList
        public List<PRYearGroupVO> getYearGroupList()
        {
            try
            {
                return _prYearGroupDAO.LoadDataGridList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region getPRYearGroupBindingList
        public BindingList<PRYearGroupVO> getPRYearGroupBindingList()
        {
            try
            {
                return _prYearGroupDAO.LoadDataGridBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

    }
}
