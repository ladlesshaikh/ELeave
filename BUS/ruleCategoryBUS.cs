using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    /// <summary>
    /// Summary description forRuleCategoryBUS
    /// </summary>
    public class RuleCategoryBUS
    {
        #region initialization
        private RuleCategoryDAO  _ruleCategoryDAO;

        /// <constructor>
        /// Constructor RuleCategoryBUS
        /// </constructor>
        public RuleCategoryBUS()
        {
            _ruleCategoryDAO = new  RuleCategoryDAO();
        }
        #endregion
        #region getRuleCategoryList
        public List<RuleCategoryVO> getRuleCategoryList()
        {
            try
            {
                return _ruleCategoryDAO.LoadDataGridList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region getRuleCategoryBindingList
        public BindingList<RuleCategoryVO> getRuleCategoryBindingList()
        {
            try
            {
                return _ruleCategoryDAO.LoadDataGridBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

    }
}
