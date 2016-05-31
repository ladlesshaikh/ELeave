using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    /// <summary>
    /// Summary description for EmailSettingsBUS
    /// </summary>
    public class EmailSettingsBUS
    {
        private EmailSettingsDAO _emailSettingsDAO;

        /// <constructor>
        /// Constructor EmailSettingsBUS
        /// </constructor>
        public EmailSettingsBUS()
        {
            _emailSettingsDAO = new EmailSettingsDAO();
        }

        #region DocumentCategory
        /// <method>
        /// Get getDocumentList ....
        /// </method>
        
        public List<EmailSettingsVO> getEmailSettingsList()
        {
            try
            {
                return _emailSettingsDAO.LoadDataGridList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 

        #region getEmailSettingsBindingList
        /// <method>
        /// Get getEmailSettingsBindingList
        /// </method>

        public BindingList<EmailSettingsVO> getEmailSettingsBindingList()
        {
            try
            {
                return _emailSettingsDAO.LoadDataGridBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Send mail
        public int SendMail(EmailVO objEmail, EmailSettingsVO emailSettings, string rowId, string emailFrom = "")
        {
            try
            {
                return (_emailSettingsDAO.SendMail(objEmail, emailSettings,rowId, emailFrom));
            }
            catch(Exception ex)
            {
                return -1;
            }
        }
        #endregion
    }
}
