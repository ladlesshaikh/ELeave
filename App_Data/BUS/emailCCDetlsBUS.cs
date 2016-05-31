using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    /// <summary>
    /// Summary description for EmailCCGroupBUS
    /// </summary>
    public class EmailCCDetlsBUS
    {
        #region initialization
        private EmailCCDetlsDAO _emailCCDetlsDAO;

        /// <constructor>
        /// Constructor EmailCCDetlsBUS
        /// </constructor>
        public EmailCCDetlsBUS()
        {
            _emailCCDetlsDAO = new EmailCCDetlsDAO();
        }
        #endregion
        #region getEmailCCGroupList
        public List<EmailCCDetlsVO> getEmailCCGroupList()
        {
            try
            {
                return _emailCCDetlsDAO.LoadDataGridList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region getEmailCCGroupBindingList
        public BindingList<EmailCCDetlsVO> getEmailCCGroupBindingList(int? emailGroupId)
        {
            try
            {
                return _emailCCDetlsDAO.LoadDataGridBindingList(emailGroupId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion getEmailCCGroupBindingList

        #region getEmailCCMemberList
        /// <method>
        /// Get getEmailCCMemberList
        /// </method>

        public DataTable getEmailCCMemberList(string strMemCode, string orderBy)
        {
            try
            {
                return _emailCCDetlsDAO.LoadDataGridList(strMemCode.Trim(), orderBy.Trim());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #region getEmailCCList
        /// <method>
        /// Get getEmailCCMemberList
        /// </method>

        public List<string> getEmailCCList(string strMemCode, string orderBy)
        {
            try
            {
                return _emailCCDetlsDAO.LoadDataCCList(strMemCode.Trim(), orderBy.Trim());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion


    }
}
