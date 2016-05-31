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
    public class LoanBUS
    {
        private LoanDAO _loanDAO;

        /// <constructor>
        /// Constructor UserBUS
        /// </constructor>
        public LoanBUS()
        {
            _loanDAO = new LoanDAO();
        }

        #region getLoanList
        public List<LoanVO> getLoanList(bool bChkWithDate, bool bRdMemCode, string strMemberCode, string strSDate, string strEndDate)
        {
            try
            {
                return _loanDAO.LoadDataGridList(bChkWithDate, bRdMemCode, strMemberCode, strSDate, strEndDate);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region getLoanBindingList
        public BindingList<LoanVO> getLoanBindingList(bool bChkWithDate, bool bRdMemCode, string strMemberCode, string strSDate, string strEndDate)
        {
            try
            {
                return _loanDAO.LoadDataGridBindingList(bChkWithDate, bRdMemCode, strMemberCode, strSDate, strEndDate);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
