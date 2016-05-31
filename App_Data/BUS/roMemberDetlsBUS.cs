using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    /// <summary>
    /// Summary description for RoMemberDetlsBUS
    /// </summary>
    public class RoMemberDetlsBUS
    {
        private RoMemberDtlsDAO _roMemberDtlsDAO;

        /// <constructor>
        ///  RoMemberDetlsBUS
        /// </constructor>
        public RoMemberDetlsBUS()
        {
            _roMemberDtlsDAO = new RoMemberDtlsDAO();  
        }

        #region getRoMembers
        /// <method>
        /// Get getRoMembers
        /// </method>

        public List<ListVO> getRoMembers(string  strMemCode)
        {
            try
            {
                return _roMemberDtlsDAO.GetMemCodes(strMemCode.Trim());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion  getRoMembers

        #region LoadDataGrid
        /// <method>
        /// Get LoadDataGrid
        /// </method>


        public DataTable getDataGridList(string strmemCode, string orderBy)
        {
            try
            {
                return _roMemberDtlsDAO.LoadDataGrid(strmemCode, orderBy);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion LoadDataGrid

        #region getProjectTeamBindingList
        /// <method>
        /// Get getProjectTeamBindingList
        /// </method>
        public BindingList<RoMemberDetlsVO  > getRoMemberBindingList(string strMemCode,string orderBy)
        {
            try
            {
                return _roMemberDtlsDAO.LoadDataGridBindingList(strMemCode, orderBy);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region getRoMemberList
        /// <method>
        /// Get getRoMemberList
        /// </method>

        public List<RoMemberDetlsVO> getRoMemberList(string strMemCode, string orderBy)
        {
            try
            {
                return _roMemberDtlsDAO.LoadDataGridList(strMemCode.Trim(), orderBy.Trim());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

       
    }
}
