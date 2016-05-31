using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    /// <summary>
    /// Summary description for ShiftGroupBUS
    /// </summary>
    public class ShiftGroupDetlsBUS
    {
        private  ShiftGroupDtlsDAO _shiftGroupDtlsDAO;

        /// <constructor>
        ///  ShiftGroupBUS
        /// </constructor>
        public ShiftGroupDetlsBUS()
        {
            _shiftGroupDtlsDAO = new ShiftGroupDtlsDAO(); 
        }

        #region getShiftGroupMemCodes
        /// <method>
        /// Get getShiftGroupList
        /// </method>

        public List<ListVO> getShiftGroupMemCodes(int igroupID)
        {
            try
            {
                return _shiftGroupDtlsDAO.GetMemCodes(igroupID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 

        #region getShiftGroupDetlsBindingList
        /// <method>
        /// Get getShiftGroupDetlsBindingList
        /// </method>

        public BindingList<ShiftGroupDetlsVO> getShiftGroupDetlsBindingList(string strGrId,string orderBy)
        {
            try
            {
                return _shiftGroupDtlsDAO.LoadDataGridBindingList(strGrId, orderBy);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 
    }
}
