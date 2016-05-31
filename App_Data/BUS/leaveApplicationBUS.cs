using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    /// <summary>
    /// Summary description for LeaveApplicationBUS
    /// </summary>
    public class LeaveApplicationBUS
    {
        private LeaveApplicationDAO _leaveApplicationDAO;

        /// <constructor>
        /// Constructor LeaveApplication
        /// </constructor>
        public LeaveApplicationBUS()
        {
            _leaveApplicationDAO = new LeaveApplicationDAO();
        }
        public DataTable GetLeaveType()
        {
            try
            {
                LeaveApplicationDAO dao = new LeaveApplicationDAO();
                DataTable dt = dao.LoadDataGridDT();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        #region CreateGUID
        public string getLeaveID()
        {
            try
            {
                LeaveApplicationDAO dao = new LeaveApplicationDAO();
                return (dao.GetLeaveID());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion



        // LoadDataGridBindingList
        #region getLeaveApplicationList
        public List<LeaveApplicationVO> getLeaveApplicationList()
        {
            try
            {
                return _leaveApplicationDAO.LoadDataGridList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion


        #region Get Leave Details by row id
        public List<LeaveApplicationVO> getLeaveDetailsByRowId(string rowId)
        {
            try
            {
                return (_leaveApplicationDAO.LoadLeaveDetailsByRowId(rowId));
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion



        #region getLeaveApplicationList(All)
        public List<LeaveApplicationVO> getLeaveApplicationListAll(string mem_code)
        {
            try
            {
                return _leaveApplicationDAO.LoadDataGridListAllReq(mem_code);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region getLeaveApplicationList(New)
        public List<LeaveApplicationVO> getLeaveApplicationListNew()
        {
            try
            {
                return _leaveApplicationDAO.LoadDataGridListNewReq();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion


        #region getLeaveApplicationList
        public bool UpdateLeaveStatus(string StatusId, string RowId, string Edit_By)
        {
            try
            {
                return _leaveApplicationDAO.ChangeLeaveStatus(StatusId, RowId, Edit_By);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region AutoApprove based on the document type
        public bool AutoapproveLeave(string RowId)
        {
            try
            {
                return _leaveApplicationDAO.AutoApproveLeaveDAO(RowId);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Transfer leave
        public bool TransferLeaveBUS(string AuthCode, string remarks, string row_id, string Edit_By)
        {
            try
            {
                return _leaveApplicationDAO.TransferLeaveDAO(AuthCode, remarks, row_id, Edit_By);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion


        #region Reject Leave
        public bool RejectLeave(string reason, string row_id, string Edit_By)
        {
            try
            {
                return _leaveApplicationDAO.RejectLeaveDAO(reason, row_id, Edit_By);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion


        #region getLeaveApplicationList with mem code
        public List<LeaveApplicationVO> getLeaveApplicationListByMemCode(string strMemCode)
        {
            try
            {
                return _leaveApplicationDAO.LoadDataGridListByEmpCode(strMemCode);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region "Get Leave Request based in RO/Admin"
        public List<LeaveApplicationVO> getLeaveApplicationListByRO(string mem_code,string branchCode)
        {
            try
            {
                return _leaveApplicationDAO.LoadDataGridListByRO(mem_code.Trim(),branchCode);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        // LoadDataGridList(string strMemCode)



        #region getLeaveApplicationBindingList
        public BindingList<LeaveApplicationVO> getLeaveApplicationBindingList()
        {
            try
            {
                return _leaveApplicationDAO.LoadDataGridBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region AddNewLeave
        public int AddNewLeave(string LeaveId, string strMemberCode, string iLeaveType, DateTime dtAppDate, DateTime dtFrom, DateTime dtTo, float fTotalDays, bool isSpecialLeave, bool isIsHalfDay, string strReason, string strFlag, string sUid, string sFinanCialYear, string ApprMemCode, string halfdayleavemode, string strRowId = "")
        //public int AddNewLeave(string strRowId, string strMemberCode, int iLeaveType, DateTime dtAppDate, DateTime dtFrom, DateTime dtTo, float fTotalDays, bool isSpecialLeave, bool isIsHalfDay, string strReason, string strFlag,string sUid, sFinanCialYear)
        {
            try
            {
                return _leaveApplicationDAO.AddNewLeave(LeaveId, strMemberCode, iLeaveType, dtAppDate, dtFrom, dtTo, fTotalDays, isSpecialLeave, isIsHalfDay, strReason, strFlag, sUid, sFinanCialYear, ApprMemCode, halfdayleavemode, strRowId);
            }
            catch (Exception ex)
            {
                return -3;
            }
        }

        #endregion AddNewLeave

        #region getLeaveApplicationRosList
        public List<RoMemberDetlsVO> LeaveApplicationRosList(string strMemCode, DateTime dtFrom, DateTime dtTo)
        {
            try

            {
                return _leaveApplicationDAO.LeaveApplicationRosList(strMemCode, dtFrom, dtTo);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<RoMemberDetlsVO> RosList(string strMemCode, DateTime dtFrom, DateTime dtTo)
        {
            try

            {
                return _leaveApplicationDAO.RosList(strMemCode, dtFrom, dtTo);
            }
            catch (Exception ex)
            {
                return null;
            }
        }//
        

        public List<RoMemberDetlsVO> LeaveApplicationforRO(string strMemCode, DateTime dtFrom, DateTime dtTo)
        {
            try

            {
                return _leaveApplicationDAO.LeaveApplicationforRO(strMemCode, dtFrom, dtTo);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<RoMemberDetlsVO> DuplicateCheck(string strMemCode, DateTime dtFrom, DateTime dtTo)
        {
            try

            {
                return _leaveApplicationDAO.DuplicateCheck(strMemCode, dtFrom, dtTo);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion getLeaveApplicationRosList

    }
}