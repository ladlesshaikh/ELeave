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
    public class EmailCCGroupBUS
    {
        #region initialization
        private EmailCCGroupDAO _emailCCGroupDAO;

        /// <constructor>
        /// Constructor EmailCCGroupBUS
        /// </constructor>
        public EmailCCGroupBUS()
        {
            _emailCCGroupDAO = new EmailCCGroupDAO();
        }
        #endregion
        #region getEmailCCGroupList
        public List<EmailCCGroupVO> getEmailCCGroupList()
        {
            try
            {
                return _emailCCGroupDAO.LoadDataGridList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region getEmailCCGroupBindingList
        public BindingList<EmailCCGroupVO> getEmailCCGroupBindingList()
        {
            try
            {
                return _emailCCGroupDAO.LoadDataGridBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion getEmailCCGroupBindingList

    }
}
