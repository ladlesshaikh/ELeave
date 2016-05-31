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
    public class EmployeeGradeBUS
    {
        private EmployeeGradeDAO _employeeGradeDAO;

        /// <constructor>
        /// Constructor UserBUS
        /// </constructor>
        public EmployeeGradeBUS()
        {
            _employeeGradeDAO = new EmployeeGradeDAO();
        }
        #region getEmployeeGradeList
        public List<EmployeeGradeVO> getEmployeeGradeList()
        {
            try
            {
                return _employeeGradeDAO.LoadDataGridList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region getEmployeeGradeBindingList
        public BindingList<EmployeeGradeVO> getEmployeeGradeBindingList()
        {
            try
            {
                return _employeeGradeDAO.LoadDataGridBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion


    }
}
