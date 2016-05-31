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
    public class AttnClockAmendmentBUS
    {
        private AttnClockAmendmentDAO _attnClockAmendmentDAO;

        /// <constructor>
        /// Constructor YearBUS
        /// </constructor>
        public AttnClockAmendmentBUS()
        {
            _attnClockAmendmentDAO = new AttnClockAmendmentDAO();
        }

        #region getAttnClockAmendmentList
        public List<AttnClockAmendmentVO> getAttnClockAmendmentList(string strStartDt, string strEndDt, string strEmpCode)
        {
            try
            {
                return _attnClockAmendmentDAO.GetClockAmendmentList(strStartDt, strEndDt, strEmpCode);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion


        //#region getAttnClockAmendmentList for Datewise
        //public string getAttnClockAmendmentListDate(string CurrDate, string Branch, string Dept, string Desig, string EType, string Grade)
        //{
        //    try
        //    {
        //        return _attnClockAmendmentDAO.GetClockAmmendDateData(CurrDate, Branch, Dept, Desig, EType, Grade);
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
        //#endregion

        #region getAttnClockAmendmentList for Datewise
        public List<AttnClockAmendmentVO> getAttnClockAmendmentListDate(string CurrDate, string Branch, string Dept, string Desig, string EType, string Grade)
        {
            try
            {
                return _attnClockAmendmentDAO.GetClockAmmendDateData(CurrDate, Branch, Dept, Desig, EType, Grade);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion



        #region checkClockingTime
        public bool checkClockingTime(string strMemberCode, string strLogdate, string strClockedTime, string strRowId)
        {
            try
            {
                return _attnClockAmendmentDAO.CheckClockingTime(strMemberCode, strLogdate, strClockedTime, strRowId);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region AddNewLog - in out clock edit ....
        public bool AddNewLog(string strMemberCode, string strLogdate, string strClockedInTime, string strClockedOutTime, string strReason, string strRowId, string strStatus)
        {

            try
            {
                return _attnClockAmendmentDAO.AddNewLog(strMemberCode, strLogdate, strClockedInTime, strClockedOutTime, strReason, strRowId, strStatus);

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion


        #region getAttnClockAmendmentBindingList
        public BindingList<AttnClockAmendmentVO> getAttnClockAmendmentBindingList(string strStartDt, string strEndDt, string strEmpCode)
        {
            try
            {
                return _attnClockAmendmentDAO.LoadDataGridBindingList(strStartDt, strEndDt, strEmpCode);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #region checkClockingTime
        
        #endregion

        #region ProcessAttnLog()

        public int ProcessAttnLog(string strProcedure, DataTable dt)
        {

            try
            {
                return _attnClockAmendmentDAO.ProcessAttnLog(strProcedure, dt);
            }
            catch (Exception ex)
            {
                return -3;
            }

        }
        #endregion


    }
}
