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
    public class TransPayAttendanceBUS 
    {
        private TransPayAttendanceDAO _attpayDAO;

        /// <constructor>
        /// Constructor TransPayAttendanceBUS
        /// </constructor>
        public TransPayAttendanceBUS()
        {
            _attpayDAO = new TransPayAttendanceDAO();
        }

        #region getTourPlaceList
        public List<TransPayAttendanceVO> getMembersList()
        {
            try
            {
               // return _attpayDAO.GetMembersList();
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region getAttendanceProcessDateRange
        public List<string> getAttendanceProcessDateRange(string sMemCode,int oWeekNo,int iMonthId,int YrId)
        {
            try
            {
                var dtlst = _attpayDAO.GetAttendanceProcessDateRange(sMemCode,oWeekNo, iMonthId, YrId);
                return dtlst;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion getAttendanceProcessDateRange
        #region getAttendanceProcessDateRange
        public List<string> getAttendanceProcessDateRange( int oWeekNo, int iMonthId, int YrId)
        {
            try
            {
                var dtlst = _attpayDAO.GetAttendanceProcessDateRange( oWeekNo, iMonthId, YrId);
                return dtlst;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion getAttendanceProcessDateRange

    }
}
