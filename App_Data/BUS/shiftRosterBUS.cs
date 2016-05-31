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
    public class ShiftRosterBUS
    {
        private ShiftRosterDAO _shiftRosterDAO;

        /// <constructor>
        /// Constructor UserBUS
        /// </constructor>
        public ShiftRosterBUS()
        {
            _shiftRosterDAO  = new ShiftRosterDAO();
        }

        #region getShiftRosterEmpList
        public List<ShiftRosterVO> getShiftRosterEmpList(int addFlag, string selVale, string sMemberCode,bool bExcludesBackRec)
        {
            try
            {
                return _shiftRosterDAO.GetDataGridDT(addFlag, selVale, sMemberCode, bExcludesBackRec);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion getShiftRosterEmpList

        #region getShiftRosterEmpList
        public List<ShiftRosterMemberVO> getShiftRosterMemList(int addFlag, string selVale, string sMemberCode, bool bExcludesBackRec)
        {
            try
            {
                return _shiftRosterDAO.GetDataGridMemDT(addFlag, selVale, sMemberCode, bExcludesBackRec);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion getShiftRosterEmpList

        #region getShiftRosterEmpList
        public List<ShiftRosterVO> getShiftRosterEmpList(int addFlag, string selVale, List<ListVO> lstListVO, bool bExcludesBackRec)
        {
            try
            {
                return _shiftRosterDAO.GetDataGridDT(addFlag, selVale, lstListVO,bExcludesBackRec);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion getShiftRosterEmpList

        #region getShiftRosterList
        public List<ShiftRosterVO> getShiftRosterList()
        {
            try
            {
                return _shiftRosterDAO.LoadDataGridList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #region getShiftRosterBindingList
        public BindingList<ShiftRosterVO> getShiftRosterBindingList()
        {
            try
            {
                return _shiftRosterDAO.LoadDataGridBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region getShiftPeriod
        public List<ShiftPeriodVO> getShiftPeriod(string sMemCode)
        {
            try
            {
                return _shiftRosterDAO.GetShiftPeriod(sMemCode);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion




    }
}
