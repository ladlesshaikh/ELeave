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
    public class EarningDeductionBUS
    {
        private EarningDeductionDAO _earningDeductionDAO;

        /// <constructor>
        /// Constructor UserBUS
        /// </constructor>
        public EarningDeductionBUS()
        {
            _earningDeductionDAO = new EarningDeductionDAO();
        }


       


        #region getEarningDeductionList
        /// <method>
        /// Get getEarningDeductionList
        /// </method>

        public List<EarningDeductionVO> getEarningDeductionList()
        {
            try
            {
                // LoadEarningDeductionList include 0 value as amount field...
                return _earningDeductionDAO.LoadEarningDeductionList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 

        #region getEarningDeductionList
        /// <method>
        /// Get getEarningDeductionBindingList
        /// </method>

        public BindingList<EarningDeductionVO> getEarningDeductionBindingList()
        {
            try
            {
                return _earningDeductionDAO.LoadDataGridBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 

        #region getEarningDeductionBasicBindingList
        /// <method>
        /// Get getEarningDeductionBasicBindingList
        /// </method>

        public BindingList<EarningDeductionVO> getEarningDeductionBasicBindingList()
        {
            try
            {
                return _earningDeductionDAO.LoadDataGridBasicBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 
    }
}
