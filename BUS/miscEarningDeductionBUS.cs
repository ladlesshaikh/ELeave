using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    /// <summary>
    /// Summary description for MiscEarningDeductionBUS
    /// </summary>
    public class MiscEarningDeductionBUS
    {
        private MiscEarningDeductionDAO _miscEarningDeductionDAO;

        /// <constructor>
        /// Constructor MiscEarningDeductionBUS
        /// </constructor>
        public MiscEarningDeductionBUS()
        {
            _miscEarningDeductionDAO = new  MiscEarningDeductionDAO();
        }


        #region getEarningDeductionLOVList
        /// <method>
        /// Get getEarningDeductionLOVList
        /// </method>

        public List<MiscEarningDeductionLOV> getEarningDeductionLOVList()
        {
            try
            {
                // LoadEarningDeductionList include 0 value as amount field...
                return _miscEarningDeductionDAO.LoadEarningDeductionLOVList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 

        #region getEarningDeductionList
        /// <method>
        /// Get getEarningDeductionList
        /// </method>

        public List<MiscEarningDeductionVO> getMiscEarningDeductionList(bool isChkWithDate, bool isRdMemCode, string strMonthSearch, string strMemberCode)
        {
            try
            {
                return _miscEarningDeductionDAO.LoadDataGridList(isChkWithDate, isRdMemCode, strMonthSearch, strMemberCode);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 

        #region getEarningDeductionBindingList
        /// <method>
        /// Get getEarningDeductionList
        /// </method>

        public BindingList<MiscEarningDeductionVO> getEarningDeductionBindingList(bool isChkWithDate, bool isRdMemCode, string strMonthSearch, string strMemberCode)
        {
            try
            {
                return _miscEarningDeductionDAO.LoadDataGridBindingList(isChkWithDate, isRdMemCode, strMonthSearch, strMemberCode);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 
    }
}
