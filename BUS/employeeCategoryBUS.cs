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
    public class EmployeeCategoryBUS
    {
        private EmployeeCategoryDAO _employeeCategoryDAO;

        /// <constructor>
        /// Constructor UserBUS
        /// </constructor>
        public EmployeeCategoryBUS()
        {
            _employeeCategoryDAO = new EmployeeCategoryDAO();
        }

        #region getEmployeeCategory
        /// <method>
        /// Get EmployeeCategory
        /// </method>

        public List<EmployeeCategoryVO> getEmployeeCategoryList()
        {
            try
            {
                return _employeeCategoryDAO.LoadDataGridList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 

        #region getEmployeeCategoryBindingList
        /// <method>
        /// Get getEmployeeCategoryBindingList
        /// </method>

        public BindingList<EmployeeCategoryVO> getEmployeeCategoryBindingList()
        {
            try
            {
                return _employeeCategoryDAO.LoadDataGridBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 
        
    }
}
