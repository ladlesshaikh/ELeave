using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{
    /// <summary>
    /// Summary description for UserBUS
    /// </summary>
    public class EmployeeBUS
    {
        private EmployeeDAO _employeeDAO;

        /// <constructor>
        /// Constructor UserBUS
        /// </constructor>
        public EmployeeBUS()
        {
            _employeeDAO = new EmployeeDAO();
        }

        #region getEmployee -bool bChecked
        /// <method>
        /// Get getDevice
        /// </method>

        public List<EmployeeVO> getEmployeeList(bool bChecked, string orderBy)
        {
            try
            {
                return _employeeDAO.LoadDataGridList(bChecked, orderBy);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 

        #region getEmployee -bool bChecked
        /// <method>
        /// Get getDevice
        /// </method>

        public List<string> getEmployeesEntrollNos()
        {
            try
            {
                return _employeeDAO.GetEmployeesEntrollNos();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 


        

        #region getEmployee -using Employee Group ID
        /// <method>
        /// Get getDevice
        /// </method>

        //public List<string> getEmployeeGroupMemCodes(int iGroupID)
        //{
        //    try
        //    {
        //        return _employeeDAO.LoadDataGroupGridMemList(iGroupID);
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
        #endregion 


        #region getEmployeeBindingList -bool bChecked
        /// <method>
        /// Get getDevice
        /// </method>

        public BindingList<EmployeeVO> getEmployeeBindingList(bool bChecked, string orderBy,string strCondition)
        {
            try
            {
                return _employeeDAO.LoadDataGridBindingList(bChecked, orderBy, strCondition);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 

        #region getEmployeeBindingList -bool bChecked
        /// <method>
        /// Get getDevice
        /// </method>

        public BindingList<EmployeeVO> getEmployeeBindingList(bool bChecked, string orderBy)
        {
            try
            {
                return _employeeDAO.LoadDataGridBindingList(bChecked, orderBy);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 

        #region getEmployee -string strRowId
        /// <method>
        /// Get getDevice
        /// </method>

        public List<EmployeeVO> getEmployeeList(string strRowId, string orderBy)
        {
            try
            {
                return _employeeDAO.LoadDataGridList(strRowId, orderBy);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 

        
        #region GetEmployeeEarningList(string strRowId)
        /// <method>
        /// Get getEmployeeEarningList...
        /// </method>

        public List<EmployeeVO> getEmployeeEarningList(string strRowId, string orderBy)
        {
            try
            {
                return _employeeDAO.GetEmployeeEarningList(strRowId, orderBy);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 

        #region GetShiftGroupList(string strShiftGrpID)
        /// <method>
        /// Get GetShiftGroupList ....
        /// </method>

        public BindingList<EmployeeVO> GetShiftGroupList(string strShiftGrpID, string orderBy)
        {
            try
            {
                return _employeeDAO.GetEmployeeShiftGroupList(strShiftGrpID, orderBy);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 
        #region GetShiftScheduleList(string MemCode)
        /// <method>
        /// Get getShiftScheduleList...
        /// </method>

        public List<EmployeeVO> getShiftScheduleList(string MemCode, string orderBy)
        {
            try
            {
                return _employeeDAO.GetEmployeeEarningList(MemCode, orderBy);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 

        #region GetRulePropertyInfo(string MemCode)
        /// <method>
        /// Get GetRulePropertyInfo...
        /// </method>

        public RulePropertyInfo getRulePropertyInfo(string MemCode)
        {
            try
            {
                return _employeeDAO.GetRulePropertyInfo(MemCode);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 

        #region GetRulePropertyInfo(List<string> MemCodes)
        /// <method>
        /// Get GetRulePropertyInfo...
        /// </method>

        public List<RulePropertyInfo> getRulePropertyInfo(List<string> MemCodes)
        {
            try
            {
                return _employeeDAO.GetRulePropertyInfo(MemCodes);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 
        #region GetRulePropertyInfoList()
        /// <method>
        /// Get GetRulePropertyInfoList...
        /// </method>

        public List<RulePropertyInfo> getRulePropertyInfoList()
        {
            try
            {
                return _employeeDAO.GetRulePropertyInfoList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 




         



    }
}
