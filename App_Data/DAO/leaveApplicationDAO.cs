using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.ComponentModel;
using EntityMapper;
using System.Globalization;

namespace ATTNPAY.Core
{
    public class LeaveApplicationDAO
    {
        // private dbConnection conn;
        private string strSQL = string.Empty;
        DataTable dtData;
        /// <constructor>
        /// Constructor leaveApplicationDAO
        /// </constructor>
        public LeaveApplicationDAO()
        {
            //conn = new dbConnection();
        }

        #region GetLeaveID
        public string GetLeaveID()
        {
            try
            {
                Guid g = new Guid();
                string id = (Guid.NewGuid()).ToString();
                return id;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region LoadDataGridDT
        public DataTable LoadDataGridDT()
        {
            try
            {
                using (DataTable dt = new DataTable())
                {
                    strSQL = "SELECT LeaveCode,LeaveName,ShortName,MaxBalance,MaxTransferabble, \n" +
                          " ISNULL(IsTransferable,0) IsTransferable,ISNULL(IsEncashable,0)IsEncashable,Activate,\n" +
                          " ISNULL(Acc_Month_Bal,0) Acc_Month_Bal FROM MASTER_LEAVE_TYPE";


                    return SQLHelper.ShowRecord(strSQL);
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region LoadDataGridList
        public List<LeaveApplicationVO> LoadDataGridList()
        {
            try
            {

                strSQL = "SELECT  CONVERT(VARCHAR(36),L.ROW_ID) ROW_ID ,L.MEM_CODE,M.Member_Name,L.LeaveCode, \n" +
                              " ML.LeaveName,CONVERT(VARCHAR(12),APP_DATE,106) APP_DATE,CONVERT(VARCHAR(12),FROM_DATE,106) FROM_DATE,\n" +
                              " CONVERT(VARCHAR(12),TO_DATE,106) TO_DATE,TOT_DAY,l.ACTIVATE,L.REASON,isnull(SPECIAL_LEAVE,0) SPECIAL_LEAVE, \n" +
                              " isnull(HALF_DAY_LEAVE,0) HALF_DAY_LEAVE FROM TRAN_LEAVE L \n" +
                               " INNER JOIN MASTER_LEAVE_TYPE ML ON L.LeaveCode = ML.LeaveCode  \n" +
                               " INNER JOIN MASTER_EMPLOYEE_MAIN M ON L.MEM_CODE = M.MEM_CODE";
                return SQLHelper.ShowRecord(strSQL).DataTableToList<LeaveApplicationVO>();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region LoadDataGridList(New Request)
        public List<LeaveApplicationVO> LoadDataGridListNewReq()
        {
            try
            {

                strSQL = "SELECT  CONVERT(VARCHAR(36),L.ROW_ID) ROW_ID ,L.MEM_CODE,M.Member_Name,L.LeaveCode, \n" +
                              " ML.LeaveName,CONVERT(VARCHAR(12),APP_DATE,106) APP_DATE,CONVERT(VARCHAR(12),FROM_DATE,106) FROM_DATE,\n" +
                              " CONVERT(VARCHAR(12),TO_DATE,106) TO_DATE,TOT_DAY,l.ACTIVATE,L.REASON,isnull(SPECIAL_LEAVE,0) SPECIAL_LEAVE, \n" +
                              " isnull(HALF_DAY_LEAVE,0) HALF_DAY_LEAVE,Is_Sanctioned FROM TRAN_LEAVE L \n" +
                               " INNER JOIN MASTER_LEAVE_TYPE ML ON L.LeaveCode = ML.LeaveCode AND L.Is_Sanctioned=2 \n" +
                               " INNER JOIN MASTER_EMPLOYEE_MAIN M ON L.MEM_CODE = M.MEM_CODE";
                return SQLHelper.ShowRecord(strSQL).DataTableToList<LeaveApplicationVO>();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region LoadDataGridList(All Request)
        public List<LeaveApplicationVO> LoadDataGridListAllReq(string mem_code)
        {
            try
            {

                strSQL = " SELECT Is_Sanctioned,RO_REMARKS,CONVERT(VARCHAR(36), L.ROW_ID) ROW_ID ,ISNULL(L.APPR_MEM_CODE, '') APPR_MEM_CODE ,L.MEM_CODE,M.Member_Name,L.LeaveCode, \n" +
                                          "    ML.LeaveName,CONVERT(VARCHAR(12), APP_DATE, 106) APP_DATE,CONVERT(VARCHAR(12), FROM_DATE, 106) FROM_DATE,\n" +
                                          "    CONVERT(VARCHAR(12), TO_DATE, 106) TO_DATE,TOT_DAY,l.ACTIVATE,L.REASON,isnull(SPECIAL_LEAVE, 0) SPECIAL_LEAVE, \n" +
                                          "    isnull(HALF_DAY_LEAVE, 0) HALF_DAY_LEAVE FROM TRAN_LEAVE L \n" +
                                          "    INNER JOIN MASTER_LEAVE_TYPE ML ON L.LeaveCode = ML.LeaveCode \n" +
                                          "    INNER JOIN MASTER_EMPLOYEE_MAIN M ON L.MEM_CODE = M.MEM_CODE \n" +
                                          "    AND L.MEM_CODE IN (SELECT MEM_CODE FROM MASTER_EMPLOYEE_MAIN WHERE RO_MEM_CODE = '" + mem_code.Trim() + "') \n" +
                                          "    and M.EMP_STATUS = 'A'  AND ISNULL(APPR_MEM_CODE,'')= '' AND Is_Sanctioned<>2 \n" +
                                          "  UNION ALL \n" +
                                          "  SELECT Is_Sanctioned,RO_REMARKS,CONVERT(VARCHAR(36), L.ROW_ID) ROW_ID ,ISNULL(L.APPR_MEM_CODE, '') APPR_MEM_CODE , L.MEM_CODE,M.Member_Name,L.LeaveCode,  \n" +
                                          "  ML.LeaveName,CONVERT(VARCHAR(12), APP_DATE, 106) APP_DATE,CONVERT(VARCHAR(12), FROM_DATE, 106) FROM_DATE,\n" +
                                          "  CONVERT(VARCHAR(12), TO_DATE, 106) TO_DATE,TOT_DAY,l.ACTIVATE,L.REASON,isnull(SPECIAL_LEAVE, 0) SPECIAL_LEAVE, \n" +
                                          "  isnull(HALF_DAY_LEAVE, 0) HALF_DAY_LEAVE FROM TRAN_LEAVE L \n" +
                                          "  INNER JOIN MASTER_LEAVE_TYPE ML ON L.LeaveCode = ML.LeaveCode \n" +
                                          "  INNER JOIN MASTER_EMPLOYEE_MAIN M ON L.MEM_CODE = M.MEM_CODE \n" +
                                          "  and M.EMP_STATUS = 'A' AND ISNULL(L.APPR_MEM_CODE, '')= '" + mem_code.Trim() + "' AND Is_Sanctioned<>2";

                return SQLHelper.ShowRecord(strSQL).DataTableToList<LeaveApplicationVO>();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...


        #region Load Leave Details by Row Id
        public List<LeaveApplicationVO> LoadLeaveDetailsByRowId(string rowId)
        {
            try
            {
                string strSQL = "select L.LeaveCode,L.APP_DATE,L.FROM_DATE,L.HALF_DAY_LEAVE,L.SPECIAL_LEAVE,L.TO_DATE,L.TOT_DAY,L.REASON,E.Member_Name as MEM_CODE, E.Mem_code as Member_Name from TRAN_LEAVE L inner join MASTER_EMPLOYEE_MAIN E on E.MEM_CODE=L.MEM_CODE where L.ROW_ID='" + rowId + "'";
                return SQLHelper.ShowRecord(strSQL).DataTableToList<LeaveApplicationVO>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region Load Grid List for Logged user with employee role
        public List<LeaveApplicationVO> LoadDataGridListByEmpCode(string strMemCode)
        {
            try
            {
                if (string.IsNullOrEmpty(strMemCode))
                    return null;
                else
                {
                    strSQL = "SELECT L.Is_Send_Mail,CONVERT(VARCHAR(36),L.ROW_ID) ROW_ID ,L.MEM_CODE,M.Member_Name,L.LeaveCode, \n" +
                                  " ML.LeaveName,CONVERT(VARCHAR(12),APP_DATE,101) APP_DATE,CONVERT(VARCHAR(12),FROM_DATE,101) FROM_DATE,\n" +
                                  " CONVERT(VARCHAR(12),TO_DATE,101) TO_DATE,TOT_DAY,l.ACTIVATE,L.REASON,isnull(SPECIAL_LEAVE,0) SPECIAL_LEAVE, \n" +
                                  " isnull(HALF_DAY_LEAVE,0) HALF_DAY_LEAVE,Is_Sanctioned,RO_REMARKS FROM TRAN_LEAVE L \n" +
                                   " INNER JOIN MASTER_LEAVE_TYPE ML ON L.LeaveCode = ML.LeaveCode  \n" +
                                   " INNER JOIN MASTER_EMPLOYEE_MAIN M ON L.MEM_CODE ='" + strMemCode.Trim() + "' AND L.MEM_CODE=M.MEM_CODE WHERE EMP_STATUS = 'A'";
                    return SQLHelper.ShowRecord(strSQL).DataTableToList<LeaveApplicationVO>();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region "Load Leave Request Based on the RO/Admin"
        public List<LeaveApplicationVO> LoadDataGridListByRO(string mem_code, string branchCode)
        {
            EmployeeBUS bus = new EmployeeBUS();
            LoginUserBUS loginUsr = new LoginUserBUS();

            LeaveApplicationBUS LAB = new LeaveApplicationBUS();
            LoginUserVO user = new LoginUserVO();
            string ROCode;
            try
            {
                user = loginUsr.GetAdminUser(branchCode);
                ROCode = Convert.ToString(user.MEM_CODE);
                if (mem_code == ROCode)
                {
                    strSQL = " SELECT Is_Sanctioned,RO_REMARKS,CONVERT(VARCHAR(36), L.ROW_ID) ROW_ID ,ISNULL(L.APPR_MEM_CODE, '') APPR_MEM_CODE,ISNULL(L.Edit_By, '')Edit_By,  CONVERT(VARCHAR(12) , ISNULL(L.Edit_date,'')) Edit_date,L.MEM_CODE,M.Member_Name,L.LeaveCode, \n" +
                          "    ML.LeaveName,CONVERT(VARCHAR(12), APP_DATE, 106) APP_DATE,CONVERT(VARCHAR(12), FROM_DATE, 106) FROM_DATE,\n" +
                          "    CONVERT(VARCHAR(12), TO_DATE, 106) TO_DATE,TOT_DAY,l.ACTIVATE,L.REASON,isnull(SPECIAL_LEAVE, 0) SPECIAL_LEAVE, \n" +
                          "    isnull(HALF_DAY_LEAVE, 0) HALF_DAY_LEAVE FROM TRAN_LEAVE L \n" +
                          "    INNER JOIN MASTER_LEAVE_TYPE ML ON L.LeaveCode = ML.LeaveCode \n" +
                          "    INNER JOIN MASTER_EMPLOYEE_MAIN M ON L.MEM_CODE = M.MEM_CODE \n" +
                          "    AND ISNULL(APPR_MEM_CODE,'')= '' AND (Is_Sanctioned=2 OR Is_Sanctioned=3) and M.EMP_STATUS = 'A' \n" +
                          "  UNION \n" +
                          "  SELECT Is_Sanctioned,RO_REMARKS,CONVERT(VARCHAR(36), L.ROW_ID) ROW_ID ,ISNULL(L.APPR_MEM_CODE, '') APPR_MEM_CODE,ISNULL(L.Edit_By, '')Edit_By,CONVERT(VARCHAR(12) , ISNULL(L.Edit_date,'')) Edit_date,L.MEM_CODE,M.Member_Name,L.LeaveCode,  \n" +
                          "  ML.LeaveName,CONVERT(VARCHAR(12), APP_DATE, 106) APP_DATE,CONVERT(VARCHAR(12), FROM_DATE, 106) FROM_DATE,\n" +
                          "  CONVERT(VARCHAR(12), TO_DATE, 106) TO_DATE,TOT_DAY,l.ACTIVATE,L.REASON,isnull(SPECIAL_LEAVE, 0) SPECIAL_LEAVE, \n" +
                          "  isnull(HALF_DAY_LEAVE, 0) HALF_DAY_LEAVE FROM TRAN_LEAVE L \n" +
                          "  INNER JOIN MASTER_LEAVE_TYPE ML ON L.LeaveCode = ML.LeaveCode \n" +
                          "  INNER JOIN MASTER_EMPLOYEE_MAIN M ON L.MEM_CODE = M.MEM_CODE \n" +
                          "  AND (Is_Sanctioned=2 OR Is_Sanctioned=3) and M.EMP_STATUS = 'A' ";
                }
                else
                {
                    strSQL = " SELECT Is_Sanctioned,RO_REMARKS,CONVERT(VARCHAR(36), L.ROW_ID) ROW_ID ,ISNULL(L.APPR_MEM_CODE, '') APPR_MEM_CODE,ISNULL(L.Edit_By, '')Edit_By,  CONVERT(VARCHAR(12) , ISNULL(L.Edit_date,'')) Edit_date,L.MEM_CODE,M.Member_Name,L.LeaveCode, \n" +
                          "    ML.LeaveName,CONVERT(VARCHAR(12), APP_DATE, 106) APP_DATE,CONVERT(VARCHAR(12), FROM_DATE, 106) FROM_DATE,\n" +
                          "    CONVERT(VARCHAR(12), TO_DATE, 106) TO_DATE,TOT_DAY,l.ACTIVATE,L.REASON,isnull(SPECIAL_LEAVE, 0) SPECIAL_LEAVE, \n" +
                          "    isnull(HALF_DAY_LEAVE, 0) HALF_DAY_LEAVE FROM TRAN_LEAVE L \n" +
                          "    INNER JOIN MASTER_LEAVE_TYPE ML ON L.LeaveCode = ML.LeaveCode \n" +
                          "    INNER JOIN MASTER_EMPLOYEE_MAIN M ON L.MEM_CODE = M.MEM_CODE \n" +
                          "    AND L.MEM_CODE IN (SELECT MEM_CODE FROM MASTER_EMPLOYEE_MAIN WHERE RO_MEM_CODE = '" + mem_code.Trim() + "') \n" +
                          "    AND ISNULL(APPR_MEM_CODE,'')= '' AND (Is_Sanctioned=2 OR Is_Sanctioned=3) and M.EMP_STATUS = 'A'  \n" +
                          "  UNION \n" +
                          "  SELECT Is_Sanctioned,RO_REMARKS,CONVERT(VARCHAR(36), L.ROW_ID) ROW_ID ,ISNULL(L.APPR_MEM_CODE, '') APPR_MEM_CODE,ISNULL(L.Edit_By, '')Edit_By,CONVERT(VARCHAR(12) , ISNULL(L.Edit_date,'')) Edit_date,L.MEM_CODE,M.Member_Name,L.LeaveCode,  \n" +
                          "  ML.LeaveName,CONVERT(VARCHAR(12), APP_DATE, 106) APP_DATE,CONVERT(VARCHAR(12), FROM_DATE, 106) FROM_DATE,\n" +
                          "  CONVERT(VARCHAR(12), TO_DATE, 106) TO_DATE,TOT_DAY,l.ACTIVATE,L.REASON,isnull(SPECIAL_LEAVE, 0) SPECIAL_LEAVE, \n" +
                          "  isnull(HALF_DAY_LEAVE, 0) HALF_DAY_LEAVE FROM TRAN_LEAVE L \n" +
                          "  INNER JOIN MASTER_LEAVE_TYPE ML ON L.LeaveCode = ML.LeaveCode \n" +
                          "  INNER JOIN MASTER_EMPLOYEE_MAIN M ON L.MEM_CODE = M.MEM_CODE \n" +
                          "  and M.EMP_STATUS = 'A' AND ISNULL(L.APPR_MEM_CODE, '')= '" + mem_code.Trim() + "' AND (Is_Sanctioned=2 OR Is_Sanctioned=3 )";
                }


                return SQLHelper.ShowRecord(strSQL).DataTableToList<LeaveApplicationVO>();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion






        #region LoadDataGridBindingList



        public BindingList<LeaveApplicationVO> LoadDataGridBindingList()
        {
            try
            {

                strSQL = "SELECT L.Is_Sanctioned,CONVERT(VARCHAR(36),L.ROW_ID) ROW_ID ,L.MEM_CODE,M.Member_Name,L.LeaveCode, \n" +
                              " ML.LeaveName,CONVERT(VARCHAR(12),APP_DATE,106) APP_DATE,CONVERT(VARCHAR(12),FROM_DATE,106) FROM_DATE,\n" +
                              " CONVERT(VARCHAR(12),TO_DATE,106) TO_DATE,TOT_DAY,l.ACTIVATE,L.REASON,isnull(SPECIAL_LEAVE,0) SPECIAL_LEAVE, \n" +
                              " isnull(HALF_DAY_LEAVE,0) HALF_DAY_LEAVE FROM TRAN_LEAVE L \n" +
                               " INNER JOIN MASTER_LEAVE_TYPE ML ON L.LeaveCode = ML.LeaveCode  \n" +
                               " INNER JOIN MASTER_EMPLOYEE_MAIN M ON L.MEM_CODE = M.MEM_CODE";
                return new BindingList<LeaveApplicationVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<LeaveApplicationVO>());

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...


        #region get the shift details whose date is overlap with currently selected  date  period
        //public int IsLeaveOverLap(string strMemCode, string sLeaveCode, DateTime leaveStartDt, DateTime leaveEndDt)
        //{
        //    try
        //    {
        //        var _leaveApplicationVO = getPendingLeaveApplied(strMemCode.Trim(), sLeaveCode);


        //        bool bOverLapped = false;


        //             bOverLapped = _leaveApplicationVO.Any(m =>
        //            (Convert.ToDateTime(m.FROM_DATE) >= leaveStartDt && Convert.ToDateTime(m.TO_DATE) <= leaveEndDt)
        //            ||
        //            (Convert.ToDateTime(m.TO_DATE)>= (leaveStartDt) && Convert.ToDateTime(m.TO_DATE) <= leaveEndDt)
        //            ||
        //            (Convert.ToDateTime(m.FROM_DATE) <= leaveStartDt.Date && Convert.ToDateTime(m.TO_DATE) >= leaveStartDt)
        //            ||
        //            (Convert.ToDateTime(m.FROM_DATE) <= (leaveStartDt) && (Convert.ToDateTime(m.TO_DATE)) >= (leaveEndDt))
        //            );
        //            return bOverLapped == true ? 1 : 0;

        //    }
        //    catch (Exception ex)
        //    {
        //        return -1; // exception
        //    }

        //}

        #endregion


        #region AddNewLeave()
        //public int AddNewLeave(string LeaveId, string strMemberCode, string iLeaveType, DateTime dtAppDate, DateTime dtFrom, DateTime dtTo, float fTotalDays, bool isSpecialLeave, bool isIsHalfDay, string strReason, string strFlag, string sUid, string sFinanCialYear, string ApprMemCode, string strRowId = "")
        //{
        //    int rtn = 0;
        //    try
        //    {

        //        #region validation
        //        if (dtFrom > dtTo)
        //        {

        //            rtn = 2;// date mismatch ...
        //        }

        //        if (GlobalVariable.CheckMonthEndForLeave(dtFrom.ToString("dd/MMM/yyyy")) == true)
        //        {

        //            rtn = 3;//"Invalid Start Date.. Month End Already Done For This Month"
        //        }
        //        if (fTotalDays <= 0)
        //        {

        //            rtn = 4; // total days <=0
        //        }

        //        #endregion validation

        //        if (strFlag.ToUpper() == "A")
        //        {
        //            strSQL = "SELECT * FROM TRAN_LEAVE WHERE FROM_DATE BETWEEN '" + dtFrom.ToString("dd/MMM/yyyy") + "' AND '" + dtTo.ToString("dd/MMM/yyyy") + "' AND Activate='A' AND MEM_CODE='" + strMemberCode.Trim() + "'";
        //            dtData = new DataTable();
        //            dtData = SQLHelper.ShowRecord(strSQL);
        //            if (dtData.Rows.Count > 0)
        //            {

        //                rtn = 5; // "Leave Application already present...."
        //            }
        //            strSQL = "SELECT * FROM TRAN_LEAVE WHERE TO_DATE BETWEEN '" + dtFrom.ToString("dd/MMM/yyyy") + "' AND '" + dtTo.ToString("dd/MMM/yyyy") + "' AND Activate='A' AND MEM_CODE='" + strMemberCode.Trim() + "'";
        //            dtData = new DataTable();
        //            dtData = SQLHelper.ShowRecord(strSQL);
        //            if (dtData.Rows.Count > 0)
        //            {

        //                rtn = 5;//Leave Application already present...."
        //            }

        //            if (isSpecialLeave == false)
        //            {
        //                strSQL = "SELECT * FROM TRAN_ATTN_MAIN WHERE LOG_DATE BETWEEN '" + dtFrom.ToString("dd/MMM/yyyy") + "' AND '" + dtTo.ToString("dd/MMM/yyyy") + "' AND Activate='A' AND MEM_CODE='" + strMemberCode.Trim() + "'";
        //                dtData = new DataTable();
        //                dtData = SQLHelper.ShowRecord(strSQL);
        //                if (dtData.Rows.Count > 0)
        //                {

        //                    rtn = 6;//"Data already presenrt....Can not apply Leave For the dates between"
        //                }
        //            }


        //            strSQL = "  SELECT   L.LeaveName, X.LeaveCode, \n" +
        //                        " (X.OB + ISNULL(LA.LEAVE_ACC_BAL,0)) - ( ISNULL(X.LEAVE_AVAILED,0) + ISNULL(L_ENCASH.EN_BAL, 0)) + ISNULL(ADJ.ADJ_BAL,0) CB  \n" +
        //                        "  FROM         (SELECT     MEM_CODE, LeaveCode, SUM(OB) AS OB, SUM(TotalLeave) AS LEAVE_AVAILED   \n" +
        //                        " FROM          (SELECT     MEM_CODE, LeaveCode, SUM(TOT_DAY) AS TotalLeave, 0 AS OB  \n" +
        //                        " FROM          TRAN_LEAVE  \n" +
        //                        " WHERE      (Activate = 'A') AND (FinYear = '" + sFinanCialYear.Trim() + "') AND (MEM_CODE = '" + strMemberCode.Trim() + "')  \n" +
        //                        " GROUP BY MEM_CODE, LeaveCode  \n" +
        //                        " UNION  \n" +
        //                        " SELECT     MEM_CODE, LEAVE_CODE, 0 AS TotalLeave, OB  \n" +
        //                        " FROM         TRAN_LEAVE_OB  \n" +
        //                        " WHERE     (MEM_CODE = '" + strMemberCode.Trim() + "') AND (FinYear = '" + sFinanCialYear.Trim() + "')) AS MAIN  \n" +
        //                        " GROUP BY MEM_CODE, LeaveCode) AS X LEFT OUTER JOIN  \n" +
        //                        " (SELECT     LeaveCode, MEM_CODE, SUM(ACCRUED_BAL) AS LEAVE_ACC_BAL  \n" +
        //                        " FROM          TRAN_LEAVE_ACCRUAL  \n" +
        //                        " WHERE      (FIN_YEAR = '" + sFinanCialYear.Trim() + "')  \n" +
        //                        " GROUP BY MEM_CODE, LeaveCode) AS LA ON X.MEM_CODE = LA.MEM_CODE AND X.LeaveCode = LA.LeaveCode LEFT OUTER JOIN \n" +
        //                        " (SELECT     LeaveCode, MEM_CODE, ISNULL(SUM(APPLIED), 0) AS EN_BAL \n" +
        //                        " FROM        TRAN_LEAVE_ENCASHMENT \n" +
        //                        " WHERE      (FINYEAR = '" + sFinanCialYear.Trim() + "') \n" +
        //                        " GROUP BY MEM_CODE, LeaveCode) AS L_ENCASH ON X.MEM_CODE = L_ENCASH.MEM_CODE AND X.LeaveCode = L_ENCASH.LeaveCode  \n" +
        //                        " LEFT OUTER JOIN  \n" +
        //                        " (SELECT     LeaveCode, MEM_CODE, ISNULL(SUM(ADJUST), 0) AS ADJ_BAL  \n" +
        //                        " FROM        TRAN_LEAVE_ADJUSTMENT WHERE (FIN_YEAR = '" + sFinanCialYear.Trim() + "') GROUP BY LeaveCode, MEM_CODE ) ADJ ON X.MEM_CODE = ADJ.MEM_CODE  \n" +
        //                        " AND X.LeaveCode = ADJ.LeaveCode  \n" +
        //                        " INNER JOIN MASTER_LEAVE_TYPE L ON X.LeaveCode = L.LeaveCode ";
        //            dtData = new DataTable();
        //            dtData = SQLHelper.ShowRecord(strSQL);
        //            if (dtData.Rows.Count <= 0)
        //            {
        //                rtn = 7;//No leave present..."
        //            }

        //        }

        //        if (strFlag == "A")
        //        {
        //            strSQL = "EXEC SP_LEAE_APPLICATION '" + LeaveId.Trim() + "','" + strMemberCode.Trim() + "','" + iLeaveType.ToString() + "',\n" +
        //            "'" + dtAppDate.ToString("dd/MMM/yyyy") + "','" + dtFrom.ToString("dd/MMM/yyyy") + "','" + dtTo.ToString("dd/MMM/yyyy") + "', \n" +
        //            fTotalDays.ToString().Trim() + ",'" + strReason.Trim() + "','" + sUid.Trim() + "','" + isSpecialLeave.ToString().Trim() + "','" + isIsHalfDay.ToString().Trim() + "','A','" + sFinanCialYear.Trim() + "','" + ApprMemCode.Trim() + "'";
        //        }
        //        else if (strFlag == "E")
        //        {
        //            strSQL = "EXEC SP_LEAE_APPLICATION '" + LeaveId.Trim() + "','" + strMemberCode.Trim() + "','" + iLeaveType.ToString() + "',\n" +
        //                "'" + dtAppDate.ToString("dd/MMM/yyyy") + "','" + dtFrom.ToString("dd/MMM/yyyy") + "','" + dtTo.ToString("dd/MMM/yyyy") + "', \n" +
        //                fTotalDays.ToString().Trim() + ",'" + strReason.Trim() + "','" + sUid.Trim() + "','" + isSpecialLeave.ToString().Trim() + "','" + isIsHalfDay.ToString().Trim() + "','E','" + sFinanCialYear.Trim() + "','" + ApprMemCode.Trim() + "','" + strRowId.Trim() + "'";
        //        }
        //        if (SQLHelper.InsertRecord(strSQL) > 0)
        //        {
        //            if (strFlag == "A")
        //                rtn = 0;//Data saved Successfully
        //            else if (strFlag == "E")
        //            {

        //                rtn = 0;//Data updated Successfully
        //            }
        //        }
        //        else
        //        {
        //            rtn = -1;// Data not Saved..";
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return -3;//exception...
        //    }
        //    return (rtn);
        //}
        public int AddNewLeave(string LeaveId, string strMemberCode, string iLeaveType, DateTime dtAppDate, DateTime dtFrom, DateTime dtTo, float fTotalDays, bool isSpecialLeave, bool isIsHalfDay, string strReason, string strFlag, string sUid, string sFinanCialYear, string ApprMemCode, string HalfDayLeaveMode, string strRowId = "")
        {
            int rtn = 0;
            try
            {

                #region validation
                if (dtFrom > dtTo)
                {

                    rtn = 2;// date mismatch ...
                }

                if (GlobalVariable.CheckMonthEndForLeave(dtFrom.ToString("dd/MMM/yyyy")) == true)
                {

                    rtn = 3;//"Invalid Start Date.. Month End Already Done For This Month"
                }
                if (fTotalDays <= 0)
                {

                    rtn = 4; // total days <=0
                }

                #endregion validation

                if (strFlag.ToUpper() == "A")
                {
                    strSQL = "SELECT * FROM TRAN_LEAVE WHERE FROM_DATE BETWEEN '" + dtFrom.ToString("dd/MMM/yyyy") + "' AND '" + dtTo.ToString("dd/MMM/yyyy") + "' AND Activate='A' AND MEM_CODE='" + strMemberCode.Trim() + "'";
                    dtData = new DataTable();
                    dtData = SQLHelper.ShowRecord(strSQL);
                    if (dtData.Rows.Count > 0)
                    {

                        rtn = 5; // "Leave Application already present...."
                    }
                    strSQL = "SELECT * FROM TRAN_LEAVE WHERE TO_DATE BETWEEN '" + dtFrom.ToString("dd/MMM/yyyy") + "' AND '" + dtTo.ToString("dd/MMM/yyyy") + "' AND Activate='A' AND MEM_CODE='" + strMemberCode.Trim() + "'";
                    dtData = new DataTable();
                    dtData = SQLHelper.ShowRecord(strSQL);
                    if (dtData.Rows.Count > 0)
                    {

                        rtn = 5;//Leave Application already present...."
                    }

                    if (isSpecialLeave == false)
                    {
                        strSQL = "SELECT * FROM TRAN_ATTN_MAIN WHERE LOG_DATE BETWEEN '" + dtFrom.ToString("dd/MMM/yyyy") + "' AND '" + dtTo.ToString("dd/MMM/yyyy") + "' AND Activate='A' AND MEM_CODE='" + strMemberCode.Trim() + "'";
                        dtData = new DataTable();
                        dtData = SQLHelper.ShowRecord(strSQL);
                        if (dtData.Rows.Count > 0)
                        {

                            rtn = 6;//"Data already presenrt....Can not apply Leave For the dates between"
                        }
                    }


                    strSQL = "  SELECT   L.LeaveName, X.LeaveCode, \n" +
                                " (X.OB + ISNULL(LA.LEAVE_ACC_BAL,0)) - ( ISNULL(X.LEAVE_AVAILED,0) + ISNULL(L_ENCASH.EN_BAL, 0)) + ISNULL(ADJ.ADJ_BAL,0) CB  \n" +
                                "  FROM         (SELECT     MEM_CODE, LeaveCode, SUM(OB) AS OB, SUM(TotalLeave) AS LEAVE_AVAILED   \n" +
                                " FROM          (SELECT     MEM_CODE, LeaveCode, SUM(TOT_DAY) AS TotalLeave, 0 AS OB  \n" +
                                " FROM          TRAN_LEAVE  \n" +
                                " WHERE      (Activate = 'A') AND (FinYear = '" + sFinanCialYear.Trim() + "') AND (MEM_CODE = '" + strMemberCode.Trim() + "')  \n" +
                                " GROUP BY MEM_CODE, LeaveCode  \n" +
                                " UNION  \n" +
                                " SELECT     MEM_CODE, LEAVE_CODE, 0 AS TotalLeave, OB  \n" +
                                " FROM         TRAN_LEAVE_OB  \n" +
                                " WHERE     (MEM_CODE = '" + strMemberCode.Trim() + "') AND (FinYear = '" + sFinanCialYear.Trim() + "')) AS MAIN  \n" +
                                " GROUP BY MEM_CODE, LeaveCode) AS X LEFT OUTER JOIN  \n" +
                                " (SELECT     LeaveCode, MEM_CODE, SUM(ACCRUED_BAL) AS LEAVE_ACC_BAL  \n" +
                                " FROM          TRAN_LEAVE_ACCRUAL  \n" +
                                " WHERE      (FIN_YEAR = '" + sFinanCialYear.Trim() + "')  \n" +
                                " GROUP BY MEM_CODE, LeaveCode) AS LA ON X.MEM_CODE = LA.MEM_CODE AND X.LeaveCode = LA.LeaveCode LEFT OUTER JOIN \n" +
                                " (SELECT     LeaveCode, MEM_CODE, ISNULL(SUM(APPLIED), 0) AS EN_BAL \n" +
                                " FROM        TRAN_LEAVE_ENCASHMENT \n" +
                                " WHERE      (FINYEAR = '" + sFinanCialYear.Trim() + "') \n" +
                                " GROUP BY MEM_CODE, LeaveCode) AS L_ENCASH ON X.MEM_CODE = L_ENCASH.MEM_CODE AND X.LeaveCode = L_ENCASH.LeaveCode  \n" +
                                " LEFT OUTER JOIN  \n" +
                                " (SELECT     LeaveCode, MEM_CODE, ISNULL(SUM(ADJUST), 0) AS ADJ_BAL  \n" +
                                " FROM        TRAN_LEAVE_ADJUSTMENT WHERE (FIN_YEAR = '" + sFinanCialYear.Trim() + "') GROUP BY LeaveCode, MEM_CODE ) ADJ ON X.MEM_CODE = ADJ.MEM_CODE  \n" +
                                " AND X.LeaveCode = ADJ.LeaveCode  \n" +
                                " INNER JOIN MASTER_LEAVE_TYPE L ON X.LeaveCode = L.LeaveCode ";
                    dtData = new DataTable();
                    dtData = SQLHelper.ShowRecord(strSQL);
                    if (dtData.Rows.Count <= 0)
                    {
                        rtn = 7;//No leave present..."
                    }

                }

                if (rtn == 0)
                {
                    if (strFlag == "A")
                    {
                        strSQL = "EXEC SP_LEAE_APPLICATION '" + LeaveId.Trim() + "','" + strMemberCode.Trim() + "','" + iLeaveType.ToString() + "',\n" +
                        "'" + dtAppDate.ToString("dd/MMM/yyyy") + "','" + dtFrom.ToString("dd/MMM/yyyy") + "','" + dtTo.ToString("dd/MMM/yyyy") + "', \n" +
                        fTotalDays.ToString().Trim() + ",'" + strReason.Trim() + "','" + sUid.Trim() + "','" + isSpecialLeave.ToString().Trim() + "','" + isIsHalfDay.ToString().Trim() + "','A','" + sFinanCialYear.Trim() + "','" + ApprMemCode.Trim() + "','" + HalfDayLeaveMode.Trim() + "'";

                    }
                    else if (strFlag == "E")
                    {
                        strSQL = "EXEC SP_LEAE_APPLICATION '" + LeaveId.Trim() + "','" + strMemberCode.Trim() + "','" + iLeaveType.ToString() + "',\n" +
                            "'" + dtAppDate.ToString("dd/MMM/yyyy") + "','" + dtFrom.ToString("dd/MMM/yyyy") + "','" + dtTo.ToString("dd/MMM/yyyy") + "', \n" +
                            fTotalDays.ToString().Trim() + ",'" + strReason.Trim() + "','" + sUid.Trim() + "','" + isSpecialLeave.ToString().Trim() + "','" + isIsHalfDay.ToString().Trim() + "','E','" + sFinanCialYear.Trim() + "','" + ApprMemCode.Trim() + "','" + HalfDayLeaveMode.Trim() + "','" + strRowId.Trim() + "'";
                    }
                    if (SQLHelper.InsertRecord(strSQL) > 0)
                    {
                        if (strFlag == "A")
                            rtn = 0;//Data saved Successfully
                        else if (strFlag == "E")
                        {

                            rtn = 0;//Data updated Successfully
                        }
                    }
                    else
                    {
                        rtn = -1;// Data not Saved..";
                    }
                }
                else
                {
                    if (rtn == 5 || rtn == 6 || rtn == 7)
                    {
                        rtn = -600;
                    }
                }
            }
            catch (Exception ex)
            {
                return -3;//exception...
            }
            return (rtn);
        }
        #endregion AddNewLeave()



        #region Change Leave Status
        public bool ChangeLeaveStatus(string StatusId, string RowId, string Edit_By)
        {
            try
            {
                DateTime dt = DateTime.Now;
                string edit_dt = dt.ToString("yyyy-MM-dd'T'HH:mm:ss");
                string StrQuery = "update TRAN_LEAVE set Is_Sanctioned=" + StatusId + ",Edit_By='" + Edit_By + "',Edit_date='" + edit_dt + "' where ROW_ID='" + RowId + "'";
                bool ret = SQLHelper.ExecuteQuery(StrQuery);
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Auto approve leave
        public bool AutoApproveLeaveDAO(string RowId)
        {
            try
            {
                DateTime dt = DateTime.Now;
                string edit_dt = dt.ToString("yyyy-MM-dd'T'HH:mm:ss");
                string StrQuery = "update TRAN_LEAVE set Is_Sanctioned=1,Edit_By='SYSTEM',Edit_date='" + edit_dt + "' where ROW_ID='" + RowId + "'";
                bool ret = SQLHelper.ExecuteQuery(StrQuery);
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region "Transfer Leave request"
        public bool TransferLeaveDAO(string AuthCode, string remarks, string row_id, string Edit_By)
        {
            try
            {
                DateTime dt = DateTime.Now;
                string StrQuery = "update TRAN_LEAVE set RO_REMARKS='" + remarks + "',APPR_MEM_CODE='" + AuthCode + "',Is_Sanctioned=3,Edit_By='" + Edit_By + "',Edit_date='" + dt + "' where ROW_ID='" + row_id + "'";
                bool ret = SQLHelper.ExecuteQuery(StrQuery);
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Reject Leave
        public bool RejectLeaveDAO(string reason, string row_id, string Edit_By)
        {
            try
            {
                DateTime dt = DateTime.Now;
                string StrQuery = "update TRAN_LEAVE set RO_REMARKS='" + reason + "',Is_Sanctioned=0 ,Edit_By='" + Edit_By + "',Edit_date='" + dt + "' where ROW_ID='" + row_id + "'";
                bool ret = SQLHelper.ExecuteQuery(StrQuery);
                return ret;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion




        #region getLeaveApplicationRosList
        //LeaveApplicationforRO
        public List<RoMemberDetlsVO> LeaveApplicationforRO(string strMemCode, DateTime dtFrom, DateTime dtTo)
        {
            try
            {
                List<RoMemberDetlsVO> lstRo = new List<RoMemberDetlsVO>();
                strSQL = "  SELECT C.RO_MEM_CODE MEM_CODE, D.Member_Name, ISNULL(C.SEQ_NO, 0) SEQNO ,   B.LeaveName , \n" +
                        "   ISNULL(D.EmailAddress, '') EMAIL ,0 ISADMIN \n" +
                        "   FROM[dbo].[TRAN_LEAVE]  A  \n" +
                        "   INNER JOIN MASTER_LEAVE_TYPE B ON  A.LeaveCode=B.LeaveCode \n" +
                        "   INNER JOIN MASTER_RO_DTLS C ON C.RO_MEM_CODE=A.MEM_CODE \n" +
                        "   INNER JOIN MASTER_EMPLOYEE_MAIN D ON D.MEM_CODE=C.RO_MEM_CODE \n" +
                        "   WHERE D.MEM_CODE ='" + strMemCode.Trim() + "'AND C.Activate='A' \n" +
                        "   AND A.FROM_DATE >= '" + dtFrom.ToString("dd-MMM-yyy", CultureInfo.InvariantCulture) + "' AND A.TO_DATE<= '" + dtTo.ToString("dd-MMM-yyy", CultureInfo.InvariantCulture) + "'\n" +
                        "    AND A.Activate = 'A' AND A.FinYear =" + GlobalVariable.FinanCialYear; //AND A.Is_Sanctioned = 1

                //" UNION \n" +
                //" SELECT  U.MEM_CODE, E.Member_Name,0 SeqNo, '' LeaveName , ISNULL(E.EmailAddress, '') EMAIL ,1 ISADMIN \n" +
                //" FROM MASTER_USER U  \n" +
                //" INNER JOIN MASTER_USER_GROUP R ON U.ROLE_ID = R.ROW_ID  \n" +
                //" INNER JOIN MASTER_EMPLOYEE_MAIN E ON U.MEM_CODE = E.MEM_CODE WHERE U.Branch_Id= 1 \n" +
                //" AND E.EMP_STATUS= 'A'  ORDER BY SEQNO ";
                //                 " AND UPPER(R.ROLE_NAME)='ADMIN' AND E.EMP_STATUS= 'A'  ORDER BY SEQNO ";

                lstRo = BindClassWithData.BindClass<RoMemberDetlsVO>(SQLHelper.ShowRecord(strSQL)).ToList();

                //if (lstRo == null || lstRo.Count == 0)
                //{
                //    //Returning Admin
                //    strSQL = " SELECT C.RO_MEM_CODE MEM_CODE, D.Member_Name, ISNULL(C.SEQ_NO, 0) SEQNO ,  '' LeaveName , \n" +
                //            "  ISNULL(D.EmailAddress, '') EMAIL ,0 ISADMIN FROM  MASTER_RO_DTLS C \n" +
                //            "  INNER JOIN MASTER_EMPLOYEE_MAIN D ON D.MEM_CODE = C.RO_MEM_CODE \n" +
                //            "  WHERE C.MEM_CODE = '" + strMemCode.Trim() + "' AND C.Activate = 'A'  ORDER BY SEQ_NO";

                //    lstRo = BindClassWithData.BindClass<RoMemberDetlsVO>(SQLHelper.ShowRecord(strSQL)).ToList();
                //}
                return lstRo;

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
                List<RoMemberDetlsVO> lstRo = new List<RoMemberDetlsVO>();
                strSQL = "  SELECT MEM_CODE  \n" +
                        "    from [TRAN_LEAVE] \n" +
                        "   WHERE FROM_DATE >= '" + dtFrom.ToString("dd-MMM-yyy", CultureInfo.InvariantCulture) + "' AND TO_DATE<= '" + dtTo.ToString("dd-MMM-yyy", CultureInfo.InvariantCulture) + "'\n" +
                        "   AND FinYear =" + GlobalVariable.FinanCialYear + " and Is_Sanctioned  in (1,2) and MEM_CODE = '" + strMemCode.Trim() + "'"; //AND A.Is_Sanctioned = 1

                lstRo = BindClassWithData.BindClass<RoMemberDetlsVO>(SQLHelper.ShowRecord(strSQL)).ToList();
                return lstRo;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<RoMemberDetlsVO> LeaveApplicationRosList(string strMemCode, DateTime dtFrom, DateTime dtTo)
        {
            try
            {
                List<RoMemberDetlsVO> lstRo = new List<RoMemberDetlsVO>();
                strSQL = "  SELECT C.RO_MEM_CODE MEM_CODE, D.Member_Name, ISNULL(C.SEQ_NO, 0) SEQNO ,   B.LeaveName , \n" +
                        "   ISNULL(D.EmailAddress, '') EMAIL ,0 ISADMIN \n" +
                        "   FROM[dbo].[TRAN_LEAVE]  A  \n" +
                        "   INNER JOIN MASTER_LEAVE_TYPE B ON  A.LeaveCode=B.LeaveCode \n" +
                        "   INNER JOIN MASTER_RO_DTLS C ON C.RO_MEM_CODE=A.MEM_CODE \n" +
                        "   INNER JOIN MASTER_EMPLOYEE_MAIN D ON D.MEM_CODE=C.RO_MEM_CODE \n" +
                        "   WHERE C.MEM_CODE ='" + strMemCode.Trim() + "'AND C.Activate='A' \n" +
                        "   AND A.FROM_DATE >= '" + dtFrom.ToString("MM-dd-yyy", CultureInfo.InvariantCulture) + "' AND A.TO_DATE<= '" + dtTo.ToString("MM-dd-yyy", CultureInfo.InvariantCulture) + "'\n" +
                        "   AND A.Is_Sanctioned = 1 AND A.Activate = 'A' AND A.FinYear =" + GlobalVariable.FinanCialYear + "\n" +

                        " UNION \n" +
                        " SELECT  U.MEM_CODE, E.Member_Name,0 SeqNo, '' LeaveName , ISNULL(E.EmailAddress, '') EMAIL ,1 ISADMIN \n" +
                        " FROM MASTER_USER U  \n" +
                        " INNER JOIN MASTER_USER_GROUP R ON U.ROLE_ID = R.ROW_ID  \n" +
                        " INNER JOIN MASTER_EMPLOYEE_MAIN E ON U.MEM_CODE = E.MEM_CODE WHERE U.Branch_Id= 1 \n" +
                        " AND E.EMP_STATUS= 'A'  ORDER BY SEQNO ";
                //                 " AND UPPER(R.ROLE_NAME)='ADMIN' AND E.EMP_STATUS= 'A'  ORDER BY SEQNO ";

                lstRo = BindClassWithData.BindClass<RoMemberDetlsVO>(SQLHelper.ShowRecord(strSQL)).ToList();

                if (lstRo == null || lstRo.Count == 0)
                {
                    //Returning Admin
                    strSQL = " SELECT C.RO_MEM_CODE MEM_CODE, D.Member_Name, ISNULL(C.SEQ_NO, 0) SEQNO ,  '' LeaveName , \n" +
                            "  ISNULL(D.EmailAddress, '') EMAIL ,0 ISADMIN FROM  MASTER_RO_DTLS C \n" +
                            "  INNER JOIN MASTER_EMPLOYEE_MAIN D ON D.MEM_CODE = C.RO_MEM_CODE \n" +
                            "  WHERE C.MEM_CODE = '" + strMemCode.Trim() + "' AND C.Activate = 'A'  ORDER BY SEQ_NO";

                    lstRo = BindClassWithData.BindClass<RoMemberDetlsVO>(SQLHelper.ShowRecord(strSQL)).ToList();
                }
                return lstRo;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<string> GetROCCList(string strMemCode)
        {
            try
            {

                strSQL = " SELECT(SELECT  ISNULL(EmailAddress, '') EmailAddress \n" +
                           " FROM MASTER_EMPLOYEE_MAIN WHERE  MEM_CODE = \n" +
                           " (SELECT ISNULL(RO_MEM_CODE, '') MEM_CODE FROM MASTER_EMPLOYEE_MAIN WHERE MEM_CODE = '" + strMemCode.Trim() + "' )) RO_EMAIL \n" +
                           " FROM MASTER_EMPLOYEE_MAIN WHERE EmailAddress is not null and MEM_CODE = '" + strMemCode.Trim() + "'";
                return (SQLHelper.ShowRecord(strSQL).Rows[0].ItemArray.Select(x => x.ToString()).ToArray().ToList<string>());

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
                List<RoMemberDetlsVO> lstRo = new List<RoMemberDetlsVO>();
                string strSQL = "   SELECT C.RO_MEM_CODE MEM_CODE,  (select member_name from  MASTER_EMPLOYEE_MAIN m where mem_code  = '" + strMemCode.Trim() + "' ) MEMBER_NAME,   \n" + //D.Member_Name,
                        "   ISNULL(C.SEQ_NO, 0) SEQNO ,  '' LeaveName ,  ISNULL(D.EmailAddress, '') EMAILADDRESS , \n" +
                        "   0 ISADMIN  FROM   \n" +
                        "    MASTER_RO_DTLS C    INNER JOIN MASTER_EMPLOYEE_MAIN D ON D.MEM_CODE=C.RO_MEM_CODE  \n" +
                        "     WHERE C.MEM_CODE = '" + strMemCode.Trim() + "'  \n" +
                        "   oRDER BY SEQNO ";

                lstRo = BindClassWithData.BindClass<RoMemberDetlsVO>(SQLHelper.ShowRecord(strSQL)).ToList();


                return lstRo;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion getLeaveApplicationRosList


    }

}
