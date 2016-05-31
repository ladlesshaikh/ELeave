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
    public class ShiftBUS
    {
        private ShiftDAO _shiftDAO;

        #region Constructor
        /// <constructor>
        /// Constructor UserBUS
        /// </constructor>
        public ShiftBUS()
        {
            _shiftDAO = new ShiftDAO();
        }
        #endregion

        #region getShiftList
        /// <method>
        /// getShiftList
        /// </method>
        public List<ShiftVO> getShiftList()
        {
            try
            {
                return _shiftDAO.LoadDataGridList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion getShiftList

        #region getDefaultShifID
        /// <method>
        /// getDefaultShifID
        /// </method>
        public int getDefaultShifID()
        {
            try
            {
                return _shiftDAO.GetDefaultShifID();
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        #endregion getShiftList


        #region getShiftBindingList
        /// <method>
        /// getShiftList
        /// </method>
        public BindingList<ShiftVO> getShiftBindingList()
        {
            try
            {
                return _shiftDAO.LoadDataGridBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion getShiftList


        #region getNightShiftMembersList
        /// <method>
        /// getShiftList
        /// </method>
        public List<string> getNightShiftMembersList(string memList,DateTime dt)
        {
            try
            {

                return _shiftDAO.GetNightShiftMembersList(memList, dt);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion getNightShiftMembersList

        // getNightShiftMembersList

        #region getNightShiftMembersList
        /// <method>
        /// getShiftList
        /// </method>
        public bool isNightShiftMembers(string memCode, DateTime dt)
        {
            try
            {

                return _shiftDAO.IsNightShiftMembers(memCode,dt);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion getNightShiftMembersList


    }
}
