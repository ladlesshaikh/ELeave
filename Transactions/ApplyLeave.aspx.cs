using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATTNPAY;
using System.Web.Script;
using System.Web.Services;
using System.Data.Linq;
using ATTNPAY.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft;
using System.Linq;
//using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Web.Configuration;

namespace BizHRMS.Transactions
{
    public partial class ApplyLeave : System.Web.UI.Page
    {



        protected void Page_Load(object sender, EventArgs e)
        {
            var isupload = WebConfigurationManager.AppSettings["uploaddoc"];
            hdfDocUploadInLeave.Value = isupload;
            //Account_Name.InnerHtml = "Welcome, " + GlobalVariable.UserName;
            hdfMemCode.Value = GlobalVariable.UserCode;
            hdfFinYear.Value = GlobalVariable.FinanCialYear;
            LeaveApplicationBUS LAB = new LeaveApplicationBUS();
            DataTable dt = LAB.GetLeaveType();
            ddlLeaveType.DataSource = dt;
            ddlLeaveType.DataValueField = "LeaveCode";
            ddlLeaveType.DataTextField = "LeaveName";
            ddlLeaveType.DataBind();
        }





        [WebMethod]
        public static BindingList<DocumentVO> GetDocumentType()
        {
            DocumentBUS bus = new DocumentBUS();
            try
            {
                BindingList<DocumentVO> lst = bus.getDocumentBindingList();
                return lst;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #region Auto Approve based on the document type
        [WebMethod]
        public static bool AutoApprove(string appId)
        {
            LeaveApplicationBUS bus = new LeaveApplicationBUS();
            try
            {
                bool ret = bus.AutoapproveLeave(appId);
                return ret;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="leaveId"></param>
        /// <param name="strRowId"></param>
        /// <param name="strMemberCode"></param>
        /// <param name="iLeaveType"></param>
        /// <param name="dtAppDate"></param>
        /// <param name="dtFrom"></param>
        /// <param name="dtTo"></param>
        /// <param name="fTotalDays"></param>
        /// <param name="isSpecialLeave"></param>
        /// <param name="isIsHalfDay"></param>
        /// <param name="iTotalDays"></param>
        /// <param name="strReason"></param>
        /// <param name="strFlag"></param>
        /// <param name="strFlagpercent"></param>
        /// <param name="halfdayleavemode"></param>
        /// <returns></returns>
        private static int SaveLeaveProxy(string leaveId, string strRowId, string strMemberCode, string iLeaveType, string dtAppDate, string dtFrom, string dtTo, string fTotalDays, string isSpecialLeave, string isIsHalfDay, string iTotalDays, string strReason, string strFlag, string strFlagpercent, string halfdayleavemode, bool isApprovedLeaveCancelletion = false)
        {
            var ret = 0;
            List<DepartmentEmployeeStatusVO> lstEmpStatusVO = new List<DepartmentEmployeeStatusVO>();
            LeaveApplicationBUS LAB = new LeaveApplicationBUS();
            try
            {
                string p_strRowId = strRowId;
                string p_strMemberCode = strMemberCode;
                string p_iLeaveType = iLeaveType;
                int LeaveNA = 0;
                int MailSend = 0;
                float percent = 0;
                DateTime p_dtAppDate = DateTime.ParseExact(dtAppDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                DateTime p_dtFrom = DateTime.ParseExact(dtFrom, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                DateTime p_dtTo = DateTime.ParseExact(dtTo, "MM/dd/yyyy", CultureInfo.InvariantCulture);

                float p_fTotalDays = float.Parse(fTotalDays, CultureInfo.InvariantCulture.NumberFormat);
                p_fTotalDays = p_fTotalDays + 1;
                bool p_isSpecialLeave = Convert.ToBoolean(Convert.ToInt32(isSpecialLeave));
                bool p_isIsHalfDay = Convert.ToBoolean(Convert.ToInt32(isIsHalfDay));
                int p_iTotalDays = Convert.ToInt32(iTotalDays);
                string p_strReason = strReason;
                string p_strFlag = strFlag;
                string cclist = "";
                string ROName = "";
                /*
                ProjectTeamStatusBUS bus = new ProjectTeamStatusBUS();
                List<ProjectTeamStatusVO> lst = bus.getStatusList(p_strMemberCode);
                for(var i=0;i<lst.Count;i++)
                {
                    int mem_count = lst[i].Mem_Count;
                    int leave_count = lst[i].Leave_Count;
                    int per_leave = ((leave_count / mem_count) * 100);
                    if(per_leave>50)
                    {
                        LeaveNA = 1;
                    }
                }
                */

                //Checking the RO Available
                LeaveApplicationBUS bus = new LeaveApplicationBUS();
                List<RoMemberDetlsVO> lstRO = new List<RoMemberDetlsVO>();
                List<RoMemberDetlsVO> lstROLeave = new List<RoMemberDetlsVO>();
                List<RoMemberDetlsVO> lstROCCList = new List<RoMemberDetlsVO>();
                EmployeeBUS empBUS = new EmployeeBUS();
                List<RoMemberInfoVO> ROLst = new List<RoMemberInfoVO>();
                var IsAdmin = 0;
                var ApprMemCode = "";
                var ApprMemName = "";
                var employeename = "";
                //lstRO = bus.LeaveApplicationRosList(p_strMemberCode, p_dtFrom, p_dtTo); //RosList
                //
                lstROLeave = bus.DuplicateCheck(p_strMemberCode, p_dtFrom, p_dtTo);

                if (isIsHalfDay == "1")
                {
                    p_fTotalDays = 0.5F;
                }
                else
                {
                    p_fTotalDays = TotalLeaveDaysExcudingHolidays(p_dtFrom, p_dtTo) + 1;
                }
                // if (i==1)
                if (lstROLeave.Count > 0)
                {
                    return -50;

                }
                //
                lstRO = bus.RosList(p_strMemberCode, p_dtFrom, p_dtTo);
                //Checking the Returned List is admin/RO
                //getLeaveApplicationRosList
                if (lstRO.Count == 0)
                {
                    return -200;
                }

                //cclist
                // lstROCCList = bus.GetROCCList(p_strMemberCode, p_dtFrom, p_dtTo);


                for (var i = 0; i < lstRO.Count; i++)
                {
                    if (lstRO[i].IsAdmin == "1")
                    {
                        IsAdmin = 1;
                    }
                    lstROLeave = bus.LeaveApplicationforRO(lstRO[i].MemCode, p_dtFrom, p_dtTo);

                    // if (i==1)
                    if (lstROLeave.Count == 0)
                    {
                        ApprMemCode = lstRO[i].MemCode;
                        employeename = lstRO[i].MemberName;
                        ROLst = empBUS.getRoName(ApprMemCode);

                        if (ROLst.Count > 0)
                        {
                            ROName = ROLst[0].Mem_Name;

                        }
                        ROLst = null;
                        break;
                    }
                }
                if (IsAdmin == 0)
                {
                    //Returned is RO Only

                }
                else
                {
                    //Returned is Admin 
                    //Need to check whether any RO Assigned.

                    ROLst = empBUS.getRoMemberInfo(p_strMemberCode, false);

                    if (ROLst.Count == 0)
                    {
                        //No RO Assigned.
                        //Alert the User that contact admin, no ROs Assigned!
                        return -100;

                    }
                    else
                    {

                        //Proceed with Admin Code as ApprMemCode
                    }
                }

                DepartmentDAO _DeptDAO = new DepartmentDAO();
                lstEmpStatusVO = _DeptDAO.GetStatusList(p_strMemberCode, p_dtFrom, p_dtTo);
                if (lstEmpStatusVO == null)
                {
                    // ret = LAB.AddNewLeave(leaveId, p_strMemberCode, p_iLeaveType, p_dtAppDate, p_dtFrom, p_dtTo, p_fTotalDays, p_isSpecialLeave, p_isIsHalfDay, p_strReason, p_strFlag, GlobalVariable.UserCode, GlobalVariable.FinanCialYear, ApprMemCode, p_strRowId, strFlagpercent);

                    ret = LAB.AddNewLeave(leaveId, p_strMemberCode, p_iLeaveType, p_dtAppDate, p_dtFrom, p_dtTo, p_fTotalDays, p_isSpecialLeave, p_isIsHalfDay, p_strReason, p_strFlag, GlobalVariable.UserCode, GlobalVariable.FinanCialYear, ApprMemCode, p_strRowId, halfdayleavemode);
                }
                else
                {
                    for (var i = 0; i < lstEmpStatusVO.Count; i++)
                    {
                        percent = lstEmpStatusVO[i].TotPercentage;
                    }
                    if (percent >= 50 && strFlagpercent == "Y")
                    {
                        ret = -10;
                        return ret;
                    }
                    else
                    {
                        // ret = LAB.AddNewLeave(leaveId, p_strMemberCode, p_iLeaveType, p_dtAppDate, p_dtFrom, p_dtTo, p_fTotalDays, p_isSpecialLeave, p_isIsHalfDay, p_strReason, p_strFlag, GlobalVariable.UserCode, GlobalVariable.FinanCialYear, ApprMemCode, p_strRowId);
                        ret = LAB.AddNewLeave(leaveId, p_strMemberCode, p_iLeaveType, p_dtAppDate, p_dtFrom, p_dtTo, p_fTotalDays, p_isSpecialLeave, p_isIsHalfDay, p_strReason, p_strFlag, GlobalVariable.UserCode, GlobalVariable.FinanCialYear, ApprMemCode, halfdayleavemode, p_strRowId);
                    }
                }

                //Send Email

                EmailVO emailH = new EmailVO();
                EmailSettingsVO emailD = new EmailSettingsVO();
                EmailSettingsBUS esBUS = new EmailSettingsBUS();
                LeaveApplicationBUS laBUS = new LeaveApplicationBUS();

                DocsBUS busd = new DocsBUS();
                List<DocsVO> lstDoc = new List<DocsVO>();
                List<string> tolist = new List<string>();
                List<string> attachLst = new List<string>();
                List<string> cclst = new List<string>();
                List<LeaveApplicationVO> LeaveDetail = new List<LeaveApplicationVO>();

                string EmailBody = "";

                //1.Attachments 
                //lstDoc = busd.getDocLst(app_id);
                //for (var i = 0; i < lstDoc.Count; i++)
                //{
                //    attachLst.Add(lstDoc[i].FILE_PATH);
                //}
                //emailH.AttachmentList = attachLst;
                //2.Mail Body
                // LeaveDetail = laBUS.getLeaveDetailsByRowId(app_id);
                emailH.Subject = "Leave Application";
                EmailBody += "Dear " + ROName + "," + "<br>" + "Leave Application has been received from Employee : <b>" + employeename + " [Employee Code:" + strMemberCode + "]" + "</b></h1><br>";
                EmailBody += "Leave starts from " + p_dtFrom.ToString("dd/MMM/yyyy") + " to " + p_dtTo.ToString("dd/MMM/yyyy") + " No. Of Days (" + p_fTotalDays + ")"; //+"</b> Day(s)<br>"+ " for <b>" + Convert.ToInt16( LeaveDetail[0].TOT_DAY)
                //if (p_isSpecialLeave == "1")
                //{
                //    EmailBody += "Type of leave : <b>Special Leave</b>";
                //}
                //if (LeaveDetail[0].HALF_DAY_LEAVE == 1)
                //{
                //    EmailBody += "Type of leave : <b>Half Leave</b>";
                //}
                EmailBody += "<br><b>Reason: <i>" + p_strReason + "</i></b>";
                EmailBody += "<br><br><a href='www.adharz.com/Login.aspx'>Login into E-Leave Portal</a> to Approve/Transfer/Reject Leave</b>";
                EmailBody += "<br><hr>";
                emailH.Body = EmailBody;
                //3.To List
                EmployeeBUS emBUS = new EmployeeBUS();

                tolist = emBUS.GetROAppDetEmail(ApprMemCode);
                cclst = emBUS.GetROCCtEmail(strMemberCode, ApprMemCode);
                //tolist.Add("manukuttanpk@gmail.com");
                emailH.EmailToList = tolist;
                //4.CC List
                //  cclst.Add("anubala99@gmail.com");
                if (cclst.Count == 0)
                    emailH.CCList = tolist; //cclst;
                else
                    emailH.CCList = cclst;

                //5.Mail Header Details
                EmailCCDetlsBUS emailCCBUS = new EmailCCDetlsBUS();
                emailH.CCList = emailCCBUS.getEmailCCList(strMemberCode, "");
                emailH.CCList.AddRange(cclst);
                emailH.CCList.AddRange(tolist);

                BindingList<EmailSettingsVO> emailSettings = esBUS.getEmailSettingsBindingList();
                emailH.IsHTML = 1;
                emailD.Is_Ssl = 0;
                emailD.Smtp_EmailFrom = emailSettings[0].Smtp_Uid;
                emailD.Smtp_Port = emailSettings[0].Smtp_Port;
                emailD.Smtp_Pwd = emailSettings[0].Smtp_Pwd;
                emailD.Smtp_Ip = emailSettings[0].Smtp_Ip;

                //Send mail
                ret = esBUS.SendMail(emailH, emailD, "0", emailD.Smtp_EmailFrom);
                //  return (esBUS.SendMail(emailH, emailD, "0", emailD.Smtp_EmailFrom)); //app_id
                //BA
                MailSend = 1;
                //
                if (MailSend == 1)
                {
                    return -500;
                }
                else
                {
                    if (ret == -600)
                    {
                        return ret;
                    }
                    else
                    {
                        return -500;
                    }
                }

                //
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ret;
        }
        [WebMethod]
        public static int SaveLeaveApp(string leaveId, string strRowId, string strMemberCode, string iLeaveType, string dtAppDate, string dtFrom, string dtTo, string fTotalDays, string isSpecialLeave, string isIsHalfDay, string iTotalDays, string strReason, string strFlag, string strFlagpercent, string halfdayleavemode)
        {
            #region Commented code
            //List<DepartmentEmployeeStatusVO> lstEmpStatusVO = new List<DepartmentEmployeeStatusVO>();
            //LeaveApplicationBUS LAB = new LeaveApplicationBUS();
            //try
            //{
            //    string p_strRowId = strRowId;
            //    string p_strMemberCode = strMemberCode;
            //    string p_iLeaveType = iLeaveType;
            //    int LeaveNA = 0;
            //    int ret;
            //    int MailSend = 0;
            //    float percent = 0;
            //    DateTime p_dtAppDate = DateTime.ParseExact(dtAppDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            //    DateTime p_dtFrom = DateTime.ParseExact(dtFrom, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            //    DateTime p_dtTo = DateTime.ParseExact(dtTo, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            //    float p_fTotalDays = float.Parse(fTotalDays, CultureInfo.InvariantCulture.NumberFormat);
            //    bool p_isSpecialLeave = Convert.ToBoolean(Convert.ToInt32(isSpecialLeave));
            //    bool p_isIsHalfDay = Convert.ToBoolean(Convert.ToInt32(isIsHalfDay));
            //    int p_iTotalDays = Convert.ToInt32(iTotalDays);
            //    string p_strReason = strReason;
            //    string p_strFlag = strFlag;

            //    /*
            //    ProjectTeamStatusBUS bus = new ProjectTeamStatusBUS();
            //    List<ProjectTeamStatusVO> lst = bus.getStatusList(p_strMemberCode);
            //    for(var i=0;i<lst.Count;i++)
            //    {
            //        int mem_count = lst[i].Mem_Count;
            //        int leave_count = lst[i].Leave_Count;
            //        int per_leave = ((leave_count / mem_count) * 100);
            //        if(per_leave>50)
            //        {
            //            LeaveNA = 1;
            //        }
            //    }
            //    */

            //    //Checking the RO Available
            //    LeaveApplicationBUS bus = new LeaveApplicationBUS();
            //    List<RoMemberDetlsVO> lstRO = new List<RoMemberDetlsVO>();
            //    var IsAdmin = 0;
            //    var ApprMemCode = "";
            //    var ApprMemMail = "";
            //    lstRO = bus.LeaveApplicationRosList(p_strMemberCode, p_dtFrom, p_dtTo);
            //    //Checking the Returned List is admin/RO

            //    if (lstRO.Count == 0)
            //    {
            //        return -200;
            //    }

            //    for (var i = 0; i < lstRO.Count; i++)
            //    {
            //        if (lstRO[i].IsAdmin == "1")
            //        {
            //            IsAdmin = 1;
            //        }
            //        if (i == 0)
            //        {
            //            ApprMemCode = lstRO[i].MemCode;
            //            ApprMemMail = lstRO[i].EmailAddress;
            //        }
            //    }
            //    if (IsAdmin == 0)
            //    {
            //        //Returned is RO Only

            //    }
            //    else
            //    {
            //        //Returned is Admin 
            //        //Need to check whether any RO Assigned.
            //        EmployeeBUS empBUS = new EmployeeBUS();
            //        List<RoMemberInfoVO> ROLst = new List<RoMemberInfoVO>();
            //        ROLst = empBUS.getRoMemberInfo(p_strMemberCode, false);

            //        if (ROLst.Count == 0)
            //        {
            //            //No RO Assigned.
            //            //Alert the User that contact admin, no ROs Assigned!
            //            return -100;
            //        }
            //        else
            //        {
            //            //Proceed with Admin Code as ApprMemCode
            //        }
            //    }

            //    DepartmentDAO _DeptDAO = new DepartmentDAO();
            //    lstEmpStatusVO = _DeptDAO.GetStatusList(p_strMemberCode, p_dtFrom, p_dtTo);
            //    if (lstEmpStatusVO == null || lstEmpStatusVO.Count == 0)
            //    {
            //        ret = LAB.AddNewLeave(leaveId, p_strMemberCode, p_iLeaveType, p_dtAppDate, p_dtFrom, p_dtTo, p_fTotalDays, p_isSpecialLeave, p_isIsHalfDay, p_strReason, p_strFlag, GlobalVariable.UserCode, GlobalVariable.FinanCialYear, ApprMemCode,halfdayleavemode,p_strRowId);
            //    }
            //    else
            //    {
            //        for (var i = 0; i < lstEmpStatusVO.Count; i++)
            //        {
            //            percent = lstEmpStatusVO[i].TotPercentage;
            //        }
            //        if (percent >= 50)
            //        {
            //            ret = -10;
            //        }
            //        else
            //        {
            //            ret = LAB.AddNewLeave(leaveId, p_strMemberCode, p_iLeaveType, p_dtAppDate, p_dtFrom, p_dtTo, p_fTotalDays, p_isSpecialLeave, p_isIsHalfDay, p_strReason, p_strFlag, GlobalVariable.UserCode, GlobalVariable.FinanCialYear, ApprMemCode,halfdayleavemode,p_strRowId);
            //        }
            //    }
            //    MailSend = Sendmail(leaveId, p_strMemberCode, ApprMemMail);
            //    if (MailSend == 1)
            //    {
            //        return ret;
            //    }
            //    else
            //    {
            //        if (ret == -600)
            //        {
            //            return ret;
            //        }
            //        else
            //        {
            //            return -500;
            //        }
            //    }

            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            #endregion

            return SaveLeaveProxy(leaveId, strRowId, strMemberCode, iLeaveType, dtAppDate, dtFrom, dtTo, fTotalDays, isSpecialLeave, isIsHalfDay, iTotalDays, strReason, strFlag, strFlagpercent, halfdayleavemode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        private static int TotalLeaveDaysExcudingHolidays(DateTime fromDate, DateTime toDate)
        {
            var retVal = 0;
            DateTime startDate = fromDate;
            DateTime endDate = toDate;
            TimeSpan diff = endDate - startDate;
            int days = diff.Days;
            retVal = days;
            var holidayDao = new HolidyDAO();
            var holidays = holidayDao.LoadDataGridList();
            for (var i = 0; i <= days; i++)
            {
                var testDate = startDate.AddDays(i);
                switch (testDate.DayOfWeek)
                {
                    case DayOfWeek.Saturday:
                    case DayOfWeek.Sunday:
                        retVal = retVal - 1;
                        break;
                    default:
                        var dateString = testDate.ToString("dd/MM/yyyy");
                        var holiday = holidays.Find(h => h.Holiday_Date == dateString);
                        if (null != holiday)
                        {
                            retVal = retVal - 1;
                        }
                        break;
                }
            }
            return retVal;
        }
        #region Creating Leave Application Id
        [WebMethod]
        public static string CreateGUID()
        {
            LeaveApplicationBUS LAB = new LeaveApplicationBUS();
            try
            {
                return (LAB.getLeaveID());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion


        [WebMethod]
        public static List<LeaveApplicationVO> getLeaveDetails(string MemCode)
        {
            LeaveApplicationBUS LAB = new LeaveApplicationBUS();
            List<LeaveApplicationVO> lstLeaveApp = new List<LeaveApplicationVO>();
            lstLeaveApp = LAB.getLeaveApplicationListByMemCode(MemCode);
            return lstLeaveApp;
        }

        [WebMethod]
        public static List<DocsVO> getDocDetails(string app_id)
        {
            DocsBUS bus = new DocsBUS();
            List<DocsVO> lstDoc = new List<DocsVO>();
            lstDoc = bus.getDocLst(app_id);
            return lstDoc;
        }

        [WebMethod]
        public static bool UpdateLeaveStatus(string StatusId, string RowId)
        {
            bool ret = false;
            try
            {
                string Edit_By = GlobalVariable.UserCode;
                LeaveApplicationBUS LAB = new LeaveApplicationBUS();

                //added code here for applying approved cancel leave.
                if (StatusId == "5")
                {
                    var leaveDetails = LAB.getLeaveApplicationListByMemCode(GlobalVariable.UserCode).FirstOrDefault(i => i.ROW_ID == RowId);
                    //user canceling approved leave so apply leave with Cancel leave type.
                    if (leaveDetails.Is_Sanctioned == 1)
                    {
                        ret = LAB.UpdateLeaveStatus("2", RowId, Edit_By);
                        //string leaveId, string strRowId, string strMemberCode, string iLeaveType, string dtAppDate, string dtFrom, string dtTo, string fTotalDays, string isSpecialLeave, string isIsHalfDay, string iTotalDays, string strReason, string strFlag, string strFlagpercent, string halfdayleavemode, bool isApprovedLeaveCancelletion = false
                        //SaveLeaveApp(leaveDetails.lea)
                    }
                }
                else
                {
                    ret = LAB.UpdateLeaveStatus(StatusId, RowId, Edit_By);
                }
                return ret;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        [WebMethod]
        public static bool DeleteDoc(string doc_id)
        {
            DocsBUS LAB = new DocsBUS();
            bool ret = LAB.DeleteDoc(doc_id);
            return ret;
        }


        [WebMethod]
        public static List<LeaveHistoryVO> getLeaveHistory(string MemCode)
        {
            LeaveHistoryBUS LHB = new LeaveHistoryBUS();
            List<LeaveHistoryVO> lstLeaveApp = new List<LeaveHistoryVO>();
            lstLeaveApp = LHB.getLeaveHistoryList(MemCode);
            return lstLeaveApp;
        }

        [WebMethod]
        public static BindingList<LeaveHistoryVO> getLeaveHistoryDetails(string MemCode)
        {
            LeaveHistoryBUS LHB = new LeaveHistoryBUS();
            BindingList<LeaveHistoryVO> lstLeaveApp = new BindingList<LeaveHistoryVO>();
            lstLeaveApp = LHB.getLeaveHistoryBindingList(MemCode);
            return lstLeaveApp;
        }

        [WebMethod]
        public static List<ComboBoxFill> getEmpLst()
        {
            List<ComboBoxFill> lst = new List<ComboBoxFill>();
            EmployeeBUS _employeeBUS = new EmployeeBUS();
            lst = _employeeBUS.getEmployeeDropDownList(true, "Member_Name");
            return lst;
        }


        [WebMethod]
        public static int Sendmail(string app_id, string mem_code, string ro_mail)
        {
            EmailVO emailH = new EmailVO();
            EmailSettingsVO emailD = new EmailSettingsVO();
            EmailSettingsBUS esBUS = new EmailSettingsBUS();
            LeaveApplicationBUS laBUS = new LeaveApplicationBUS();
            EmailCCDetlsBUS emailCCBUS = new EmailCCDetlsBUS();

            DocsBUS bus = new DocsBUS();
            List<DocsVO> lstDoc = new List<DocsVO>();
            List<string> tolist = new List<string>();
            List<string> attachLst = new List<string>();
            List<string> cclst = new List<string>();
            List<LeaveApplicationVO> LeaveDetail = new List<LeaveApplicationVO>();
            string EmailBody = "";
            try
            {
                //1.Attachments 
                lstDoc = bus.getDocLst(app_id);
                for (var i = 0; i < lstDoc.Count; i++)
                {
                    attachLst.Add(lstDoc[i].FILE_PATH);
                }
                emailH.AttachmentList = attachLst;
                //2.Mail Body
                LeaveDetail = laBUS.getLeaveDetailsByRowId(app_id);
                emailH.Subject = "Leave Application";
                EmailBody += "Leave Application has been received from Employee : <b>" + LeaveDetail[0].MEM_CODE + "</b></h1><br>";
                EmailBody += "Leave starts from " + LeaveDetail[0].FROM_DATE + " to " + LeaveDetail[0].TO_DATE + " for <b>" + Convert.ToInt16(LeaveDetail[0].TOT_DAY) + "</b> Day(s)<br>";
                if (LeaveDetail[0].SPECIAL_LEAVE == 1)
                {
                    EmailBody += "Type of leave : <b>Special Leave</b>";
                }
                if (LeaveDetail[0].HALF_DAY_LEAVE == 1)
                {
                    EmailBody += "Type of leave : <b>Half Leave</b>";
                }
                EmailBody += "<br><b>Reason: <i>" + LeaveDetail[0].REASON + "</i></b>";
                EmailBody += "<br><hr>";
                emailH.Body = EmailBody;
                //3.To List
                EmployeeBUS emBUS = new EmployeeBUS();
                //tolist= emBUS.GetRODet(mem_code);
                tolist.Add(ro_mail);
                emailH.EmailToList = tolist;
                //4.CC List

                emailH.CCList = emailCCBUS.getEmailCCList(mem_code, "");
                emailH.CCList.AddRange(tolist);
                emailH.CCList.AddRange(cclst);
                //5.Mail Header Details
                BindingList<EmailSettingsVO> emailSettings = esBUS.getEmailSettingsBindingList();
                emailH.IsHTML = 1;
                emailD.Is_Ssl = 0;
                emailD.Smtp_EmailFrom = emailSettings[0].Smtp_Uid;
                emailD.Smtp_Port = emailSettings[0].Smtp_Port;
                emailD.Smtp_Pwd = emailSettings[0].Smtp_Pwd;
                emailD.Smtp_Ip = emailSettings[0].Smtp_Ip;

                //Send mail
                return (esBUS.SendMail(emailH, emailD, app_id, emailD.Smtp_EmailFrom));
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}