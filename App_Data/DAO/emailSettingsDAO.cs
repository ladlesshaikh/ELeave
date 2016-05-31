using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.ComponentModel;
using EntityMapper;
using System.Net.Mail;
using System.Net;

namespace ATTNPAY.Core
{
    public class EmailSettingsDAO
    {
       // private dbConnection conn;
        private string strSQL = string.Empty;
        /// <constructor>
        /// Constructor EmailSettingsDAO
        /// </constructor>
        public EmailSettingsDAO()
        {
            //conn = new dbConnection();
        }

       


        #region GetLoadDataGridDT
        private DataTable GetLoadDataGridDT()
        {
            try
            {
                strSQL = " SELECT  ISNULL(convert(varchar(38), ROW_ID),'') ROW_ID,[SMTP_SERVER],[SMTP_PORT] \n" +
                    " ,[SMTP_UID],[SMTP_PWD],[IS_SSL] ,[Activate] FROM MASTER_EMAILSETTINGS";
        
                return (SQLHelper.ShowRecord(strSQL));

               
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion GetLoadDataGridDT
        #region LoadDataGridList
        public List<EmailSettingsVO> LoadDataGridList()
        {
            try
            {
                strSQL = " SELECT  ISNULL(convert(varchar(38), ROW_ID),'') ROW_ID,[SMTP_SERVER],[SMTP_PORT] \n" +
                                   " ,[SMTP_UID],[SMTP_PWD],[IS_SSL] ,[Activate] FROM MASTER_EMAILSETTINGS";

                return BindClassWithData.BindClass<EmailSettingsVO>(SQLHelper.ShowRecord(strSQL)).ToList();
               
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        
        #region LoadDataGridList
        public BindingList<EmailSettingsVO> LoadDataGridBindingList()
        {
            try
            {
                strSQL = " SELECT  ISNULL(convert(varchar(38), ROW_ID),'') ROW_ID,[SMTP_SERVER],[SMTP_PORT] \n" +
                                   " ,[SMTP_UID],[SMTP_PWD],[IS_SSL] ,[Activate] FROM MASTER_EMAILSETTINGS";
                return new BindingList<EmailSettingsVO>( BindClassWithData.BindClass<EmailSettingsVO>(SQLHelper.ShowRecord(strSQL)).ToList());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region SendMail
        public int SendMail(EmailVO objEmail,EmailSettingsVO emailSettings, string rowId, string emailFrom="")
        {
            try {

                string smtpAddress = emailSettings.Smtp_Ip;
                int portNumber = emailSettings.Smtp_Port;
                bool enableSSL =  emailSettings.Is_Ssl==1 ? false :true;
                // string emailFrom = emailSettings"email@yahoo.com";


                string password = emailSettings.Smtp_Pwd;

                string emailTo = string.Join(";", objEmail.EmailToList);
                string ccTo = string.Join(";", objEmail.CCList);
                string subject = objEmail.Subject;
                string body = objEmail.Body;

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(emailFrom);
                    mail.To.Add(emailTo);
                    mail.CC.Add(ccTo);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true;
                    // Can set to false, if you are sending pure text.
                    //if(objEmail.AttachmentList.Count>0)
                    //{
                    //    foreach(string attmt in objEmail.AttachmentList)
                    //    {
                    //        var uploadFolder = "/Attachments";// you could put this to web.config
                    //        var root = System.Web.HttpContext.Current.Server.MapPath(uploadFolder);
                    //        mail.Attachments.Add(new Attachment(root+"/"+attmt));
                    //    }
                    //}
                    using (SmtpClient smtp = new SmtpClient(emailSettings.Smtp_Ip, emailSettings.Smtp_Port))
                    {
                        smtp.Credentials = new NetworkCredential(emailSettings.Smtp_EmailFrom, emailSettings.Smtp_Pwd);
                        smtp.EnableSsl = enableSSL;
                        smtp.Send(mail);
                    }
                }
                //Setting the Is_send_status
                string strQuery = "update TRAN_LEAVE set Is_Send_Mail=1 where ROW_ID='" + rowId + "'";
                bool ret = SQLHelper.ExecuteQuery(strQuery);
                if(ret==true)
                {
                    //All Actions Completed.
                    return 1;
                }
                else
                {
                    //Failure in Data saving.
                    return 0;
                }
            }catch( Exception exp)
            {
                return -1;
            }
        }

#endregion SendMail


        
        #region  CheckData
        private bool CheckData(string GroupName, string strFlag, string strRowId)
        {
            try
            {
                DataTable dt = new DataTable();
                if (strFlag == "A")
                {
                    strSQL = "SELECT SMTP_SERVER FROM MASTER_EMAILSETTINGS WHERE REPLACE(SMTP_SERVER,' ','') = REPLACE('" + GroupName + "',' ','') ";
                    if (SQLHelper.ShowRecord(strSQL).Rows.Count == 0)
                        return true;
                    else
                        return false;
                }//if
                else
                {
                    strSQL = "SELECT ROW_ID,SMTP_SERVER FROM MASTER_EMAILSETTINGS WHERE REPLACE(SMTP_SERVER,' ','') = REPLACE('" + GroupName + "',' ','') AND ROW_ID='" + strRowId + "' ";
                    dt = SQLHelper.ShowRecord(strSQL);
                    
                    if (dt.Rows.Count > 0)
                    {
                        if (strRowId != dt.Rows[0]["ROW_ID"].ToString().Trim())
                        {
                            return false;
                        }
                        else
                            return true;
                    }
                    else
                        return true;
                }//else
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion 

    }
}
