using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    /// <summary>
    /// Summary description for  SalaryEarningBUS
    /// </summary>
    public class SalaryEarningBUS
    {
        private SalaryEarningDAO _salaryEarningDAO;

        /// <constructor>
        /// Constructor UserBUS
        /// </constructor>
        public SalaryEarningBUS()
        {
            _salaryEarningDAO = new SalaryEarningDAO();
        }

        #region getSalaryEarningList
        /// <method>
        /// Get getSalaryEarningList
        /// </method>

        public List<SalaryEarningVO> getSalaryEarningList(string strRowId)
        {
            try
            {
                return _salaryEarningDAO.LoadSalaryEarningList(strRowId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 
        #region salaryEarningBindingList
        /// <method>
        /// Get SalaryEarning
        /// </method>

        public BindingList<SalaryEarningVO> getSalaryEarningBindingList(string strRowId)
        {
            try
            {
                return _salaryEarningDAO.LoadDataGridBindingList(strRowId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 
        
    }
}
